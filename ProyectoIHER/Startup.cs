using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ProyectoIHER.Startup))]
namespace ProyectoIHER
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
