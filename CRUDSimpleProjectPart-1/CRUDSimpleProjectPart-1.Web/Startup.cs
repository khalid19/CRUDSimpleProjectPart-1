using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRUDSimpleProjectPart_1.Web.Startup))]
namespace CRUDSimpleProjectPart_1.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
