using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WeddingPlanner.Web.ActionFilter;
using WeddingPlanner.Web.App_Start;

namespace WeddingPlanner.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new GlobalExceptionAttribute());
        }
    }
}
