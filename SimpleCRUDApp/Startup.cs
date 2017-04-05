using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SimpleCRUDApp.Startup))]
namespace SimpleCRUDApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
