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
    public class HomeController : Controller
    {
      
        // GET: Home
        dbEntities db = new dbEntities();
        public ActionResult Index()
        {
        
            return View();
        }
        public ActionResult Urunler()
        {

            return View(db.Tbl_Urunler.ToList());
        }
       
        public ActionResult UrunEkle()
        { 
            ViewBag.kategoriler = db.Tbl_Kategori.ToList();
            ViewBag.altKategoriler = db.Tbl_AltKategori.ToList();
            ViewBag.renkler = db.Tbl_Renkler.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult UrunEkle(Tbl_Urunler urn, HttpPostedFileBase fileupload)
        {
            if (fileupload != null)
            {
                Image img = Image.FromStream(fileupload.InputStream);

                Bitmap bmp = new Bitmap(img, Settings.SliderResimBoyut);

                string yol = "/Content/UrunResim/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);
                bmp.Save(Server.MapPath(yol));
                urn.u_OneCikar = yol;

                db.Tbl_Urunler.Add(urn);
                db.SaveChanges();
            }
            return RedirectToAction("Urunler");
        }
        public ActionResult UrunSil(int id)
        {
            var sil= db.Tbl_Urunler.FirstOrDefault(x=> x.u_ID==id);
            db.Tbl_Urunler.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("Urunler");
        }
        public ActionResult UrunGuncelle(int? id)
        { 

            ViewBag.kategoriler = db.Tbl_Kategori.ToList();
            ViewBag.altKategoriler = db.Tbl_AltKategori.ToList();
            ViewBag.renkler = db.Tbl_Renkler.ToList();
            Tbl_Urunler kayit = db.Tbl_Urunler.Where(k => k.u_ID == id).SingleOrDefault();
            Tbl_Urunler model = new Tbl_Urunler()
            { 
                u_ID = Convert.ToInt32(id),
                u_Adi = kayit.u_Adi,
                u_Kategori_ID = kayit.u_Kategori_ID,
                u_AltKategori_ID = kayit.u_AltKategori_ID,
                u_Renk_ID = kayit.u_Renk_ID,
                u_Fiyat = kayit.u_Fiyat,
                u_Aciklama = kayit.u_Aciklama,
                u_Stok = kayit.u_Stok,
                u_DT = kayit.u_DT,
                u_indirim_Fiyat = kayit.u_indirim_Fiyat
            };

            using (var db998 = new dbEntities())
            {
                var altKategori = db.Tbl_AltKategori.ToList();
                if (altKategori != null && altKategori.Count > 0)
                {
                    foreach (var item1 in altKategori)
                    {
                        ViewBag.kategoriview += WebUtility.HtmlDecode(String.Format("<option value='{0}'>{1}</option>", item1.aKategori_ID, item1.AltKategori_Adi));
                    }
                }
            }
            

            ViewBag.altKategoriler = db.Tbl_AltKategori.ToList();
            return View(model);
        }
        [HttpPost]
        public ActionResult UrunGuncelle(Tbl_Urunler m)
        {
            ViewBag.altKategoriler = db.Tbl_AltKategori.ToList();
            var kayitlar = db.Tbl_Urunler.Find(m.u_ID);
            if (kayitlar==null)
            {
                return RedirectToAction("UrunEkle");
            }
            else
            {
                kayitlar.u_Adi = m.u_Adi;
                kayitlar.u_Kategori_ID = m.u_Kategori_ID;
                kayitlar.u_AltKategori_ID = m.u_AltKategori_ID;
                kayitlar.u_Renk_ID = m.u_Renk_ID;
                kayitlar.u_Fiyat = m.u_Fiyat;
                kayitlar.u_Aciklama = m.u_Aciklama;
                kayitlar.u_Stok = m.u_Stok;
                kayitlar.u_DT = m.u_DT;
                kayitlar.u_indirim_Fiyat = m.u_indirim_Fiyat;
                db.SaveChanges();
                return RedirectToAction("Urunler");
            }
            
        }
        public ActionResult UstKategori()
        {

            return View(db.Tbl_Kategori.ToList());
        }
        [HttpPost]
        public ActionResult UstKategori(Tbl_Kategori Kategori)
        {
            db.Tbl_Kategori.Add(Kategori);
            db.SaveChanges();
            return RedirectToAction("UstKategori");
        }
        public ActionResult UstKategoriSil(int id)
        {
            var sil = db.Tbl_Kategori.FirstOrDefault(x => x.Kategori_ID == id);
            db.Tbl_Kategori.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("UstKategori");
        }
        public ActionResult AltKategori()
        {
            ViewBag.bagliKategori = db.Tbl_Kategori.ToList();
            return View(db.Tbl_AltKategori.ToList());
        }
        [HttpPost]
        public ActionResult AltKategori(Tbl_AltKategori aKategori)
        {
            db.Tbl_AltKategori.Add(aKategori);
            db.SaveChanges();
            return RedirectToAction("AltKategori");
        }
        public ActionResult AltKategoriSil(int id)
        {
            var sil = db.Tbl_AltKategori.FirstOrDefault(x => x.aKategori_ID == id);
            db.Tbl_AltKategori.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("AltKategori");
        }
        public ActionResult SliderListesi()
        {
            ViewBag.sliders = db.Tbl_Slider.ToList();
            return View();
        }
        public ActionResult SliderResimEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult SliderResimEkle( Tbl_Slider rsm,HttpPostedFileBase fileupload)
        {
            if (fileupload != null)
            {
                Image img = Image.FromStream(fileupload.InputStream);

                Bitmap bmp = new Bitmap(img, Settings.SliderResimBoyut);

                string yol = "/Content/SliderResim/" + Guid.NewGuid() + Path.GetExtension(fileupload.FileName);
                bmp.Save(Server.MapPath(yol));
                rsm.SliderURL = yol;
                
                db.Tbl_Slider.Add(rsm);
             db.SaveChanges();
            }
            return RedirectToAction("SliderListesi");
        }
        public ActionResult SliderSil(int id)
        {
            var sil = db.Tbl_Slider.FirstOrDefault(x => x.s_ID == id);
            db.Tbl_Slider.Remove(sil);
            db.SaveChanges();
            return RedirectToAction("SliderListesi");
        }


    }

}