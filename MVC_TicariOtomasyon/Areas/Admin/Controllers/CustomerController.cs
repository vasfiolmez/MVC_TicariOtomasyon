using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class CustomerController : Controller
    {

        TicariOtomasyonContext context = new TicariOtomasyonContext();
        public ActionResult CustomerList()
        {
            ViewBag.baslik = "Müşteri Listesi";
            var values = context.Customers.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCustomer()
        {
            ViewBag.baslik = "Müşteri Oluşturma Sayfası";
            return View();
        }
        [HttpPost]
        public ActionResult CreateCustomer(Customer customer)
        {
            ViewBag.baslik = "Müşteri Oluşturma Sayfası";
            context.Customers.Add(customer);
            context.SaveChanges();
            return RedirectToAction("CustomerList", "Customer", "Admin");
        }
        public ActionResult CustomerChangeToStatusFalse(int id)
        {
            var value = context.Customers.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("CustomerList", "Customer", "Admin");
        }
        public ActionResult CustomerChangeToStatusTrue(int id)
        {
            var value = context.Customers.Find(id);
            value.Status=true;
            context.SaveChanges();
            return RedirectToAction("CustomerList", "Customer", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateCustomer(int id)
        {
            ViewBag.baslik = "Müşteri Güncelleme Sayfası";

            var value = context.Customers.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCustomer(Customer customer)
        {
            if (!ModelState.IsValid) 
            {
            return View(customer);
            }

            ViewBag.baslik = "Müşteri Güncelleme Sayfası";
            var value = context.Customers.Find(customer.CustomerId);
            value.Name = customer.Name;
            value.Surname = customer.Surname;
            value.City = customer.City;
            value.Mail = customer.Mail;
            value.Status = customer.Status;
            context.SaveChanges();
            return RedirectToAction("CustomerList", "Customer", "Admin");
        }
        public ActionResult DetailCustomer(int id)
        {
            var departmanAdı = context.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
            ViewBag.baslik = departmanAdı.Name +" "+ departmanAdı.Surname +"  Satın Aldıkları";
            var values = context.SalesMovements.Where(x => x.CustomerId == id).ToList();
            return View(values);
        }
    }
}