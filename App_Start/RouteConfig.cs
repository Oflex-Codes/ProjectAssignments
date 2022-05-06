using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ProjectAssignments
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            /*routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }*/


            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{username}",
                defaults: new { controller = "authentication", action = "login", username = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "homepage",
               url: "home/{action}/{username}",
               defaults: new { controller = "Homepage", action = "home", username = UrlParameter.Optional }
           );
            //Projects / home
            routes.MapRoute(
              name: "project",
              url: "Projects/{action}/{username}/{projectid}",
              defaults: new { controller = "Projects", action = "home", username = UrlParameter.Optional, projectid = UrlParameter.Optional }
          );
            //    routes.MapRoute(
            //    name: "project",
            //    url: "Projects/{action}/{auth}",
            //    defaults: new { controller = "Projects", action = "complete", auth = UrlParameter.Optional }
            //);
        }
    }
}
