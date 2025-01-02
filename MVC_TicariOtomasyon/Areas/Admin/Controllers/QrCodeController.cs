using QRCoder;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static QRCoder.QRCodeGenerator;
using System.Text.RegularExpressions;

namespace MVC_TicariOtomasyon.Areas.Admin.Controllers
{
    public class QrCodeController : Controller
    {
        public ActionResult GenerateQRCode()
        {
            ViewBag.baslik = "QR Kod";
            return View();
        }
            [HttpPost]
        public ActionResult GenerateQRCode(string qrCodeContent)
        {
            ViewBag.baslik = "QR Kod";
            if (string.IsNullOrEmpty(qrCodeContent))
            {
                ViewBag.QrCodeImage = "";
                // veya  ViewBag.QrCodeImage = "";
                return View();
            }

            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(qrCodeContent, QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            using (MemoryStream ms = new MemoryStream())
            {
                qrCodeImage.Save(ms, ImageFormat.Png);
                byte[] imageBytes = ms.ToArray();
                string base64Image = "data:image/png;base64," + Convert.ToBase64String(imageBytes);

                ViewBag.QrCodeImage = base64Image; 
            }

            string fileName = $"{qrCodeContent}.png";   

            fileName = Regex.Replace(fileName, "[^a-zA-Z0-9_\\.-]", "_");
            ViewBag.QrCodeFileName = fileName;

            return View(); // Aynı View'ı döndür
        }
       
    }
}