using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DansveSalon.Models;

namespace DansveSalon.Controllers
{
    public class HomeController : Controller
    {
        private Entities db = new Entities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ogrLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ogrLogin(string eposta, string psw)
        {
            if (new login().isLoginSucces(eposta, psw))
            {
                return RedirectToAction("ogrPage", "Home");
            }
            return View();
        }
        public ActionResult ogrtLogin()
        {

            return View();
        }
        [HttpPost]
        public ActionResult ogrtLogin(string eposta, string psw)
        {
            if (new ogtlogin().isLoginSucces(eposta, psw))
            {
                return RedirectToAction("ogrtPage", "Home");
            }
            return View();
        }

        public ActionResult ogrPage()
        {
            var result = db.dans;
            ViewBag.veri = result;
            return View();
        }
        public ActionResult ogrtPage()
        {
            var result = db.ogrenci;
            ViewBag.veri = result;

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}