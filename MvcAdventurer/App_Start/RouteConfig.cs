using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MvcAdventurer
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            routes.MapMvcAttributeRoutes();
            /*  routes.MapRoute(
                   "destinationsByRegions",
                   "destinations/region/{name}",
                   new { controller ="Destinations", action = "ByRegions" }  
               //    new { name = @"\a-z" }
                  );
           
            routes.MapRoute(
                "destinationsList",
                 "destinations/list",
                  new { controller = "Destinations", action = "List" }
                ); */
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
