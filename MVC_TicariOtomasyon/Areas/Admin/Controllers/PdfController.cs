using MVC_TicariOtomasyon.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class PdfController : Controller
    {
        TicariOtomasyonContext contex=new TicariOtomasyonContext();
        public ActionResult ProductList()
        {
            var values= contex.Products.ToList();
            return View(values);
        }
    }
}