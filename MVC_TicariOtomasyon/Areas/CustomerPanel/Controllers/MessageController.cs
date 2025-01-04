using MVC_TicariOtomasyon.Context;
using MVC_TicariOtomasyon.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_TicariOtomasyon.Areas.CustomerPanel.Controllers
{
    public class MessageController : Controller
    {
        TicariOtomasyonContext _context = new TicariOtomasyonContext();
        public ActionResult MessageList()
        {

            ViewBag.baslik = "Mesajlar";
            var mail = (string)Session["CustomerMail"];
            var values = _context.Messages.Where(x => x.Receiver == mail).ToList();
            return View(values);
        }
        public ActionResult SendMessageBox()
        {
            ViewBag.baslik = "Gönderilen Mesajlar";
            var mail = (string)Session["CustomerMail"];
            var values = _context.Messages.Where(x => x.Sender == mail).ToList();
            return View(values);
        }
        public ActionResult MessageDetail(int id)
        {
            ViewBag.baslik = "Mesaj Detayları";
            var mail = (string)Session["CustomerMail"];
            var values = _context.Messages.Where(x => x.MessageId == id).FirstOrDefault();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            ViewBag.baslik = "Yeni Mesaj Oluştur";
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = (string)Session["CustomerMail"];
            message.SendDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Sender = mail;
            _context.Messages.Add(message);
            _context.SaveChanges();
            return RedirectToAction("SendMessageBox", "Message", new { area = "CustomerPanel" });
        }
        public PartialViewResult MessageColmd3()
        {
            var mail = (string)Session["CustomerMail"];
            var inboxCount = _context.Messages.Count(x => x.Receiver == mail);
            var sendboxCount = _context.Messages.Count(x => x.Sender == mail);
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendboxCount = sendboxCount;
            return PartialView();
        }
    }
}