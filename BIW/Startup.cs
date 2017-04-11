using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BIW.Startup))]
namespace BIW
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
