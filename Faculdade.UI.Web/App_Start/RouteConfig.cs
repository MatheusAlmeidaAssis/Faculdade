﻿using System.Web.Mvc;
using System.Web.Routing;

namespace Faculdade.UI.Web
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{aId}",
                defaults: new { controller = "Home", action = "Index", aId = UrlParameter.Optional }
            );
        }
    }
}
