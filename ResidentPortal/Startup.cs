using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ResidentPortal.Startup))]
namespace ResidentPortal
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {            
        }
    }
}
