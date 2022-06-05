using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SkyAirline.Startup))]
namespace SkyAirline
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
