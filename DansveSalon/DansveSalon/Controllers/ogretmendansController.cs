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
    public class ogretmendansController : Controller
    {
        private Entities db = new Entities();

        // GET: ogretmendans
        public ActionResult Index()
        {
            var ogretmendans = db.ogretmendans.Include(o => o.dans).Include(o => o.ogretmen);
            return View(ogretmendans.ToList());
        }

        // GET: ogretmendans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogretmendans ogretmendans = db.ogretmendans.Find(id);
            if (ogretmendans == null)
            {
                return HttpNotFound();
            }
            return View(ogretmendans);
        }

        // GET: ogretmendans/Create
        public ActionResult Create()
        {
            ViewBag.dansid = new SelectList(db.dans, "dansid", "dansadi");
            ViewBag.ogrid = new SelectList(db.ogretmen, "ogrid", "adi");
            return View();
        }

        // POST: ogretmendans/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ogrdesid,ogrid,dansid")] ogretmendans ogretmendans)
        {
            if (ModelState.IsValid)
            {
                db.ogretmendans.Add(ogretmendans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.dansid = new SelectList(db.dans, "dansid", "dansadi", ogretmendans.dansid);
            ViewBag.ogrid = new SelectList(db.ogretmen, "ogrid", "adi", ogretmendans.ogrid);
            return View(ogretmendans);
        }

        // GET: ogretmendans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogretmendans ogretmendans = db.ogretmendans.Find(id);
            if (ogretmendans == null)
            {
                return HttpNotFound();
            }
            ViewBag.dansid = new SelectList(db.dans, "dansid", "dansadi", ogretmendans.dansid);
            ViewBag.ogrid = new SelectList(db.ogretmen, "ogrid", "adi", ogretmendans.ogrid);
            return View(ogretmendans);
        }

        // POST: ogretmendans/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ogrdesid,ogrid,dansid")] ogretmendans ogretmendans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretmendans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dansid = new SelectList(db.dans, "dansid", "dansadi", ogretmendans.dansid);
            ViewBag.ogrid = new SelectList(db.ogretmen, "ogrid", "adi", ogretmendans.ogrid);
            return View(ogretmendans);
        }

        // GET: ogretmendans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogretmendans ogretmendans = db.ogretmendans.Find(id);
            if (ogretmendans == null)
            {
                return HttpNotFound();
            }
            return View(ogretmendans);
        }

        // POST: ogretmendans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ogretmendans ogretmendans = db.ogretmendans.Find(id);
            db.ogretmendans.Remove(ogretmendans);
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
