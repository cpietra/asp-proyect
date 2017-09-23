using SSS.Model;
using SSS.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SSS.system
{
    public partial class sys_users : System.Web.UI.Page
    {
        private UsuariosClass usuario = new UsuariosClass();
        private DAO dao = new DAO();
        private String operador;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                txtpassword.Attributes["type"] = "password";
                operador = Session["operador"] as String;
                if (operador == null)
                {
                    if (Request.Cookies["userName"] != null)
                    {
                        HttpCookie aCookie = Request.Cookies["userName"];
                        operador = Server.HtmlEncode(aCookie.Value);
                        Session["operador"] = operador;
                    }
                }
                reader_gridview();
                Button2.Enabled = false;
                Button3.Enabled = false;
            }
        }

        private void reader_gridview()
        {
            operador = Session["operador"] as String;
            if (operador == null)
            {
                if (Request.Cookies["userName"] != null)
                {
                    HttpCookie aCookie = Request.Cookies["userName"];
                    operador = Server.HtmlEncode(aCookie.Value);
                    Session["operador"] = operador;
                }
            }

            GridView1.DataSource = dao.GetData("Select id, username, password, nivel FROM users");
            GridView1.DataBind();
            //GridView1.Columns[7].Visible = false;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                usuario = new UsuariosClass();
                usuario.Username = txtusername.Text.Trim();
                usuario.Password = txtpassword.Text;
                usuario.Nivel = Convert.ToInt32(txtnivel.Text);
                String id_users = dao.create_user(usuario);
                usuario.Id = Convert.ToInt32(id_users);
                clear_fieds();
                reader_gridview();

                Configuration webConfigApp = WebConfigurationManager.OpenWebConfiguration("~");
                String value = webConfigApp.AppSettings.Settings["allow"].Value;
                webConfigApp.AppSettings.Settings["allow users"].Value = value + ", " + usuario.Username.ToString();
                webConfigApp.Save();

            }
        }

        private void clear_fieds()
        {
            txtusername.Text = "";
            txtpassword.Text = "";
            txtnivel.Text = "";
            Button1.Enabled = true;
            Button2.Enabled = false;
            Button3.Enabled = false;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                usuario = new UsuariosClass();
                usuario.Username = txtusername.Text.Trim();
                usuario.Password = txtpassword.Text.Trim();
                usuario.Nivel = Convert.ToInt32(txtnivel.Text);
                dao.update_user(usuario);
                clear_fieds();
                reader_gridview();
            }
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            usuario = new UsuariosClass();
            usuario = Session["users_Session"] as UsuariosClass;
            dao.borrar_user(usuario.Id);
            clear_fieds();
            reader_gridview();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            var colsNoVisible = GridView1.DataKeys[row.RowIndex].Values;
            usuario.Id = (Int32)colsNoVisible[0];
            if (row.Cells[2].Text != "" && row.Cells[2].Text.IndexOf("nbsp;") == -1)
            {
                usuario.Username = row.Cells[2].Text;
            }
            else
            {
                usuario.Username = "";
            }
            if (row.Cells[3].Text != "" && row.Cells[3].Text.IndexOf("nbsp;") == -1)
            {
                usuario.Password = row.Cells[3].Text;
            }
            else
            {
                usuario.Password = "";
            }
            if (row.Cells[4].Text != "" && row.Cells[4].Text.IndexOf("nbsp;") == -1)
            {
                usuario.Nivel = Convert.ToInt32(row.Cells[4].Text);
            }
            else
            {
                usuario.Nivel = 0;
            }
            txtusername.Text = usuario.Username;
            txtpassword.Text = usuario.Password;
            txtnivel.Text = usuario.Nivel.ToString();
            Session["users_session"] = usuario;
            Button1.Enabled = false;
            Button2.Enabled = true;
            Button3.Enabled = true;
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            reader_gridview();
        }

        protected void gridview1_Sorting(object sender, GridViewSortEventArgs e)
        {
            DataTable dataTable = GridView1.DataSource as DataTable;
            if (dataTable != null)
            {
                DataView dataView = new DataView(dataTable);
                dataView.Sort = e.SortExpression + " " + ConvertSortDirection(e.SortDirection);
                GridView1.DataSource = dataView;
                GridView1.DataBind();
            }

        }

        private string ConvertSortDirection(SortDirection sortDirection)
        {
            string newSortDirection = String.Empty;

            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    newSortDirection = "ASC";
                    break;

                case SortDirection.Descending:
                    newSortDirection = "DESC";
                    break;
            }

            return newSortDirection;
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            clear_fieds();
            Button1.Enabled = true;
            Button2.Enabled = false;
            Button3.Enabled = false;

        }
    }
}