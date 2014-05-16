using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAplikacija.Startup))]
namespace WebAplikacija
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
