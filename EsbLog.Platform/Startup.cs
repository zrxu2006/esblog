using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EsbLog.Platform.Startup))]
namespace EsbLog.Platform
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
