using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication3
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Informe", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "CompraVenta",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "CompraVenta", action = "Index", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Informe",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Informe", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
