using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text.RegularExpressions;
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
            var ordencompra = db.OrdenCompra.Include(o => o.OrdenCompraEstado).Include(o => o.Sucursal);
            
            return View(ordencompra.First());
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

        [ActionName("DeleteDetalle")]
        public ActionResult DeleteDetalle(int id = 0)
        {
            if (id != 0)
            {
                OrdenCompraDetalle ordenCompraDetalle = db.OrdenCompraDetalle.Find(id);
                db.OrdenCompraDetalle.Remove(ordenCompraDetalle);
                db.SaveChanges();
            }
            return RedirectToAction("ShopBasket");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult ShopCheckoutStep1(int id = 0)
        {
            return View();
        }

        public ActionResult ShopCheckoutStep4()
        {
            return View();
        }

        private bool ValidarNumeroTarjetaIngresada(string numero)
        {
            Regex regex = new Regex("/^(?:4[0-9]{12}(?:[0-9]{3})?|[25][1-7][0-9]{14}|6(?:011|5[0-9][0-9])[0-9]{12}|3[47][0-9]{13}|3(?:0[0-5]|[68][0-9])[0-9]{11}|(?:2131|1800|35\\d{3})\\d{11})$/");
            return regex.IsMatch(numero);
        }
    }
}