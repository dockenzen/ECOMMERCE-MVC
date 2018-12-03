using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TF_Base.Models;

namespace TF_Base.Areas.Admin.Controllers
{
    public class StocksController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        // GET: Admin/Stocks
        public ActionResult Index()
        {
            var stock = db.Stock.Include(s => s.Producto).Include(s => s.Sucursal);
            ViewBag.Sucursales = GetSucursalesList();
            ViewBag.SeleccionSucursal = "Casa Central";
            return View(stock.Where(s => s.Sucursal.descripcion == "Casa Central").ToList());
        }

        private SelectList GetSucursalesList()
        {
            SelectList sucursalesList = new SelectList(db.Sucursal.ToList(), "idSucursal", "descripcion");
            return sucursalesList;
        }

        private string GetSucursalSelect(string value) 
        {
            int idsucursal = int.Parse(value != "" ? value : "0");
            return idsucursal != 0 ? db.Sucursal.Where(s => s.idSucursal == idsucursal).FirstOrDefault().descripcion : "sin selección";
        }

        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            var stock = db.Stock.Include(s => s.Producto).Include(s => s.Sucursal);
            ViewBag.Sucursales = GetSucursalesList();
            string sucursalDesc = GetSucursalSelect(form.GetValue("ddlSucursales").AttemptedValue);
            ViewBag.SeleccionSucursal = sucursalDesc;
            return View(stock.Where(s => s.Sucursal.descripcion.Contains(sucursalDesc)).ToList());
        }
        // GET: Admin/Stocks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // GET: Admin/Stocks/Create
        public ActionResult Create()
        {
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion");
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "descripcion");
            return View();
        }

        // POST: Admin/Stocks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idStock,idSucursal,idProducto,cantidad,minimo,maximo")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Stock.Add(stock);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", stock.idProducto);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "descripcion", stock.idSucursal);
            return View(stock);
        }

        // GET: Admin/Stocks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", stock.idProducto);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "descripcion", stock.idSucursal);
            return View(stock);
        }

        // POST: Admin/Stocks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idStock,idSucursal,idProducto,cantidad,minimo,maximo")] Stock stock)
        {
            if (ModelState.IsValid)
            {
                db.Entry(stock).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idProducto = new SelectList(db.Producto, "idProducto", "descripcion", stock.idProducto);
            ViewBag.idSucursal = new SelectList(db.Sucursal, "idSucursal", "descripcion", stock.idSucursal);
            return View(stock);
        }

        // GET: Admin/Stocks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Stock stock = db.Stock.Find(id);
            if (stock == null)
            {
                return HttpNotFound();
            }
            return View(stock);
        }

        // POST: Admin/Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Stock stock = db.Stock.Find(id);
            db.Stock.Remove(stock);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
