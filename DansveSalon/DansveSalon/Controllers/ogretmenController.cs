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
    public class ogretmenController : Controller
    {
        private Entities db = new Entities();

        // GET: ogretmen
        public ActionResult Index()
        {
            var ogretmen = db.ogretmen.Include(o => o.salon);
            return View(ogretmen.ToList());
        }

        // GET: ogretmen/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogretmen ogretmen = db.ogretmen.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // GET: ogretmen/Create
        public ActionResult Create()
        {
            ViewBag.bolumid = new SelectList(db.salon, "bolumid", "bolumadi");
            return View();
        }

        // POST: ogretmen/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ogrid,adi,soyadi,memleket,eposta,psw,bolumid,maası")] ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                db.ogretmen.Add(ogretmen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.bolumid = new SelectList(db.salon, "bolumid", "bolumadi", ogretmen.bolumid);
            return View(ogretmen);
        }

        // GET: ogretmen/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogretmen ogretmen = db.ogretmen.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            ViewBag.bolumid = new SelectList(db.salon, "bolumid", "bolumadi", ogretmen.bolumid);
            return View(ogretmen);
        }

        // POST: ogretmen/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ogrid,adi,soyadi,memleket,eposta,psw,bolumid,maası")] ogretmen ogretmen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ogretmen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.bolumid = new SelectList(db.salon, "bolumid", "bolumadi", ogretmen.bolumid);
            return View(ogretmen);
        }

        // GET: ogretmen/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ogretmen ogretmen = db.ogretmen.Find(id);
            if (ogretmen == null)
            {
                return HttpNotFound();
            }
            return View(ogretmen);
        }

        // POST: ogretmen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ogretmen ogretmen = db.ogretmen.Find(id);
            db.ogretmen.Remove(ogretmen);
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
