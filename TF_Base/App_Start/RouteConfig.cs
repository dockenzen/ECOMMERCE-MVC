﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TF_Base
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Shared", action = "Home", id = UrlParameter.Optional },
                namespaces: new string[] { "TF_Base.Controllers" }
            );

            routes.MapRoute(
                name: "ShopCategory",
                url: "Producto/{action}/{subcategoria}",
                defaults: new { action = "ShopCategory", subcategoria = UrlParameter.Optional },
                namespaces: new string[] { "TF_Base.Controllers" }
            );
        }
    }
}