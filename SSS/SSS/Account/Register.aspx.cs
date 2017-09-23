using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SSS.Models;
using PostgreSQL.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace SSS.Account
{
    public partial class Register : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                createRolesandUsers();

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>()); 
                var roles = roleManager.Roles.ToList();
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Id";
                DropDownList1.DataSource = roles;
                DropDownList1.DataBind();
                if (!User.IsInRole("Admins"))
                {
                        DropDownList1.Items.FindByText("Admins").Enabled = false;
                }
            }
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = TextUserName.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                // Para obtener más información sobre cómo habilitar la confirmación de cuentas y el restablecimiento de contraseña, visite http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirmar cuenta", "Para confirmar la cuenta, haga clic <a href=\"" + callbackUrl + "\">aquí</a>.");

                ApplicationDbContext context = new ApplicationDbContext();
                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
                var result1 = UserManager.AddToRole(user.Id, DropDownList1.SelectedItem.Text);

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        private void createRolesandUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<PostgreSQL.AspNet.Identity.EntityFramework.IdentityRole>(new RoleStore<PostgreSQL.AspNet.Identity.EntityFramework.IdentityRole>(context));
            var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));


            // In Startup iam creating first Admin Role and creating a default Admin User    
            if (!roleManager.RoleExists("Admins"))
            {

                // first we create Admin rool   
                var role = new PostgreSQL.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Admins";
                roleManager.Create(role);

                //Here we create a Admin super user who will maintain the website                  

                var user = new ApplicationUser();
                user.UserName = "admin";
                user.Email = "admin@sss.com.ar";

                string userPWD = "AdminSSS-q1";

                var chkUser = UserManager.Create(user, userPWD);

                //Add default User to Role Admin   
                if (chkUser.Succeeded)
                {
                    var result1 = UserManager.AddToRole(user.Id, "Admins");

                }
            }

            // creating Creating Manager role    
            if (!roleManager.RoleExists("Supervisor"))
            {
                var role = new PostgreSQL.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Supervisor";
                roleManager.Create(role);

            }

            // creating Creating Employee role    
            if (!roleManager.RoleExists("Operadores"))
            {
                var role = new PostgreSQL.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = "Operadores";
                roleManager.Create(role);

            }
        }
    }
}