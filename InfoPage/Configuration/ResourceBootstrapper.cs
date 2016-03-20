using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Conventions;
using Nancy.TinyIoc;
using Nancy.ViewEngines;
using System.Threading;

namespace InfoPage.Configuration
{
    public class ResourceBootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            
            base.ConfigureApplicationContainer(container);
            _ResourceViewLocationProvider.RootNamespaces.Add(GetType().Assembly, GetType().Assembly.GetName().Name+".Views");
            //https://groups.google.com/forum/#!topic/nancy-web-framework/9N4f6-Y4dNA

        }


        protected override void ConfigureConventions(NancyConventions nancyConventions)
        {


            nancyConventions.StaticContentsConventions.Add(EmbeddedStaticContentConventionBuilder.AddDirectory("Content", GetType().Assembly, "Content"));
            base.ConfigureConventions(nancyConventions);
        }

        protected override NancyInternalConfiguration InternalConfiguration
        {
            get { return NancyInternalConfiguration.WithOverrides(OnConfigurationBuilder); }
        }

        private void OnConfigurationBuilder(NancyInternalConfiguration x)
        {
            x.ViewLocationProvider = typeof(_ResourceViewLocationProvider);
            x.StaticContentProvider = typeof(DefaultStaticContentProvider);
            
        }
    }
}
