﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using WebMatrix.WebData;

namespace TF_Base
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //MODIFICAR
            WebSecurity.InitializeDatabaseConnection("DefaultConnection", "Usuario", "idUsuario", "userName", true);

        }

        protected void Application_Error()
        {
            Exception exception = Server.GetLastError();
            Response.Clear();

            if (exception != null)
            {
                // clear error on server
                Server.ClearError();

                Response.Redirect(String.Format("~/Shared/Error?message={0}", exception.Message));
            }
        }
    }
}