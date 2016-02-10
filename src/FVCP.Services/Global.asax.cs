using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using FVCP.Infrastructure.DependencyInjection;

using System.Reflection;
using Castle.Windsor.Installer;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;

namespace FVCP.Services
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        WindsorContainer _container;

        protected void Application_Start()
        {
            ConfigureWindsor(GlobalConfiguration.Configuration);

            AreaRegistration.RegisterAllAreas();
            
            //GlobalConfiguration.Configure(WebApiConfig.Register);
            GlobalConfiguration.Configure(c => WebApiConfig.Register(c, _container));

            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        /// <summary>
        /// </summary>
        /// <param name="configuration"></param>
        private void ConfigureWindsor(HttpConfiguration configuration)
        {
            // Castle Windsor setup
            _container = new WindsorContainer();
            //_container.Install(FromAssembly.This()); -- would normally call out to "ApiControllersInstaller", but we handle this with the Register() call below
            //type.Name.EndsWith("Service")) -- would be service if we were using WCF.

            _container.Register(Component.For<IWindsorContainer>().Instance(_container)); // Not a fan of this as it passes a reference to the conatiner itself, but it is necessary for the RequestProcessor to work.

            _container.Register(Classes.FromThisAssembly()
                .Where(type => type.Name.EndsWith("Controller"))
                .WithServiceDefaultInterfaces()
                .LifestylePerWebRequest()
                .Configure(component => component.Named(component.Implementation.FullName)));
            new CompositionRoot().ComposeApplication(_container); // Calls out to Infrastructure project's \DependencyInjection\Installers

            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel, true));


            var dependencyResolver = new WindsorDependencyResolver(_container);
            configuration.DependencyResolver = dependencyResolver;
        }

        protected void Application_End(object sender, EventArgs e)
        {
            if (_container != null)
                _container.Dispose();
        }
    }
}
