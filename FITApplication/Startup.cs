using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FITApplication.Startup))]
namespace FITApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
