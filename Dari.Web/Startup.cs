using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Dari.Web.Startup))]
namespace Dari.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
