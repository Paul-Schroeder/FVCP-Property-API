using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;

using Castle.Windsor;
using System.Web.Http.Dispatcher;

namespace FVCP.Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config, IWindsorContainer container)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            MapRoutes(config);
            RegisterControllerActivator(container);
        }

        private static void MapRoutes(HttpConfiguration config)
        {
            // Web API routes
            config.MapHttpAttributeRoutes();

            // Map this rule first
            //config.Routes.MapHttpRoute(
            //     "WithActionApi",
            //     "api/{controller}/{action}/{id}"
            // );

            //config.Routes.MapHttpRoute(
            //    name:  "DefaultApi",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { action = "DefaultAction", id = System.Web.Http.RouteParameter.Optional }
            //);

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // For POST with json "data" parameter.
            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi2",
            //    routeTemplate: "api/{controller}/{data}",
            //    defaults: new { }
            //);
        }

        private static void RegisterControllerActivator(IWindsorContainer container)
        {
            GlobalConfiguration.Configuration.Services.Replace(typeof(IHttpControllerActivator),
                new WindsorCompositionRoot(container));
        }
    }
}
