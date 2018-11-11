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
    public class DatosPersonalesController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        // GET: DatosPersonales
        public ActionResult Index()
        {
            var datosPersonales = db.DatosPersonales.Include(d => d.Direccion).Include(d => d.Usuario);
            return View(datosPersonales.ToList());
        }

        // GET: DatosPersonales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            if (datosPersonales == null)
            {
                return HttpNotFound();
            }
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Create
        public ActionResult Create()
        {
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "direccion1");
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "userName");
            return View();
        }

        // POST: DatosPersonales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "datosPersonalesId,nombre,apellido,dni,idDireccion,idUsuario")] DatosPersonales datosPersonales)
        {
            if (ModelState.IsValid)
            {
                db.DatosPersonales.Add(datosPersonales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "direccion1", datosPersonales.idDireccion);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "userName", datosPersonales.idUsuario);
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            if (datosPersonales == null)
            {
                return HttpNotFound();
            }
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "direccion1", datosPersonales.idDireccion);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "userName", datosPersonales.idUsuario);
            return View(datosPersonales);
        }

        // POST: DatosPersonales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "datosPersonalesId,nombre,apellido,dni,idDireccion,idUsuario")] DatosPersonales datosPersonales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(datosPersonales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idDireccion = new SelectList(db.Direccion, "idDireccion", "direccion1", datosPersonales.idDireccion);
            ViewBag.idUsuario = new SelectList(db.Usuario, "idUsuario", "userName", datosPersonales.idUsuario);
            return View(datosPersonales);
        }

        // GET: DatosPersonales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            if (datosPersonales == null)
            {
                return HttpNotFound();
            }
            return View(datosPersonales);
        }

        // POST: DatosPersonales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatosPersonales datosPersonales = db.DatosPersonales.Find(id);
            db.DatosPersonales.Remove(datosPersonales);
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
