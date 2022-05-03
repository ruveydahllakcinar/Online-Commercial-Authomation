using QRCoder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;
using System.Drawing;
using System.Drawing.Imaging;

namespace Online_Commercial_Authomation.Controllers
{
    public class QRController : Controller
    {
        // GET: QR
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string code)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                QRCodeGenerator generatecode = new QRCodeGenerator();
                QRCodeGenerator.QRCode qrcode = generatecode.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);
                using (Bitmap image = qrcode.GetGraphic(10))
                {
                    image.Save(ms, ImageFormat.Png);
                    ViewBag.qrcodeimg = "data:image/png;base64, " + Convert.ToBase64String(ms.ToArray());
                }
            }
            return View();
        }
    }
}