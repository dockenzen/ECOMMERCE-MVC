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
    public class ProductosController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        // GET: Admin/Productos
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Color).Include(p => p.Garantia).Include(p => p.SubCategoria).Include(p => p.Talle);
            return View(producto.ToList());
        }

        // GET: Admin/Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // GET: Admin/Productos/Create
        public ActionResult Create()
        {
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion");
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion");
            ViewBag.idSubCategoria = new SelectList(db.SubCategoria, "idSubCategoria", "descripcion");
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion");
            return View();
        }

        // POST: Admin/Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,idSubCategoria,descripcion,idTalle,precioUnitario,idGarantia,idColor,esDestacado")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idSubCategoria = new SelectList(db.SubCategoria, "idSubCategoria", "descripcion", producto.idSubCategoria);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        // GET: Admin/Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idSubCategoria = new SelectList(db.SubCategoria, "idSubCategoria", "descripcion", producto.idSubCategoria);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        // POST: Admin/Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,idSubCategoria,descripcion,idTalle,precioUnitario,idGarantia,idColor,esDestacado")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idSubCategoria = new SelectList(db.SubCategoria, "idSubCategoria", "descripcion", producto.idSubCategoria);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        // GET: Admin/Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Admin/Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Producto.Find(id);
            db.Producto.Remove(producto);
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
