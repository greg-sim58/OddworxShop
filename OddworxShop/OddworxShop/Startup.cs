using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OddworxShop.Startup))]
namespace OddworxShop
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
