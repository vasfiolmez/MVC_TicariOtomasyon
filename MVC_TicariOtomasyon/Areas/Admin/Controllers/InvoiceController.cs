using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class InvoiceController : Controller
    {
        TicariOtomasyonContext context = new TicariOtomasyonContext();
        public ActionResult InvoiceList()
        {
            ViewBag.baslik = "Fatura Listesi";
            var values = context.Invoices.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult CreateInvoice()
        {
            ViewBag.baslik = "Yeni Fatura Girişi";
            return View();
        }
        [HttpPost]
        public ActionResult CreateInvoice(Invoice invoice)
        {
            ViewBag.baslik = "Fatura Oluşturma Sayfası";
            context.Invoices.Add(invoice);
            context.SaveChanges();
            return RedirectToAction("InvoiceList", "Invoice", "Admin");
        }
        public ActionResult DeleteInvoice(int id)
        {
            var value = context.Invoices.Find(id);

            context.SaveChanges();
            return RedirectToAction("InvoiceList", "Invoice", "Admin");
        }

        [HttpGet]
        public ActionResult UpdateInvoice(int id)
        {
            ViewBag.baslik = "Fatura Güncelleme ";

            var value = context.Invoices.Find(id);
            return View(value);
        }

        [HttpPost]
        public ActionResult UpdateInvoice(Invoice invoice)
        {
            ViewBag.baslik = "Fatura Güncelleme";
            var value = context.Invoices.Find(invoice.InvoiceId);
            value.InvoiceSerialNo = invoice.InvoiceSerialNo;
            value.InvoiceSequenceNo = invoice.InvoiceSequenceNo;
            value.TaxOffice = invoice.TaxOffice;
            value.Hour = invoice.Hour;
            value.Date = invoice.Date;
            value.DelivereredBy = invoice.DelivereredBy;
            value.ReceivedBy = invoice.ReceivedBy;
            context.SaveChanges();
            return RedirectToAction("InvoiceList", "Invoice", "Admin");
        }
        public ActionResult DetailInvoice(int id)
        {
            ViewBag.baslik = "Fatura Kalemi";
            var values = context.InvoiceItems.Where(x => x.InvoiceId == id).ToList();           
            return View(values);
        }

        [HttpGet]
        public ActionResult CreateInvoiceItem()
        {
            ViewBag.baslik = "Fatura Kalemi Ekle";
            return View();
        }
        [HttpPost]
        public ActionResult CreateInvoiceItem(InvoiceItem ınvoiceItem)
        {
            ViewBag.baslik = "Fatura Kalemi Ekle";
            context.InvoiceItems.Add(ınvoiceItem);
            context.SaveChanges();
            return RedirectToAction("DetailInvoice", "Invoice", "Admin");
        }

    }
}