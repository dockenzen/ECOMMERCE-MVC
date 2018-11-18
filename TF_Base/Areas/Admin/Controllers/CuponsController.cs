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
    public class CuponsController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        // GET: Admin/Cupons
        public ActionResult Index()
        {
            return View(db.Cupon.ToList());
        }

        // GET: Admin/Cupons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupon cupon = db.Cupon.Find(id);
            if (cupon == null)
            {
                return HttpNotFound();
            }
            return View(cupon);
        }

        // GET: Admin/Cupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Cupons/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCupon,cantidad,codigo,fechaCaducidad,porcentajeDescuento,descripcion")] Cupon cupon)
        {
            if (ModelState.IsValid)
            {
                db.Cupon.Add(cupon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cupon);
        }

        // GET: Admin/Cupons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupon cupon = db.Cupon.Find(id);
            if (cupon == null)
            {
                return HttpNotFound();
            }
            return View(cupon);
        }

        // POST: Admin/Cupons/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCupon,cantidad,codigo,fechaCaducidad,porcentajeDescuento,descripcion")] Cupon cupon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cupon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cupon);
        }

        // GET: Admin/Cupons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cupon cupon = db.Cupon.Find(id);
            if (cupon == null)
            {
                return HttpNotFound();
            }
            return View(cupon);
        }

        // POST: Admin/Cupons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cupon cupon = db.Cupon.Find(id);
            db.Cupon.Remove(cupon);
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
