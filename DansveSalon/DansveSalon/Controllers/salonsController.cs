using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DansveSalon.Models;

namespace DansveSalon.Controllers
{
    public class salonsController : Controller
    {
        private Entities db = new Entities();

        // GET: salons
        public ActionResult Index()
        {
            return View(db.salon.ToList());
        }

        // GET: salons/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salon salon = db.salon.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // GET: salons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: salons/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "bolumid,bolumadi,acıklama")] salon salon)
        {
            if (ModelState.IsValid)
            {
                db.salon.Add(salon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salon);
        }

        // GET: salons/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salon salon = db.salon.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // POST: salons/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "bolumid,bolumadi,acıklama")] salon salon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salon);
        }

        // GET: salons/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            salon salon = db.salon.Find(id);
            if (salon == null)
            {
                return HttpNotFound();
            }
            return View(salon);
        }

        // POST: salons/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            salon salon = db.salon.Find(id);
            db.salon.Remove(salon);
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
