using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Boosting.Startup))]
namespace Boosting
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
