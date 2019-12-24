using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mvc_Course_Udemy.Startup))]
namespace Mvc_Course_Udemy
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
