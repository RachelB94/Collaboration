using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Collaboration3.Startup))]
namespace Collaboration3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            
        }
    }
}
