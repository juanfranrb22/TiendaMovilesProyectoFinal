using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin;
using Owin;
using TiendaMovilesProyectoFinal.Models;

[assembly: OwinStartup(typeof(TiendaMovilesProyectoFinal.Startup))]
namespace TiendaMovilesProyectoFinal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            CreateRolesAndUsers();
        }


        private void CreateRolesAndUsers()
        {
            ApplicationDbContext context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            /* if (!roleManager.RoleExists("Administrador"))
             {

                 var role = new IdentityRole();
                 role.Name = "Administrador";
                 roleManager.Create(role);


                 var user = new ApplicationUser();
                 user.UserName = "admin";
                 user.Email = "admin@example.com";

                 string userPWD = "Admin@123";

                 var chkUser = userManager.Create(user, userPWD);

                 // Añadir usuario al rol Administrador
                 if (chkUser.Succeeded)
                 {
                     var result1 = userManager.AddToRole(user.Id, "Administrador");
                 }
             }*/

            // Crear otros roles aquí si es necesario
            /* if (!roleManager.RoleExists("Usuario"))
             {
                 var role = new IdentityRole();
                 role.Name = "Usuario";
                 roleManager.Create(role);
             }
         }*/
        }
    }
}
