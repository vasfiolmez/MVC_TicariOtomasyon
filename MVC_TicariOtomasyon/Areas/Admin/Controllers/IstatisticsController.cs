using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class IstatisticsController : Controller
    {
        TicariOtomasyonContext context = new TicariOtomasyonContext();

        public ActionResult IstatisticsList()
        {
            ViewBag.baslik = "İstatistikler";
            ViewBag.musteriSayisi = context.Customers.Count().ToString();
            ViewBag.urunSayisi = context.Products.Count().ToString();
            ViewBag.personelSayisi = context.Employees.Count().ToString();
            ViewBag.kategoriSayisi = context.Categories.Count().ToString();
            ViewBag.stokSayisi = context.Products.Sum(x => x.Stock).ToString();
            ViewBag.markaSayisi = context.Products.Select(x => x.Brand).Count().ToString();
            ViewBag.kritikSeviye = context.Products.Where(x => x.Stock < 50).Select(x => x.ProductId).Count().ToString();
            ViewBag.fiyatiEnYuksekOlanUrun = context.Products.OrderByDescending(x => x.SalePrice).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.fiyatiEnDusukOlanUrun = context.Products.OrderBy(x => x.SalePrice).Select(x => x.ProductName).FirstOrDefault();
            ViewBag.enFazlaUrunluMarka = context.Products.GroupBy(x => x.Brand).OrderByDescending(x => x.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.buzdolabıSayısı = context.Products.Where(x => x.ProductName == "Buzdolabı").Select(x => x.Stock).FirstOrDefault();
            ViewBag.bilgisayarSayısı = context.Products.Where(x => x.Category.Name == "Bilgisayar").Select(x => x.Stock).FirstOrDefault();
            ViewBag.enCokSatanUrun = context.SalesMovements.OrderByDescending(x => x.Piece).Select(x => x.Product.ProductName).FirstOrDefault();
            ViewBag.kasadakiTutar = context.SalesMovements.Sum(x => x.Amount).ToString();
            ViewBag.bugunkuSatis = context.SalesMovements.Where(x => x.Date == DateTime.Today).Select(x => x.Piece).Count().ToString();

            
            if (context.SalesMovements.Where(x => x.Date == DateTime.Today).Sum(x => x.Amount)==null)
            {
                ViewBag.bugunkuKazanc = "0";
            }
            else
            {
                ViewBag.bugunkuKazanc = context.SalesMovements.Where(x => x.Date == DateTime.Today).Sum(x => x.Amount).ToString();
                
            }
            
            return View();
        }
        public ActionResult SimpleTables()
        {
            ViewBag.baslik = "Kolay Tablolar";

            var sehirler = context.Customers.Select(x => x.City).ToList();
            var liste = sehirler.GroupBy(x => x).OrderByDescending(y => y.Count()).Select(s => new SehirModel { Key = s.Key, Count = s.Count() }).ToList();
            ViewBag.list = liste;



            var departmanlar=context.Employees.Select(x => x.Department.DepartmentName).ToList();
            var liste2=departmanlar.GroupBy(x=>x).OrderByDescending(y=>y.Count()).Select(s=>new SehirModel { Key=s.Key,Count = s.Count() }).ToList();
            ViewBag.list2=liste2;


            var musteriList=context.Customers.ToList();
            ViewBag.list3=musteriList;


            var urunList=context.Products.ToList();
            ViewBag.list4=urunList;


            var markalar=context.Products.Select(x=>x.Brand).ToList();
            var liste5=markalar.GroupBy(x=>x).OrderByDescending(y=>y.Count()).Select(s=> new SehirModel { Key=s.Key, Count = s.Count() }).ToList();
            ViewBag.list5=liste5;

            return View();
        }
    }
}
 