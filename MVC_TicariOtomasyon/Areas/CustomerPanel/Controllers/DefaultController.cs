using MVC_TicariOtomasyon.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
            return View(values);
        }
        public ActionResult Orders()
        {
            ViewBag.baslik = "Sipariş Geçmişim";

            var mail = (string)Session["CustomerMail"];
            var id=context.Customers.Where(x=>x.Mail==mail.ToString()).Select(y=>y.CustomerId).FirstOrDefault();
            var values=context.SalesMovements.Where(x=>x.CustomerId==id).ToList();
            return View(values);
        }
    }
}