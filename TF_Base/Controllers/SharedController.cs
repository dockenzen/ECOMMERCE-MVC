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

        //
        // GET: /Shared/Details/5

        public ActionResult Details(int id = 0)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // GET: /Shared/Create

        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descripcion");
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion");
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion");
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion");
            return View();
        }

        //
        // POST: /Shared/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descripcion", producto.idCategoria);
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        //
        // GET: /Shared/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descripcion", producto.idCategoria);
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        //
        // POST: /Shared/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descripcion", producto.idCategoria);
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        //
        // GET: /Shared/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // POST: /Shared/Delete/5

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
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}