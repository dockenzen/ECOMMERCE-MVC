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
    public class OrdenCompraController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        //
        // GET: /OrdenCompra/

        public ActionResult ShopBasket()
        {
            /*var ordencompra = db.OrdenCompra.Include(o => o.Cupon).Include(o => o.OrdenCompraEstado).Include(o => o.Pago).Include(o => o.Sucursal).Include(o => o.Usuario);
            */
            return View();
        }

        //
        // GET: /OrdenCompra/Details/5

        public ActionResult Details(int id = 0)
        {
            OrdenCompra ordencompra = db.OrdenCompra.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }

        //
        // GET: /OrdenCompra/Create

        public ActionResult Create()
        {
            ViewBag.idCupon = new SelectList(db.Cupon, "idCupon", "codigo");
            ViewBag.idEstadoOrden = new SelectList(db.OrdenCompraEstado, "idEstadoOrden", "descripcion");
            ViewBag.idPago = new SelectList(db.Pago, "idPago", "idPago");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "telefono");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "userName");
            return View();
        }

        //
        // POST: /OrdenCompra/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdenCompra ordencompra)
        {
            if (ModelState.IsValid)
            {
                db.OrdenCompra.Add(ordencompra);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCupon = new SelectList(db.Cupon, "idCupon", "codigo", ordencompra.idCupon);
            ViewBag.idEstadoOrden = new SelectList(db.OrdenCompraEstado, "idEstadoOrden", "descripcion", ordencompra.idEstadoOrden);
            ViewBag.idPago = new SelectList(db.Pago, "idPago", "idPago", ordencompra.idPago);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "telefono", ordencompra.idSucursal);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "userName", ordencompra.idUsuario);
            return View(ordencompra);
        }

        //
        // GET: /OrdenCompra/Delete/5
        public ActionResult Delete(int id = 0)
        {
            OrdenCompra ordencompra = db.OrdenCompra.Find(id);
            if (ordencompra == null)
            {
                return HttpNotFound();
            }
            return View(ordencompra);
        }

        //
        // POST: /OrdenCompra/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdenCompra ordencompra = db.OrdenCompra.Find(id);
            db.OrdenCompra.Remove(ordencompra);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ShopCheckoutStep1()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShopCheckoutStep1(int id = 0)
        {
            return View();
        }

        public ActionResult ShopCheckoutStep2()
        {
            return View();
        }

        public ActionResult ShopCheckoutStep3()
        {
            return View();
        }

        public ActionResult ShopCheckoutStep4()
        {
            return View();
        }
    }
}