using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace SklepUKW
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
              name: "FilmDetails",
              url: "details_{id}.html",
              defaults: new { controller = "Films", action = "Details" }
              );

            routes.MapRoute(
               name: "FilmsList",
               url: "ziemniak/{categoryName}.html",
               defaults: new { controller = "Films", action = "List" }
               );

            routes.MapRoute(
               name: "StaticSite",
               url: "info/{name}.html",
               defaults: new { controller = "Home", action = "StaticSite" }
               );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

           
        }
    }
}
