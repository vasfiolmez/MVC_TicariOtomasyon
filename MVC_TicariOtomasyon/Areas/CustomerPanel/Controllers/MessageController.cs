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
        TicariOtomasyonContext _context=new TicariOtomasyonContext();
        public ActionResult MessageList()
        {

            ViewBag.baslik = "Mesajlar";
            var mail = (string)Session["CustomerMail"];
            var values = _context.Messages.Where(x=>x.Receiver==mail).ToList();
            var inboxCount=_context.Messages.Count(x=>x.Receiver==mail);
            var sendboxCount = _context.Messages.Count(x => x.Sender == mail);
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendboxCount = sendboxCount;
            return View(values);
        }
        public ActionResult SendMessageBox()
        {
            var mail = (string)Session["CustomerMail"];
            var values = _context.Messages.Where(x => x.Sender == mail).ToList();
            var inboxCount = _context.Messages.Count(x => x.Receiver == mail);
            var sendboxCount = _context.Messages.Count(x => x.Sender == mail);
            ViewBag.inboxCount = inboxCount;
            ViewBag.sendboxCount = sendboxCount;
            return View(values);
        }
        [HttpGet]
        public ActionResult NewMessage() 
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message) 
        { 
        return View("Error");
        }
    }
}