using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mayibookabook.Startup))]
namespace Mayibookabook
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
