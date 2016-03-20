using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;

namespace InfoPage.Modules
{
    public class WelcomeModule : NancyModule
    {
        public WelcomeModule()
        {
            string baseHome = ConfigurationManager.AppSettings["InfoPage:home"];
            baseHome = (baseHome) ?? "info";
            Get["/"+baseHome] = _ => {
                var model = new
                {
                    title = "We've Got Issues..."
                };

                return View["home.html", model];
            };
        }
    }
}
