using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AHPortfolio.Startup))]
namespace AHPortfolio
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
