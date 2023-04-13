using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Semester_3_project.Startup))]
namespace Semester_3_project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
