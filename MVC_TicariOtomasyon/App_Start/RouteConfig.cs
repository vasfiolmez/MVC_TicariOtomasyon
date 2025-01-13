using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC_TicariOtomasyon
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
               name: "CargoDetails",
               url: "Admin/Cargo/CargoDetail/{trackingcode}",
               defaults: new { controller = "Cargo", action = "CargoDetail",Areas="Admin", trackingcode = UrlParameter.Optional }
           );
            routes.MapRoute(
              name: "CustomerCargoDetails",
              url: "CustomerPanel/Cargo/CargoDetail/{trackingcode}",
              defaults: new { controller = "Cargo", action = "CargoDetail", Areas = "CustomerPanel", trackingcode = UrlParameter.Optional }
          );
        }
    }
}
