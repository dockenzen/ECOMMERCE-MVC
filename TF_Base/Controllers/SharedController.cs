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

        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Color).Include(p => p.Garantia).Include(p => p.Talle);
            return View(producto.ToList());
        }

        public ActionResult Home()
        {
            return View();
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