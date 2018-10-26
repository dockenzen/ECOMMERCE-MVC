using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TF_Base.Controllers
{
    public class NavBarController : Controller
    {
        //GET
        public ActionResult FAQ()
        {
            return View();
        }

        //GET
        public ActionResult About()
        {
            return View();
        }

        //GET
        public ActionResult Contact()
        {
            return View();
        }

    }
}