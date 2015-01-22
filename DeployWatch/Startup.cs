using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(DeployWatch.Startup))]

namespace DeployWatch
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
