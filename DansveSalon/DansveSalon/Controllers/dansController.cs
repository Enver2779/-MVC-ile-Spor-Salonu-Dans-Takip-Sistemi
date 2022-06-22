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
    public class dansController : Controller
    {
        private Entities db = new Entities();

        // GET: dans
        public ActionResult Index()
        {
            return View(db.dans.ToList());
        }

        // GET: dans/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dans dans = db.dans.Find(id);
            if (dans == null)
            {
                return HttpNotFound();
            }
            return View(dans);
        }

        // GET: dans/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: dans/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "dansid,dansadi,dansmemleket,dansfiyat,danssure,danskodu")] dans dans)
        {
            if (ModelState.IsValid)
            {
                db.dans.Add(dans);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dans);
        }

        // GET: dans/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dans dans = db.dans.Find(id);
            if (dans == null)
            {
                return HttpNotFound();
            }
            return View(dans);
        }

        // POST: dans/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "dansid,dansadi,dansmemleket,dansfiyat,danssure,danskodu")] dans dans)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dans).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dans);
        }

        // GET: dans/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            dans dans = db.dans.Find(id);
            if (dans == null)
            {
                return HttpNotFound();
            }
            return View(dans);
        }

        // POST: dans/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            dans dans = db.dans.Find(id);
            db.dans.Remove(dans);
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
