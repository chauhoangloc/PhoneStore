using Microsoft.Owin;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PhoneStore.Models;

[assembly: OwinStartupAttribute(typeof(PhoneStore.Startup))]
namespace PhoneStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
          //  InitUserRole();
        }
        private void InitUserRole()
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            try
            {

                if (!roleManager.RoleExists("Admin")) { 
                    var role = new IdentityRole();
                    role.Name = "Admin";
                    roleManager.Create(role);
                 
                    var user = new ApplicationUser();
                    user.UserName = "admin@pt.com";
                    user.Email = "admin@pt.com";
                    string pass = "000000";
                    var chkUser = userManager.Create(user, pass);  

                    if (chkUser.Succeeded)
                        userManager.AddToRole(user.Id, "Admin");
                }
            }
            catch { }
        }
    }
}
