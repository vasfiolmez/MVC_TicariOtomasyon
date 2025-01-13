using MVC_TicariOtomasyon.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_TicariOtomasyon.Areas.CustomerPanel.Controllers
{
    public class DefaultController : Controller
    {
        TicariOtomasyonContext context = new TicariOtomasyonContext();
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.baslik = "Müşteri Bİlgileri";

            var mail = (string)Session["CustomerMail"];
            var values = context.Customers.FirstOrDefault(x => x.Mail == mail);
            ViewBag.mail = mail;

            var customerİd = context.Customers.Where(x => x.Mail == mail).Select(x => x.CustomerId).FirstOrDefault();
            var toplamSatıs=context.SalesMovements.Where(x=>x.CustomerId==customerİd).Count();
            ViewBag.toplamsatis = toplamSatıs;

            var toplamTutar=context.SalesMovements.Where(x=>x.CustomerId==customerİd).Sum(x=>x.Amount);
            ViewBag.toplamTutar=toplamTutar;

            var toplamUrunSayisi = context.SalesMovements.Where(x => x.CustomerId == customerİd).Sum(y => y.Piece);
            ViewBag.toplamUrunSayisi=toplamUrunSayisi;


            return View(values);
        }
        public ActionResult Orders()
        {
            ViewBag.baslik = "Sipariş Geçmişim";

            var mail = (string)Session["CustomerMail"];
            var id = context.Customers.Where(x => x.Mail == mail.ToString()).Select(y => y.CustomerId).FirstOrDefault();
            var values = context.SalesMovements.Where(x => x.CustomerId == id).ToList();
            return View(values);
        }
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Panel", new { area = "" });
        }
    }
}