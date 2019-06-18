using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KohviAutomaat.Startup))]
namespace KohviAutomaat
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
