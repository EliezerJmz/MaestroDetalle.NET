using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MaestroDetalle.Startup))]
namespace MaestroDetalle
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
