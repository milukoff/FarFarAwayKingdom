using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FarFarAway.Startup))]
namespace FarFarAway
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            
        }
    }
}
