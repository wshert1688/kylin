using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace kylin {
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters) {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes) {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                "indexs", // Route name
                "", // URL with parameters
                new { controller = "Home", action = "Index" } // Parameter defaults
            );
            routes.MapRoute(
                "index", // Route name
                "index.html", // URL with parameters
                new { controller = "Home", action = "Index" } // Parameter defaults
            );
            routes.MapRoute(
             "article", // Route name
             "article/{aid}.html", // URL with parameters
             new { controller = "Home", action = "article", aid = 0 }
            );
            routes.MapRoute(
                "admin", // Route name
                "admin/{action}", // URL with parameters
                new { controller = "admin", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );
     

        }

        protected void Application_Start() {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}