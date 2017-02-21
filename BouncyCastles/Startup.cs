using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BouncyCastles.Startup))]
namespace BouncyCastles
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
