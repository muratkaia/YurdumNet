using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using YurdumNet_MasterPage.Models;

namespace YurtEkleme.Controllers
{
    public class YurtController : Controller
    {
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(YurtEkle yurtModel)
        {
            string dosyaAdi = Path.GetFileNameWithoutExtension(yurtModel.FotoDosyasi.FileName);
            string uzanti = Path.GetExtension(yurtModel.FotoDosyasi.FileName);
            dosyaAdi += DateTime.Now.ToString("yyyyMMddhhmmss") + uzanti;
            yurtModel.FotoYolu = "~/Content/images/YeniYurt/" + dosyaAdi;
            dosyaAdi = Path.Combine(Server.MapPath("~/Content/images/YeniYurt/"), dosyaAdi);
            yurtModel.FotoDosyasi.SaveAs(dosyaAdi);
            using (YurdumNETEntities db = new YurdumNETEntities())
            {
                db.YurtEkle.Add(yurtModel);
                db.SaveChanges();
            }
            ModelState.Clear();

            return RedirectToAction("Index","Home");
        }
    }
}