using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NerdDinner3.Startup))]
namespace NerdDinner3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
