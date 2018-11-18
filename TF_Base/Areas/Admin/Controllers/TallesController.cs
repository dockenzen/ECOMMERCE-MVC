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
    public class TallesController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        // GET: Admin/Talles
        public ActionResult Index()
        {
            return View(db.Talle.ToList());
        }

        // GET: Admin/Talles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talle talle = db.Talle.Find(id);
            if (talle == null)
            {
                return HttpNotFound();
            }
            return View(talle);
        }

        // GET: Admin/Talles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Talles/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idTalle,descripcion")] Talle talle)
        {
            if (ModelState.IsValid)
            {
                db.Talle.Add(talle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(talle);
        }

        // GET: Admin/Talles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talle talle = db.Talle.Find(id);
            if (talle == null)
            {
                return HttpNotFound();
            }
            return View(talle);
        }

        // POST: Admin/Talles/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idTalle,descripcion")] Talle talle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(talle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(talle);
        }

        // GET: Admin/Talles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Talle talle = db.Talle.Find(id);
            if (talle == null)
            {
                return HttpNotFound();
            }
            return View(talle);
        }

        // POST: Admin/Talles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Talle talle = db.Talle.Find(id);
            db.Talle.Remove(talle);
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
