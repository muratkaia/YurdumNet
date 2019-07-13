using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using YurdumNet_MasterPage.Models;

namespace YurdumNet_MasterPage.Controllers
{
    public class ListeController : Controller
    {
        YurdumNETEntities db = new YurdumNETEntities();
        // GET: Liste
        [HttpPost]
        public ActionResult AramaSonucu(string SehirAdi, string UniversiteAdi, string yurttipi)
        {
            if (yurttipi!= "Yurt Tipi")
            {
                if (SehirAdi!= "Sehir Seciniz")
                {
                    int id = db.Sehirler.Where(x => x.SehirAdi == SehirAdi).Select(y => y.SehirID).FirstOrDefault();
                   
                    List<Yurtlar> yurtlar = db.Yurtlar.Where(x => x.YurtTipi == yurttipi && x.SehirID == id).ToList();
                    List<Degerlendirmeler> deger = new List<Degerlendirmeler>();
                    foreach (Yurtlar item in yurtlar)
                    {
                        deger.AddRange(db.Degerlendirmeler.Where(x => x.YurtID == item.YurtID).ToList());
                    }
                    ViewBag.Degerlendirme = deger;
                    if (yurtlar.Count == 0)
                    {
                        TempData["Hata"] = "Aranılan kriterlerde yurt bulunmamaktadır.";
                        return RedirectToAction("Index", "Home");
                    }
                    return View(yurtlar);
                }
                else if (UniversiteAdi!= "Universite Seciniz")
                {
                    int id = db.Universiteler.Where(x => x.UniversiteAdi == UniversiteAdi).Select(y => y.SehirID).FirstOrDefault();

                    List<Yurtlar> yurtlar = db.Yurtlar.Where(x => x.YurtTipi == yurttipi && x.SehirID == id).ToList();
                    List<Degerlendirmeler> deger = new List<Degerlendirmeler>();
                    foreach (Yurtlar item in yurtlar)
                    {
                        deger.AddRange(db.Degerlendirmeler.Where(x => x.YurtID == item.YurtID).ToList());
                    }
                    ViewBag.Degerlendirme = deger;
                    if (yurtlar.Count==0)
                    {
                        TempData["Hata"] = "Aranılan kriterlerde yurt bulunmamaktadır.";
                        return RedirectToAction("Index", "Home");
                    }
                    return View(yurtlar);

                }
                else
                {
                    List<Yurtlar> yurtlar = db.Yurtlar.Where(x => x.YurtTipi == yurttipi).ToList();
                    List<Degerlendirmeler> deger = new List<Degerlendirmeler>();
                    foreach (Yurtlar item in yurtlar)
                    {
                        deger.AddRange(db.Degerlendirmeler.Where(x => x.YurtID == item.YurtID).ToList());
                    }
                    ViewBag.Degerlendirme = deger;
                    if (yurtlar.Count == 0)
                    {
                        TempData["Hata"] = "Aranılan kriterlerde yurt bulunmamaktadır.";
                        return RedirectToAction("Index", "Home");
                    }

                    return View(yurtlar);

                }
            }
            else{
                if (SehirAdi != "Sehir Seciniz" && UniversiteAdi != "Universite Seciniz")
                {
                    int Sehirlerid = db.Sehirler.Where(x => x.SehirAdi == SehirAdi).Select(y => y.SehirID).FirstOrDefault();
                    int Universitelerid = db.Universiteler.Where(x => x.UniversiteAdi == UniversiteAdi).Select(y => y.SehirID).FirstOrDefault();
                    if (Sehirlerid == Universitelerid)
                    {
                        List<Yurtlar> yurtlar = db.Yurtlar.Where(x => x.SehirID == Sehirlerid).ToList();
                        List<int> Yurtid = db.Yurtlar.Where(x => x.SehirID == Sehirlerid).Select(y => y.YurtID).ToList();
                        List<Degerlendirmeler> deger = new List<Degerlendirmeler>();
                        foreach (int item in Yurtid)
                        {
                            deger.AddRange(db.Degerlendirmeler.Where(x => x.YurtID == item).ToList());
                        }
                        ViewBag.Degerlendirme = deger;
                        if (yurtlar.Count == 0)
                        {
                            TempData["Hata"] = "Aranılan kriterlerde yurt bulunmamaktadır.";
                            return RedirectToAction("Index", "Home");
                        }
                        return View(yurtlar);
                    }
                    else
                    {
                        TempData["mesaj"] = "Secili Universite Secili Sehirde bulunmamaktadir.";
                       return RedirectToAction("Index","Home");
                    }

                }
               else if (UniversiteAdi != "Universite Seciniz")
                {
                    int id = db.Universiteler.Where(x => x.UniversiteAdi == UniversiteAdi).Select(y => y.SehirID).FirstOrDefault();

                    List<Yurtlar> yurtlar = db.Yurtlar.Where(x => x.SehirID == id).ToList();
                    List<int> Yurtid = db.Yurtlar.Where(x => x.SehirID == id).Select(y => y.YurtID).ToList();
                    List<Degerlendirmeler> deger = new List<Degerlendirmeler>();
                    foreach (int item in Yurtid)
                    {
                        deger.AddRange(db.Degerlendirmeler.Where(x => x.YurtID == item).ToList());
                    }
                    ViewBag.Degerlendirme = deger;
                    if (yurtlar.Count == 0)
                    {
                        TempData["Hata"] = "Aranılan kriterlerde yurt bulunmamaktadır.";
                        return RedirectToAction("Index", "Home");
                    }
                    return View(yurtlar);
                }
                else if (SehirAdi != "Sehir Seciniz")
                {
                    int id = db.Sehirler.Where(x => x.SehirAdi == SehirAdi).Select(y => y.SehirID).FirstOrDefault();
                    List<Yurtlar> yurtlar = db.Yurtlar.Where(x => x.SehirID == id).ToList();
                    List<int> Yurtid = db.Yurtlar.Where(x => x.SehirID == id).Select(y => y.YurtID).ToList();
                    List<Degerlendirmeler> deger = new List<Degerlendirmeler>();
                    foreach (int item in Yurtid)
                    {
                        deger.AddRange(db.Degerlendirmeler.Where(x => x.YurtID == item).ToList());
                    }
                    ViewBag.Degerlendirme = deger;
                    if (yurtlar.Count == 0)
                    {
                        TempData["Hata"] = "Aranılan kriterlerde yurt bulunmamaktadır.";
                        return RedirectToAction("Index", "Home");
                    }
                    return View(yurtlar);

                }
                
                else
                {
                    List<Yurtlar> yurtlar = db.Yurtlar.ToList();
                    List<int> Yurtid = db.Yurtlar.Select(y => y.YurtID).ToList();
                    List<Degerlendirmeler> deger = new List<Degerlendirmeler>();
                    foreach (int item in Yurtid)
                    {
                        deger.AddRange(db.Degerlendirmeler.Where(x => x.YurtID == item).ToList());
                    }
                    ViewBag.Degerlendirme = deger;
                    if (yurtlar.Count == 0)
                    {
                        TempData["Hata"] = "Aranılan kriterlerde yurt bulunmamaktadır.";
                        return RedirectToAction("Index", "Home");
                    }
                    return View(yurtlar);

                }
                //return View();
            } }
        
        public ActionResult Detay(int? id)
        {
            Yurtlar yurt=db.Yurtlar.Where(x => x.YurtID == id).Select(x => x).FirstOrDefault();
            List<YurtOzellikleri> ozellikler = db.Yurtlar.Where(x => x.YurtID == id).Select(x => x.YurtOzellikleri).ToList();
            ViewBag.ozellikler = ozellikler;
            return View(yurt);
        }
        [HttpPost]
        public ActionResult Gonder(string name,string surname,string email,string message,int rating,int yurtid)
        {
            
            
            Degerlendirmeler yorum = new Degerlendirmeler();
            yorum.Adi = name;
            yorum.Mail = email;
            yorum.Tarih = DateTime.Now;
            yorum.YurtID = yurtid;
            yorum.Yorum = message;
            yorum.Rating = rating;
            yorum.Soyadi = surname;
            db.Degerlendirmeler.Add(yorum);
            db.SaveChanges();

          

            return RedirectToAction("Index","Home");
        }
    }
}