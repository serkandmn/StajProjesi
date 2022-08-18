using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using webb.Models;

namespace webb.Controllers
{
    public class HomeController : Controller
    {
        private SqlContext context;
        public HomeController(SqlContext sqlContext)
        {
            context = sqlContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Detay()
        {
            List<kisibilgileri> kisiler = context.bilgis.ToList();
            ViewData["Kisiler"] = kisiler;
            return View(kisiler);
        }

        //[HttpPost("Home/{action}")]
        public ViewResult BilgiFormu(kisibilgileri bilgi)
        {
            if (bilgi != null && bilgi.Ad != null)
            {
                context.bilgis.Add(bilgi);
                context.SaveChanges();
                return View(bilgi);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult update(int Id, kisibilgileri bilgi)
        {
            kisibilgileri kisibilgileri = context.bilgis.Find(Id);
            if (kisibilgileri != null && bilgi != null && bilgi.Ad != null)
            {
                kisibilgileri.Ad = bilgi.Ad;
                kisibilgileri.Soyad = bilgi.Soyad;
                kisibilgileri.TelNo = bilgi.TelNo;
                kisibilgileri.Adres = bilgi.Adres;
                context.bilgis.Update(kisibilgileri);
                context.SaveChanges();
                return View("Detay",context.bilgis.ToList());
            }
            else
            {
                return View(kisibilgileri);
            }

        
        }
        public IActionResult Remove(int Id)
        {
            kisibilgileri kisibilgileri = context.bilgis.Find(Id);
            context.bilgis.Remove(kisibilgileri);
            context.SaveChanges();
            return View("Detay", context.bilgis.ToList());
        }
    }
}
