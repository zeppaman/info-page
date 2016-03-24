using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using InfoPage.Configuration;
using InfoPage.Helpers;

namespace InfoPage.Modules
{
    public class WelcomeModule : NancyModule
    {
        public WelcomeModule()
        {
            string baseUrl = InfoPageConfigurator.Configuration.BaseUrl;
            baseUrl = (baseUrl) ?? "info";
            Get["/" + baseUrl] = _ =>
            {
                var model = InfoHelper.GetInfoPage(InfoPageConfigurator.Configuration);

                return View["home.html", model];
            };
        }
    }
}
