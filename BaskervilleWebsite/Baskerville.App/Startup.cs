using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Baskerville.App.Startup))]
namespace Baskerville.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
