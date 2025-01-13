using MVC_TicariOtomasyon.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.CustomerPanel.Controllers
{
    public class CargoController : Controller
    {
        TicariOtomasyonContext context = new TicariOtomasyonContext();
        public ActionResult Index(string kargoTakipNo)
        {
            ViewBag.baslik = "Kargo Listesi";
            var values = from x in context.CargoDetails select x;
            values = values.Where(x => x.TrackingCode.Contains(kargoTakipNo));

            return View(values.ToList());
        }
        public ActionResult CargoDetail(string trackingcode)
        {
            ViewBag.baslik = "Kargo Detay";

            var code = context.CargoTrackings.Where(x => x.TrackingCode == trackingcode).ToList();
            ViewBag.code = trackingcode;
            return View(code);
        }
    }
}