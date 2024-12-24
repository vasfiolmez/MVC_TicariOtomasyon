using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        TicariOtomasyonContext context = new TicariOtomasyonContext();
        public ActionResult CategoryList(int page=1)
        {
            ViewBag.baslik = "Kategori Listesi";
            var values = context.Categories.ToList().ToPagedList(page, 4);
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateCategory()
        {
            ViewBag.baslik = "Kategori Oluşturma Sayfası";
            return View();
        }
        [HttpPost]
        public ActionResult CreateCategory(Category category)
        {
            ViewBag.baslik = "Kategori Oluşturma Sayfası";                     
            context.Categories.Add(category);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }
        public ActionResult DeleteCategory(int id)
        {
            var value = context.Categories.Find(id);
            context.Categories.Remove(value);
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateCategory(int id)
        {
            ViewBag.baslik = "Kategori Güncelleme Sayfası";

            var value = context.Categories.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            ViewBag.baslik = "Kategori Güncelleme Sayfası";
            var value = context.Categories.Find(category.CategoryId);
            value.Name = category.Name;
            context.SaveChanges();
            return RedirectToAction("CategoryList", "Category", "Admin");
        }
    }
}