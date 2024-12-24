using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        TicariOtomasyonContext _context=new TicariOtomasyonContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Panel()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EmployeeLogin()
        {
        return View();
        }
        [HttpPost]
        public ActionResult EmployeeLogin(Employee employee)
        {
            return View();
        }
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(MVC_TicariOtomasyon.Models.Entities.Customer customer)
        {
            return View();
        }

        [HttpGet]
        public ActionResult CustomerSave()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerSave(MVC_TicariOtomasyon.Models.Entities.Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerLogin");
        }
    }
}