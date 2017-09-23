using Microsoft.Owin;
using Owin;
using SSS.Models;
using System.Data.Entity;

[assembly: OwinStartupAttribute(typeof(SSS.Startup))]
namespace SSS
{
    public partial class Startup {

        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
            Database.SetInitializer<ApplicationDbContext>(new CreateDatabaseIfNotExists<ApplicationDbContext>());
        }
    }
}


