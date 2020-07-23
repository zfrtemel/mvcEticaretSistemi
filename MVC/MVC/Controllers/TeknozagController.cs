using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using System.Net;
using System.Drawing;
using System.IO;
using MVC.App_Classes;

namespace MVC.Controllers
{
    public class TeknozagController : Controller
    {
        
        dbEntities db = new dbEntities();
        // GET: Teknozag
        public ActionResult Hompage()
        {
            ViewBag.slider = db.Tbl_Slider.ToList();
            ViewBag.yeniUrun = db.Tbl_Urunler.
               OrderByDescending(x => x.u_DT).
               Take(4); //order by ile sıralama yaptık tarihe göre where ile de sadece belirli ürünleri aldık
            ViewBag.SatilanUrun = db.Tbl_Urunler.
                OrderByDescending(s=> s.u_SatılanMiktar).
                Take(9);
            ViewBag.Bilgisayar = db.Tbl_Urunler.
                Where(b=>b.u_Kategori_ID == 2).
                Take(4);
            ViewBag.Tablet = db.Tbl_Urunler.
                Where(t => t.u_Kategori_ID == 1002).
              Take(4);
            ViewBag.Telefon = db.Tbl_Urunler.
              Where(p => p.u_Kategori_ID==1).
              Take(4);
           
            return View();
        }
        public ActionResult UrunDetay(String id)
        {
          Tbl_Urunler u= db.Tbl_Urunler.FirstOrDefault(x => x.u_Adi == id);
          
            return View(u);
        }
        public ActionResult Giris()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Giris(string Username,String Password)
        {
            var Kullanici = db.Tbl_Kullanici.FirstOrDefault(x=> x.Kullanici_Adi==Username&& x.Sifre==Password);
            if (Kullanici!=null)
            {
                Session["Kullanici"] = Kullanici;
                return RedirectToAction("Hompage", "Teknozag");
            }
            ViewBag.Hata("Kullanıcı Adı Veya Şifre Yanlış");
            return View();
        }
        [HttpPost]
        public ActionResult KayitOl(Tbl_Kullanici bilgi)
        {
            if (bilgi!= null)
            {
                db.Tbl_Kullanici.Add(bilgi);
                db.SaveChanges();
               
                return View();
            }
            ViewBag.hata("Hesap Oluşturma Başarısız Lütfen Daha Sonra Tekrar Deneyiniz.");
            return View();
        }
        public ActionResult Cikis()
        {
            Session["kullanici"] = null;
            return RedirectToAction("Hompage", "Teknozag");
        }
       
        [HttpGet]
        public ActionResult SepetEkle(int ID)
        {
            var SepetSeS = db.Tbl_Urunler.FirstOrDefault(x => x.u_ID == ID);
            if (SepetSeS != null)
            {
                Session["Sepet"] = SepetSeS;
                return View();
            }
            return View();
        }

    }
}
