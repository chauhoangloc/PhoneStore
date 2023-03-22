using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PhoneStore.Startup))]
namespace PhoneStore
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
