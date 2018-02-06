using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BookRentalProj.Startup))]
namespace BookRentalProj
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
