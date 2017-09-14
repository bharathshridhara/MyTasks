using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyTasks.Startup))]
namespace MyTasks
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
