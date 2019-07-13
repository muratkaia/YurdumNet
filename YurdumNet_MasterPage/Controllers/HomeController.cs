using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurdumNet_MasterPage.Models;

namespace YurdumNet_MasterPage.Controllers
{
    public class HomeController : Controller
    {
        YurdumNETEntities db = new YurdumNETEntities();
        public ActionResult Index()
        {
            ViewBag.Sehirler = db.Sehirler.ToList();
            ViewBag.Universiteler = db.Universiteler.ToList();
            List<Yurtlar> yurt = db.Yurtlar.ToList();
            return View(yurt);
        }
        
       
            public ActionResult Iletisim()
            {
                return View();
            }
        [HttpPost]
        public ActionResult Ilet(string name, string soyad, string telephone, string email, string message)
        {
            Iletisim bizeulas = new Iletisim();
            bizeulas.Ad = name;
            bizeulas.Email = email;
            bizeulas.Mesaj = message;
            bizeulas.Telefon = telephone;
            bizeulas.Soyad = soyad;
            db.Iletisim.Add(bizeulas);
            db.SaveChanges();
            return RedirectToAction("Iletisim");
        }
        public ActionResult Hakkimizda()
        {
            return View();
        }
    } 
}