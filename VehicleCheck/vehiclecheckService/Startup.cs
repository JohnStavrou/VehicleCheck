using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(vehiclecheckService.Startup))]

namespace vehiclecheckService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}