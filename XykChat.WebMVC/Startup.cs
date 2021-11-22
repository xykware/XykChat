using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(XykChat.WebMVC.Startup))]
namespace XykChat.WebMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
