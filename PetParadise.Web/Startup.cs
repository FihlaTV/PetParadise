using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PetParadise.Web.Startup))]
namespace PetParadise.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
