using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GroupProject_dotNET_MVC.Startup))]
namespace GroupProject_dotNET_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
