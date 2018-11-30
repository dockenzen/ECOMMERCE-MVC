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
            var productos = db.Producto.Where(p => p.esDestacado.HasValue).Take(3).ToList();
            ViewData.Add("Carrusel", db.ImagenProducto.Where(ip => ip.esCarrusel).ToList());

            return View(productos);
        }

        public ActionResult FAQ()
        {
            return View();
        }

        //GET
        public ActionResult About()
        {
            ViewData.Add("VENTAS", db.OrdenCompra.Where(e => e.OrdenCompraEstado.idEstadoOrden == 5).Count().ToString());
            ViewData.Add("CLIENTES", db.Usuario.Count());
            ViewData.Add("SUCURSALES", db.Sucursal.Count().ToString());
            ViewData.Add("PRODUCTOS", db.Producto.Count().ToString());
            return View();
        }

        //GET
        public ActionResult Contact()
        {
            return View();
        }


    }
}