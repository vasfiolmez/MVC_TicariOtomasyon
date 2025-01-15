using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MVC_TicariOtomasyon.Controllers
{
    [AllowAnonymous]
    public class PanelController : Controller
    {
     
        TicariOtomasyonContext _context=new TicariOtomasyonContext();
        // GET: Panel
        public ActionResult PanelLayout()
        {
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult EmployeeLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeLogin(Admin admin)
        {
            var values = _context.Admins.FirstOrDefault(x => x.Username == admin.Username && x.Password == admin.Password);
            if (values!=null)
            {
                FormsAuthentication.SetAuthCookie(values.Username, false);
                Session["Username"] = values.Username.ToString();
                return RedirectToAction("DepartmentList", "Department", new { area = "Admin" });
            }
            else
            {
                return RedirectToAction("EmployeeLogin", "Panel");
            }
            return View();
        }
        [HttpGet]
        public ActionResult CustomerLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CustomerLogin(Customer customer)
        {
            var values = _context.Customers.FirstOrDefault(x => x.Mail == customer.Mail && x.Password == customer.Password);
            if(values != null)
            {
                FormsAuthentication.SetAuthCookie(values.Mail,false);
                Session["CustomerMail"]=values.Mail.ToString();
                return RedirectToAction("Index","Default", new { area = "CustomerPanel" });
            }
            return RedirectToAction("CustomerLogin","Panel");
        }

        [HttpGet]
        public ActionResult NewCustomer()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewCustomer(MVC_TicariOtomasyon.Models.Entities.Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
            return RedirectToAction("CustomerLogin","Panel");
        }
    }
}