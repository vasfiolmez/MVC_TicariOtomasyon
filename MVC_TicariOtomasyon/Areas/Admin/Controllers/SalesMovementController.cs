using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class SalesMovementController : Controller
    {
        TicariOtomasyonContext context = new TicariOtomasyonContext();
        public ActionResult SalesMovementList()
        {
            ViewBag.baslik = "Satış Listesi";
            var values = context.SalesMovements.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateSalesMovement()
        {
            ViewBag.baslik = "Yeni Ürün Satışı";

           List<SelectListItem> valuesProduct= (from x in context.Products.ToList()
                                                select new SelectListItem
                                                {
                                                    Text=x.ProductName.ToString(),
                                                    Value=x.ProductId.ToString(),
                                                }).ToList();

            List<SelectListItem> valuesEmployee = (from x in context.Employees.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name + " " + x.Surname,
                                                       Value = x.EmployeeId.ToString()
                                                   }).ToList();
       

            List<SelectListItem> valuesCustomer= (from x in context.Customers.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text=x.Name + " " + x.Surname,
                                                      Value=x.CustomerId.ToString()

                                                  }).ToList() ;

            ViewBag.valuesProduct = valuesProduct;
            ViewBag.valuesEmployee = valuesEmployee;
            ViewBag.valuesCustomer = valuesCustomer;

            return View();
        }
        [HttpPost]
        public ActionResult CreateSalesMovement(SalesMovement sales)
        {
            ViewBag.baslik = "Yeni Ürün Satışı"; 
            sales.Date=DateTime.Parse( DateTime.Now.ToShortDateString());
            context.SalesMovements.Add(sales);
          
            context.SaveChanges();
            return RedirectToAction("SalesMovementList", "SalesMovement", "Admin");
        }
        //public ActionResult SalesMovementStatusToChangeFalse(int id)
        //{
        //    var value = context.SalesMovements.Find(id);
        //    //value.Status = false;
        //    context.SaveChanges();
        //    return RedirectToAction("SalesMovementList", "SalesMovement", "Admin");
        //}
        //public ActionResult SalesMovementStatusToChangeTrue(int id)
        //{
        //    var value = context.SalesMovements.Find(id);
        //    //value.Status = true;
        //    context.SaveChanges();
        //    return RedirectToAction("SalesMovementList", "SalesMovement", "Admin");
        //}

        [HttpGet]
        public ActionResult UpdateSalesMovement(int id)
        {
            ViewBag.baslik = "Ürün Satışını Güncelleme";

            List<SelectListItem> valuesProduct = (from x in context.Products.ToList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.ProductName.ToString(),
                                                      Value = x.ProductId.ToString(),
                                                  }).ToList();

            List<SelectListItem> valuesEmployee = (from x in context.Employees.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name + " " + x.Surname,
                                                       Value = x.EmployeeId.ToString()
                                                   }).ToList();


            List<SelectListItem> valuesCustomer = (from x in context.Customers.ToList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.Name + " " + x.Surname,
                                                       Value = x.CustomerId.ToString()

                                                   }).ToList();

            ViewBag.valuesProduct = valuesProduct;
            ViewBag.valuesEmployee = valuesEmployee;
            ViewBag.valuesCustomer = valuesCustomer;

            var value = context.SalesMovements.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateSalesMovement(SalesMovement salesMovement)
        {
            ViewBag.baslik = "Ürün Satışını Güncelleme";
            var value = context.SalesMovements.Find(salesMovement.SalesMovementId);
            value.ProductId = salesMovement.ProductId;
            value.CustomerId = salesMovement.CustomerId;
            value.EmployeeId = salesMovement.EmployeeId;
            value.Piece = salesMovement.Piece;
            value.Price = salesMovement.Price;
            value.Amount = salesMovement.Amount;
            context.SaveChanges();
            return RedirectToAction("SalesMovementList", "SalesMovement", "Admin");
        }

        public ActionResult DetailSalesMovement(int id)
        {          
            ViewBag.baslik ="Satış Detayı";
            var values = context.SalesMovements.Where(x => x.SalesMovementId == id).ToList();
            return View(values);
        }
        public ActionResult EmployeeSalesMovementSales(int id)
        {
            var personelAdı = context.SalesMovements.Where(x => x.EmployeeId == id).Select(y => y.Employee.Name + " " + y.Employee.Surname).FirstOrDefault();

            ViewBag.baslik = personelAdı + "  Personeliniz Satış Hareketleri";
            var value = context.SalesMovements.Where(x => x.EmployeeId == id).ToList();
            return View(value);
        }
    }
}