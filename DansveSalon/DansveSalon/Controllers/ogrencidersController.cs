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
    public class ogrencidersController : Controller
    {
        private Entities db = new Entities();

        // GET: ogrenciders
        public ActionResult Index()
        {
            var ogrenciders = db.ogrenciders.Include(o => o.dans).Include(o => o.ogrenci);
            return View(ogrenciders.ToList());
        }

        // GET: ogrenciders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogrenciders ogrenciders = db.ogrenciders.Find(id);
            if (ogrenciders == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciders);
        }

        // GET: ogrenciders/Create
        public ActionResult Create()
        {
            ViewBag.dansid = new SelectList(db.dans, "dansid", "dansadi");
            ViewBag.ono = new SelectList(db.ogrenci, "ono", "adi");
            return View();
        }

        // POST: ogrenciders/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ono,dansid,ogdersid")] ogrenciders ogrenciders)
        {
            if (ModelState.IsValid)
            {
                db.ogrenciders.Add(ogrenciders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dansid = new SelectList(db.dans, "dansid", "dansadi", ogrenciders.dansid);
            ViewBag.ono = new SelectList(db.ogrenci, "ono", "adi", ogrenciders.ono);
            return View(ogrenciders);
        }

        // GET: ogrenciders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogrenciders ogrenciders = db.ogrenciders.Find(id);
            if (ogrenciders == null)
            {
                return HttpNotFound();
            }
            ViewBag.dansid = new SelectList(db.dans, "dansid", "dansadi", ogrenciders.dansid);
            ViewBag.ono = new SelectList(db.ogrenci, "ono", "adi", ogrenciders.ono);
            return View(ogrenciders);
        }

        // POST: ogrenciders/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ono,dansid,ogdersid")] ogrenciders ogrenciders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogrenciders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dansid = new SelectList(db.dans, "dansid", "dansadi", ogrenciders.dansid);
            ViewBag.ono = new SelectList(db.ogrenci, "ono", "adi", ogrenciders.ono);
            return View(ogrenciders);
        }

        // GET: ogrenciders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogrenciders ogrenciders = db.ogrenciders.Find(id);
            if (ogrenciders == null)
            {
                return HttpNotFound();
            }
            return View(ogrenciders);
        }

        // POST: ogrenciders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ogrenciders ogrenciders = db.ogrenciders.Find(id);
            db.ogrenciders.Remove(ogrenciders);
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
