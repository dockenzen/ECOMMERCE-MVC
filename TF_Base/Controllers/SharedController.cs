using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TF_Base.Models;

namespace TF_Base.Controllers
{
    public class SharedController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        //
        // GET: /Shared/
        public ActionResult Home()
        {
            var productos = db.Producto.Where(p => p.esDestacado == true).Take(3).ToList();
            return View(productos);
        }

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