using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using jcPVS.Library;

namespace jcPVS.Tests.WebAPI {
    public static class WebApiConfig {
        public static void Register(HttpConfiguration config) {
            // Web API configuration and services
            config.Formatters.Clear();
            config.Formatters.Add(new jcPVSMediaFormatter());
           
            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
