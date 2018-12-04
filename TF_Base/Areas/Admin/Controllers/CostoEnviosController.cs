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
    public class CostoEnviosController : Controller
    {
        private ecommerceEntities db = new ecommerceEntities();

        // GET: Admin/CostoEnvios
        public ActionResult Index()
        {
            var costoEnvio = db.CostoEnvio.Include(c => c.Localidad);
            return View(costoEnvio.ToList());
        }

        // GET: Admin/CostoEnvios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostoEnvio costoEnvio = db.CostoEnvio.Find(id);
            if (costoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(costoEnvio);
        }

        // GET: Admin/CostoEnvios/Create
        public ActionResult Create()
        {
            ViewBag.idLocalidad = new SelectList(db.Localidad, "id", "localidad1");
            return View();
        }

        // POST: Admin/CostoEnvios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idCostoEnvio,idLocalidad,Importe")] CostoEnvio costoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.CostoEnvio.Add(costoEnvio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.idLocalidad = new SelectList(db.Localidad, "id", "localidad1", costoEnvio.idLocalidad);
            return View(costoEnvio);
        }

        // GET: Admin/CostoEnvios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostoEnvio costoEnvio = db.CostoEnvio.Find(id);
            if (costoEnvio == null)
            {
                return HttpNotFound();
            }
            ViewBag.idLocalidad = new SelectList(db.Localidad, "id", "localidad1", costoEnvio.idLocalidad);
            return View(costoEnvio);
        }

        // POST: Admin/CostoEnvios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idCostoEnvio,idLocalidad,Importe")] CostoEnvio costoEnvio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(costoEnvio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.idLocalidad = new SelectList(db.Localidad, "id", "localidad1", costoEnvio.idLocalidad);
            return View(costoEnvio);
        }

        // GET: Admin/CostoEnvios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CostoEnvio costoEnvio = db.CostoEnvio.Find(id);
            if (costoEnvio == null)
            {
                return HttpNotFound();
            }
            return View(costoEnvio);
        }

        // POST: Admin/CostoEnvios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CostoEnvio costoEnvio = db.CostoEnvio.Find(id);
            db.CostoEnvio.Remove(costoEnvio);
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
