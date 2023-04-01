using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_ProjeKamp.Controllers
{
    public class IstatistikController : Controller
    {
        Context c = new Context();
        public ActionResult Index()
        {
            ViewBag.KategoriToplam = c.Categories.Count();
            //Başlık tablosunda "yazılım" kategorisine ait başlık sayısı
            var result1 = c.Headings
                .Join(c.Categories, baslik => baslik.CategoryID, kategori => kategori.CategoryID, (baslik, kategori) => new { Heading = baslik, Category = kategori })
                .Where(bk => bk.Category.CategoryName == "Yazılım")
                .Count();
            ViewBag.YazilimBaslikSayisi = result1;
            //Yazar adında 'a' harfi geçen yazar sayısı
            ViewBag.YazarSayisi = c.Writers.Where(x => x.WriterName.Contains("a")).Count();
            //En fazla başlığa sahip kategori adı
            var result2  = c.Headings
                .Join(c.Categories, h => h.CategoryID, ca => ca.CategoryID, (h, ca) => new { Heading = h, Category = ca })
                .GroupBy(x => new { x.Heading.CategoryID, x.Category.CategoryName })
                .Select(x => new { CategoryName = x.Key.CategoryName, Count = x.Count() })
                .OrderByDescending(x => x.Count)
                .FirstOrDefault();
            ViewBag.MaxBaslikKategori = result2.CategoryName;
            //Kategori tablosunda durumu true olan kategoriler ile false olan kategoriler arasındaki sayısal fark
            ViewBag.Fark = c.Categories.Where(x => x.CategoryStatus == true).Count() - c.Categories.Where(x => x.CategoryStatus == false).Count();
            return View();
        }
        
    }
}

