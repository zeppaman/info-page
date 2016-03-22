using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Owin;
using System.Diagnostics;

namespace InfoPage.Configuration
{
    public static class InfoPageConfigurator
    {
        private static InfoPageConfiguration _current;
        public static InfoPageConfiguration Configuration { get { return _current ?? (_current = new InfoPageConfiguration()); } }

        public static void Configure( IAppBuilder app, Action<InfoPageConfiguration> conf)
        {

            StackFrame frame = new StackFrame(1);
            var method = frame.GetMethod();
            var type = method.DeclaringType;
            

           app  .UseNancy(options =>
          {
              options.Bootstrapper = new ResourceBootstrapper();
              options.PerformPassThrough = (context => context.Response.StatusCode == HttpStatusCode.NotFound);
          });


            InfoPageConfiguration settings = new InfoPageConfiguration();

            settings.MainAssembly=type.Assembly;
            conf.Invoke(settings);

            InfoPageConfigurator._current = settings;
           

        }
    }
}

