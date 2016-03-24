using InfoPage.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfoPage.WebTest.Startup))]
namespace InfoPage.WebTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            InfoPageConfigurator.Configure(app, 
                x => {
                    x.BaseUrl = "custom-info";
                    x.ApplicationName = "My Sample Application";
                });
        }
    }
}
