using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Owin;

namespace InfoPage.Configuration
{
    public static class InfoPageConfigurator
    {
        private static InfoPageConfiguration _current;
        public static InfoPageConfiguration Configuration { get { return (_current = new InfoPageConfiguration()) ?? _current; } }

        public static void Configure(IAppBuilder app, Action<InfoPageConfiguration> conf)
        {

           app  .UseNancy(options =>
          {
              options.Bootstrapper = new ResourceBootstrapper();
              options.PerformPassThrough = (context => context.Response.StatusCode == HttpStatusCode.NotFound);
          });


            InfoPageConfiguration settings = new InfoPageConfiguration();

            conf.Invoke(settings);
           

        }
    }
}

