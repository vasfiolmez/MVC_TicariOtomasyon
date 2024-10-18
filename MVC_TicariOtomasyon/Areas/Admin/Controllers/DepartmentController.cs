using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class DepartmentController : Controller
    {
        TicariOtomasyonContext context = new TicariOtomasyonContext();
        public ActionResult DepartmentList()
        {
            ViewBag.baslik = "Departman Listesi";
            var values = context.Departments.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateDepartment()
        {
            ViewBag.baslik = "Departman Oluşturma Sayfası";
            return View();
        }
        [HttpPost]
        public ActionResult CreateDepartment(Department department)
        {
            ViewBag.baslik = "Departman Oluşturma Sayfası";
            context.Departments.Add(department);
            context.SaveChanges();
            return RedirectToAction("DepartmentList", "Department", "Admin");
        }
        public ActionResult DepartmentStatusToChangeFalse(int id)
        {
            var value = context.Departments.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("DepartmentList", "Department", "Admin");
        }
        public ActionResult DepartmentStatusToChangeTrue(int id)
        {
            var value = context.Departments.Find(id);
            value.Status=true;
            context.SaveChanges();
            return RedirectToAction("DepartmentList", "Department", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateDepartment(int id)
        {
            ViewBag.baslik = "Departman Güncelleme Sayfası";

            var value = context.Departments.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateDepartment(Department department)
        {
            ViewBag.baslik = "Departman Güncelleme Sayfası";
            var value = context.Departments.Find(department.DepartmentId);
            value.DepartmentName = department.DepartmentName;
            context.SaveChanges();
            return RedirectToAction("DepartmentList", "Department", "Admin");
        }

        public ActionResult DetailDepartment(int id)
        {
            var departmanAdı = context.Departments.Where(x => x.DepartmentId == id).Select(y=>y.DepartmentName).FirstOrDefault();
            ViewBag.baslik = departmanAdı + "  Departmanında Çalışanların Listesi";
            var values = context.Employees.Where(x => x.DepartmentId == id).ToList();
            return View(values);
        }
        public ActionResult EmployeeDepartmentSales(int id)
        {
            var personelAdı = context.SalesMovements.Where(x => x.EmployeeId == id).Select(y => y.Employee.Name + " " +y.Employee.Surname).FirstOrDefault();

            ViewBag.baslik = personelAdı + "  Personeliniz Satış Hareketleri";
            var value=context.SalesMovements.Where(x=>x.EmployeeId==id).ToList();
            return View(value);
        }
    }
}