using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        TicariOtomasyonContext context =new TicariOtomasyonContext();
        public ActionResult ProductList(string productName)
        {
            ViewBag.baslik = "Ürün Listesi";

            var products= from x in context.Products select x;
            if (!string.IsNullOrEmpty(productName))
            {
                products = products.Where(x => x.ProductName.Contains(productName));
            }
            return View(products.ToList());
        }
        [HttpGet]
        public ActionResult CreateProduct()
        {
            ViewBag.baslik = "Ürün Oluşturma Sayfası";

            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name.ToString(),
                                               Value = x.CategoryId.ToString(),
                                           }).ToList();

            ViewBag.categoryName = values;

            return View();
        }
        [HttpPost]
        public ActionResult CreateProduct(Product product)
        {
            ViewBag.baslik = "Ürün Oluşturma Sayfası";
            product.Status = true;
            context.Products.Add(product);
            context.SaveChanges();
            return RedirectToAction("ProductList", "Product", "Admin");
        }
        public ActionResult DeleteProduct(int id)
        {
            var value = context.Products.Find(id);
            value.Status = false;
            context.SaveChanges();
            return RedirectToAction("ProductList", "Product", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateProduct(int id)
        {
            ViewBag.baslik = "Ürün Güncelleme Sayfası";

            List<SelectListItem> values = (from x in context.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.Name.ToString(),
                                               Value = x.CategoryId.ToString(),
                                           }).ToList();

            ViewBag.categoryName = values;


            var value = context.Products.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            ViewBag.baslik = "Ürün Güncelleme Sayfası";
            var value = context.Products.Find(product.ProductId);
            value.ProductName = product.ProductName;
            value.Brand = product.Brand;
            value.Stock = product.Stock;
            value.BuyingPrice = product.BuyingPrice;
            value.SalePrice = product.SalePrice;
            value.CategoryId = product.CategoryId;
            value.Image = product.Image;
            value.Status = product.Status;  
            context.SaveChanges();
            return RedirectToAction("ProductList", "Product", "Admin");
        }
    }
}