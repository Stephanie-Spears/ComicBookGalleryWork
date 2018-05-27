using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ComicBookGallery
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "ComicBooks", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
//The routes for an ASP.NET MVC website or application are defined by adding a series of rules to the RouteCollection object in the order that they should be applied to incoming requests.