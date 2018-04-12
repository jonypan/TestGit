using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hanvet
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "tin-tuc",
                url: "tin-tuc",
                defaults: new { controller = "Tintuc", action = "Tintuc", id = UrlParameter.Optional },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            routes.MapRoute(
                name: "benh-va-dieu-tri",
                url: "benh-va-dieu-tri/{url}",
                defaults: new { controller = "Tintuc", action = "BenhVaDieuTri", url = "benh-va-dieu-tri" },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            routes.MapRoute(
                name: "san-pham",
                url: "san-pham/{url}",
                defaults: new { controller = "Sanpham", action = "Sanpham", url = "san-pham" },
                namespaces: new[] { "Hanvet.Controllers" }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces : new []{"Hanvet.Controllers"}
            );

        }
    }
}
