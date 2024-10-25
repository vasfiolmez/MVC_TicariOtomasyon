using MVC_TicariOtomasyon.Context;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class ToDoListController : Controller
    {
        TicariOtomasyonContext context=new TicariOtomasyonContext();
        public ActionResult Index()
        {
            var musteriSayisi=context.Customers.Count().ToString();
            ViewBag.mSayi=musteriSayisi;

            var urunSayisi=context.Products.Count().ToString();
            ViewBag.urunSayi=urunSayisi;

            var kategoriSayisi=context.Categories.Count().ToString();
            ViewBag.kSayisi=kategoriSayisi;

            var sehirSayisi=context.Customers.Select(x => x.City).Distinct().Count().ToString();
            ViewBag.sehirSayi=sehirSayisi;
      
            return View();
        }
        public PartialViewResult Todo()
        {
            var todo = context.ToDoLists.ToList();
            return PartialView(todo);
        }
    }
}