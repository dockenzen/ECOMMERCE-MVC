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
    public class GarantiasController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        // GET: Admin/Garantias
        public ActionResult Index()
        {
            return View(db.Garantia.ToList());
        }

        // GET: Admin/Garantias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantia garantia = db.Garantia.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            return View(garantia);
        }

        // GET: Admin/Garantias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Garantias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idGarantia,descripcion,duracion")] Garantia garantia)
        {
            if (ModelState.IsValid)
            {
                db.Garantia.Add(garantia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(garantia);
        }

        // GET: Admin/Garantias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantia garantia = db.Garantia.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            return View(garantia);
        }

        // POST: Admin/Garantias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idGarantia,descripcion,duracion")] Garantia garantia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(garantia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(garantia);
        }

        // GET: Admin/Garantias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Garantia garantia = db.Garantia.Find(id);
            if (garantia == null)
            {
                return HttpNotFound();
            }
            return View(garantia);
        }

        // POST: Admin/Garantias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Garantia garantia = db.Garantia.Find(id);
            db.Garantia.Remove(garantia);
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
