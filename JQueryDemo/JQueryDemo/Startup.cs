using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JQueryDemo.Startup))]
namespace JQueryDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
