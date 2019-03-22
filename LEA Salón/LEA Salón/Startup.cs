using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LEA_Salón.Startup))]
namespace LEA_Salón
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
