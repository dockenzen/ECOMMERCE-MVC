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
    public class ProductoController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        //
        // GET: /Producto/
        [HttpGet]
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Color).Include(p => p.Garantia).Include(p => p.Talle);
            return View(producto.ToList());
        }

        //
        // GET: /Producto/Details/5
        [HttpGet]
        public ActionResult ShopDetail(int id = 0)
        {
            Producto producto = db.Producto.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        //
        // GET: /Producto/Create
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descripcion");
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion");
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion");
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion");
            return View();
        }

        //
        // POST: /Producto/Create

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
        // GET: /Producto/Edit/5

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
        // POST: /Producto/Edit/5

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
        // GET: /Producto/Delete/5

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
        // POST: /Producto/Delete/5

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

        [HttpGet]
        public ActionResult ShopCategory()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Color).Include(p => p.Talle);
            GetCategorias();
            GetColores();
            return View(producto.ToList());
        }

        private void GetCategorias()
        {
            ViewBag.Categorias = db.Categoria.ToList(); 
        }
        private void GetColores()
        {
            ViewBag.Colores = db.Color.ToList();
        }
        
    }
}