using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class CargoController : Controller
    {
        TicariOtomasyonContext context=new TicariOtomasyonContext();
        public ActionResult Index(string kargoTakipNo)
        {
            ViewBag.baslik = "Kargo Listesi";
            var values= from x in context.CargoDetails select x;
            if (!String.IsNullOrEmpty(kargoTakipNo))
            {
                values = values.Where(x => x.TrackingCode.Contains(kargoTakipNo));
            }

            return View(values.ToList());
        }
        [HttpGet]
        public ActionResult NewCargoAdd()
        {
            ViewBag.baslik = "Kargo Bilgisi Ekle";
            var trackingCode = context.CargoDetails.Select(c => c.TrackingCode).ToString();
            trackingCode = GenerateTrackingCode();
            ViewBag.trackingCode = trackingCode;    
            return View();
        }
        [HttpPost]
        public ActionResult NewCargoAdd(CargoDetail cargo)
        {
            
            context.CargoDetails.Add(cargo);
            context.SaveChanges();
            return RedirectToAction("Index", "Cargo", "Admin");
        }

        public ActionResult CargoDetail(string trackingcode)
        {
            ViewBag.baslik = "Kargo Detay";

            var code =context.CargoTrackings.Where(x=>x.TrackingCode==trackingcode).ToList();
            ViewBag.code = trackingcode;
            return View(code);
        }

        private string GenerateTrackingCode()
        {
            // Veritabanında benzersizliği kontrol edin (önerilir, özellikle kısa kodlar için)
            while (true)
            {
                string trackingCode = GenerateGuidCode(10);
                                                     
                if (!context.CargoDetails.Any(c => c.TrackingCode == trackingCode))
                {
                    return trackingCode;
                }
            }
        }

        private string GenerateGuidCode(int length)
        {
            string guid = Guid.NewGuid().ToString("N"); // "N" formatı, tiresiz ve büyük harfli bir GUID üretir
            return guid.Substring(0, Math.Min(guid.Length, length)); // İstenilen uzunlukta kısalt
        }
    }
}