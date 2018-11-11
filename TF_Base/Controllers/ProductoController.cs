using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TF_Base.Models;

namespace TF_Base.Controllers
{
    public class ProductoController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        // GET: Productoes
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.Categoria).Include(p => p.Color).Include(p => p.Garantia).Include(p => p.Talle);
            return View(producto.ToList());
        }

        // GET: Productoes/Details/5
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

        // GET: Productoes/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descripcion");
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion");
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion");
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion");
            return View();
        }

        // POST: Productoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,idCategoria,descripcion,idTalle,precioUnitario,idGarantia,idColor,fotoUrl")] Producto producto)
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

        // GET: Productoes/Edit/5
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
            ViewBag.idCategoria = new SelectList(db.Categoria, "idCategoria", "descripcion", producto.idCategoria);
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        // POST: Productoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,idCategoria,descripcion,idTalle,precioUnitario,idGarantia,idColor,fotoUrl")] Producto producto)
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

        // GET: Productoes/Delete/5
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

        // POST: Productoes/Delete/5
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

        [HttpPost]
        public ActionResult ShopCategory(FormCollection form)
        {
            List<int> listaFiltro = new List<int>();
            foreach (Color color in db.Color.ToList())
            {
                var sarasa = form.GetValues(color.idColor.ToString());
                if (sarasa.Contains("true"))
                    listaFiltro.Add(color.idColor);
            }
            var productos = db.Producto.Join(listaFiltro, p => p.idColor, l => l, (p, l) => new { Prod = p, Col = l }).Where(p => p.Prod.idColor == p.Col).Select(p => p.Prod).ToList();
            GetCategorias();
            GetColores();
            return View(productos.ToList());
        }

    }
}
