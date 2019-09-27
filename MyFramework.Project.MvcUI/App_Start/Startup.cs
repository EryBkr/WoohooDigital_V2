using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(MyFramework.Project.MvcUI.App_Start.Startup))]

namespace MyFramework.Project.MvcUI.App_Start
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}
