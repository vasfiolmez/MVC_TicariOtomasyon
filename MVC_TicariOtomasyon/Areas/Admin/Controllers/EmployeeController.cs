using Microsoft.AspNetCore.Http;
using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class EmployeeController : Controller
    {
        TicariOtomasyonContext context = new TicariOtomasyonContext();
        public ActionResult EmployeeList()
        {
            ViewBag.baslik = "Personel Listesi";
            var values = context.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateEmployee()
        {
            ViewBag.baslik = "Yeni Personel Girişi ";

            List<SelectListItem> values = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName.ToString(),
                                               Value = x.DepartmentId.ToString(),
                                           }).ToList();

            ViewBag.employeeDepartment = values;

            return View();
        }
        [HttpPost]
        public ActionResult CreateEmployee(Employee employee, HttpPostedFileBase resim)
        {
            ViewBag.baslik = "Yeni Personel Girişi";

            if (resim!=null&&resim.ContentLength>0)
            {
                string fileName = Path.GetFileName(resim.FileName);
                string path = Path.Combine(Server.MapPath("~/Image/"), fileName);

                if (System.IO.File.Exists(path))
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(resim.FileName);
                    path= Path.Combine(Server.MapPath("~/Image/"), fileName);
                }

                resim.SaveAs(path);
                employee.Image = "/Image/" + fileName;

                //string dosyaAdi = Path.GetFileName(Request.Files[0].FileName);
                //string uzanti = Path.GetExtension(Request.Files[0].FileName);
                //string yol = "~/Image/" + dosyaAdi + uzanti;
                //Request.Files[0].SaveAs(Server.MapPath(yol));
                //employee.Image = "/Image/" + dosyaAdi + uzanti;
            }

            context.Employees.Add(employee);
            context.SaveChanges();
            return RedirectToAction("EmployeeList", "Employee", "Admin");
        }
        public ActionResult EmployeeStatusToChangeFalse(int id)
        {
            var value = context.Employees.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("EmployeeList", "Employee", "Admin");
        }
        public ActionResult EmployeeStatusToChangeTrue(int id)
        {
            var value = context.Employees.Find(id);
            value.Status = true;
            context.SaveChanges();
            return RedirectToAction("EmployeeList", "Employee", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateEmployee(int id)
        {
            ViewBag.baslik = "Personel Bilgisi Güncelleme";

            List<SelectListItem> values = (from x in context.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName.ToString(),
                                               Value = x.DepartmentId.ToString(),
                                           }).ToList();

            ViewBag.employeeDepartment = values;

            var value = context.Employees.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateEmployee(Employee employee,HttpPostedFileBase resim)
        {

            ViewBag.baslik = "Personel Bilgisi Güncelleme";
            var value = context.Employees.Find(employee.EmployeeId);

            if (value==null)
            {
                return HttpNotFound();
            }
            if (resim !=null && resim.ContentLength>0)
            {
                if (!string.IsNullOrEmpty(value.Image))
                {
                    string eskiResimYolu = Server.MapPath(value.Image);
                    if (System.IO.File.Exists(eskiResimYolu))
                    {
                        System.IO.File.Delete(eskiResimYolu);
                    }
                }
                string fileName = Path.GetFileName(resim.FileName);
                string path = Path.Combine(Server.MapPath("~/Image/"), fileName);

                if (System.IO.File.Exists(path))
                {
                    fileName = Guid.NewGuid().ToString() + Path.GetExtension(resim.FileName);
                    path = Path.Combine(Server.MapPath("~/Image/"), fileName);
                }

                resim.SaveAs(path);
                value.Image = "/Image/" + fileName;
            }


            value.Name = employee.Name;
            value.Surname = employee.Surname;
        
            value.DepartmentId = employee.DepartmentId;
            context.SaveChanges();
            return RedirectToAction("EmployeeList", "Employee", "Admin");
        }

        public ActionResult DetailEmployee(int id)
        {
            var personelAdı = context.Employees.Where(x => x.EmployeeId == id).Select(y => y.Name + " " + y.Surname).FirstOrDefault();
            ViewBag.baslik = "Personel Satış Hareketleri: " + personelAdı;
            var values = context.SalesMovements.Where(x => x.EmployeeId == id).ToList();
            return View(values);
        }

        public ActionResult PageDetailEmployees(int page = 1, int pageSize = 6)
        {
            ViewBag.baslik = "Personel Detayları Listesi";
            var values = context.Employees.OrderBy(x => x.EmployeeId).Skip((page - 1) * pageSize).Take(pageSize).ToList();

            int totalRecords = context.Employees.Count();
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRecords / pageSize);
            ViewBag.CurrentPage = page;
            return View(values);
        }

    }
}