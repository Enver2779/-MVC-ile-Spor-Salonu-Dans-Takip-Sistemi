using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DansveSalon.Models;

namespace DansveSalon.Models
{
    public class ogtlogin
    {
        private Entities db;
        public ogtlogin()
        {
            db = new Entities();
        }

        public bool isLoginSucces(string eposta, string psw)
        {
            ogretmen resultUser = db.ogretmen.Where(x => x.eposta.Equals(eposta) && x.psw.Equals(psw)).FirstOrDefault();
            System.Diagnostics.Debug.WriteLine(resultUser);
            if (resultUser != null)
            {
                db.Entry(resultUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                HttpContext.Current.Session.Add("UserId", resultUser.ogrid.ToString());
                return true;
            }

            return false;
        }
    }
}