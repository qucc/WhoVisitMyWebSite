using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WhoVisitMyWebSite.Startup))]
namespace WhoVisitMyWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
