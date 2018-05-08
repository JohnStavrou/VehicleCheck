using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(VehicleCheckService.Startup))]

namespace VehicleCheckService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}