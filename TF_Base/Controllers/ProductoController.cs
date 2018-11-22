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

        // GET: Producto
        public ActionResult Index()
        {
            var producto = db.Producto.Include(p => p.SubCategoria).Include(p => p.Color).Include(p => p.Garantia).Include(p => p.Talle);
            return View(producto.ToList());
        }

        // GET: Producto/Details/5
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

        // GET: Producto/Create
        public ActionResult Create()
        {
            ViewBag.idCategoria = new SelectList(db.Categoria, "idSubCategoria", "descripcion");
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion");
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion");
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion");
            return View();
        }

        // POST: Producto/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idProducto,idSubCategoria,descripcion,idTalle,precioUnitario,idGarantia,idColor,fotoUrl")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Producto.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idCategoria = new SelectList(db.Categoria, "idSubCategoria", "descripcion", producto.idSubCategoria);
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        // GET: Producto/Edit/5
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
            ViewBag.idCategoria = new SelectList(db.Categoria, "idSubCategoria", "descripcion", producto.idSubCategoria);
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        // POST: Producto/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idProducto,idSubCategoria,descripcion,idTalle,precioUnitario,idGarantia,idColor,fotoUrl")] Producto producto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idCategoria = new SelectList(db.Categoria, "idSubCategoria", "descripcion", producto.idSubCategoria);
            ViewBag.idColor = new SelectList(db.Color, "idColor", "descripcion", producto.idColor);
            ViewBag.idGarantia = new SelectList(db.Garantia, "idGarantia", "descripcion", producto.idGarantia);
            ViewBag.idTalle = new SelectList(db.Talle, "idTalle", "descripcion", producto.idTalle);
            return View(producto);
        }

        // GET: Producto/Delete/5
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

        // POST: Producto/Delete/5
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
        public ActionResult ShopCategory(int? idSubcategoria = null)
        {
            var producto = db.Producto.Include(p => p.SubCategoria).Include(p => p.Color).Include(p => p.Talle);
            if(idSubcategoria.HasValue)
                producto = producto.Where(p => p.SubCategoria.idSubCategoria == idSubcategoria);
            ViewBag.Categorias = db.Categoria.ToList();
            ViewBag.SubCategorias = db.SubCategoria.ToList();
            ViewBag.Colores = db.Color.ToList();
            return View(producto.ToList());
        }

        [HttpPost]
        public ActionResult ShopCategory(FormCollection form)
        {
            List<int> listaFiltro = new List<int>();
            List<Producto> productos = new List<Producto>();
            foreach (Color color in db.Color.ToList())
            {
                var sarasa = form.GetValues(color.idColor.ToString());
                if (sarasa.Contains("true"))
                    listaFiltro.Add(color.idColor);
            }

            if (listaFiltro.Count > 0)
               productos = db.Producto.Join(listaFiltro, p => p.idColor, l => l, (p, l) => new { Prod = p, Col = l }).Where(p => p.Prod.idColor == p.Col).Select(p => p.Prod).ToList();
            else
               productos = db.Producto.ToList();

            ViewBag.Categorias = db.Categoria.ToList();
            ViewBag.SubCategorias = db.SubCategoria.ToList();
            ViewBag.Colores = db.Color.ToList();
            return View(productos);
        }

        [HttpGet]
        public ActionResult ShopDetail(int id = 0)
        {
            var producto = db.Producto.Find(id);

            ViewBag.Talles = new SelectList(db.Talle.ToList(), "idTalle", "descripcion", producto.Talle.idTalle);
            ViewBag.ProductosAlAzar = db.Producto.Where(p => p.SubCategoria.idCategoria == producto.idSubCategoria).Take(3).ToList();

            return View(producto);
        }

        public ActionResult AgregarProductoWishlist(int id = 0)
        {
            int idUsuario = WebMatrix.WebData.WebSecurity.CurrentUserId;
            if (!db.WishList.Any(w => w.idProducto == id && w.idUsuario == idUsuario))
            {
                WishList wishList = new WishList()
                {
                    Producto = db.Producto.Find(id),
                    Usuario = db.Usuario.Find(idUsuario)
                };
                db.WishList.Add(wishList);
                db.SaveChanges();
            }
            else
            {
                WishList wish = db.WishList.FirstOrDefault(w => w.idProducto == id && w.idUsuario == idUsuario);
                db.WishList.Remove(wish);
                db.SaveChanges();
            }
            return RedirectToAction("CustomerWishlist","Usuario");
        }

        public ActionResult AgregarProductoCarrito(int id = 0)
        {
            return View();
        }

    }
}
