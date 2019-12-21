using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(prjWedding.Startup))]
namespace prjWedding
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
