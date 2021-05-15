using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MvcAdventurer.Startup))]
namespace MvcAdventurer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
