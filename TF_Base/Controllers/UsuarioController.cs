using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using TF_Base.Models;

namespace TF_Base.Controllers
{
    public class UsuarioController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            var usuario = db.Usuario.Include(u => u.UsuarioEstado);
            return View(usuario.ToList());
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            ViewBag.idEstadoUsuario = new SelectList(db.UsuarioEstado, "idEstado", "descripcion");
            return View();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idEstadoUsuario = new SelectList(db.UsuarioEstado, "idEstado", "descripcion", usuario.idEstadoUsuario);
            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.idEstadoUsuario = new SelectList(db.UsuarioEstado, "idEstado", "descripcion", usuario.idEstadoUsuario);
            return View(usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idEstadoUsuario = new SelectList(db.UsuarioEstado, "idEstado", "descripcion", usuario.idEstadoUsuario);
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [Authorize(Roles = "Cliente")]
        public ActionResult CustomerAccount()
        {
            var datos = db.Usuario.FirstOrDefault(u => u.idUsuario == WebMatrix.WebData.WebSecurity.CurrentUserId).DatosPersonales;

            ViewBag.Localidades = new SelectList(db.Localidad, "id", "localidad1", datos.Direccion.idLocalidad);
            
            return View(datos);
        }

        [Authorize(Roles = "Cliente")]
        [HttpPost]
        public ActionResult CustomerAccount(DatosPersonales datos)
        {
            if (ModelState.IsValid)
            {
                Localidad localidad = db.Localidad.Find(datos.Direccion.idLocalidad);
                datos.Direccion.Localidad = localidad;

                db.Entry(datos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("CustomerAccount");
            }

            ViewBag.Localidades = new SelectList(db.Localidad, "id", "localidad1", datos.Direccion.idLocalidad);

            return View(datos);
        }

        [Authorize(Roles = "Cliente")]
        public ActionResult CustomerOrder(int id = 0)
        {
            var ordenCompra = db.OrdenCompra.Find(id);

            return View(ordenCompra);
        }

        [Authorize(Roles = "Cliente")]
        public ActionResult CustomerOrders()
        {
            var ordenesCompra = db.OrdenCompra.Where(o => o.idUsuario == WebMatrix.WebData.WebSecurity.CurrentUserId);
            return View(ordenesCompra.ToList());
        }

        [Authorize(Roles = "Cliente")]
        public ActionResult CustomerWishlist()
        {
            //todo iqualitycomparer de distinct x producto.id (?
            var wishlist = db.WishList.Where(w => w.idUsuario == WebMatrix.WebData.WebSecurity.CurrentUserId)
                                      .Select(p=> p.Producto)
                                      .Distinct();
            
            return View(wishlist.ToList());
        }

    }
}