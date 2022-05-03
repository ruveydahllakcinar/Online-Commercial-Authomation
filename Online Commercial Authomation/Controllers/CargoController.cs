using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;

namespace Online_Commercial_Authomation.Controllers
{
    public class CargoController : Controller
    {
        // GET: Cargo
        Context c = new Context();
        public ActionResult Index(string p)
        {
            var cargoes = from x in c.CargoDetails select x;
            if (!string.IsNullOrEmpty(p))
            { cargoes = cargoes.Where(y => y.TrackingCode.Contains(p)); }
            return View(cargoes.ToList());
        }
        [HttpGet]
        public ActionResult CargoAdd()
        {
            Random rnd = new Random();

            string[] characters = { "A", "B", "C", "D" ,"E","F","G", "H", "I", "J", "K ", "L", "M", "N", "O", "Q", "P", "R", "S", "T", "U", "X", "V", "Y", "Z"};
            int k1, k2, k3;
            k1 = rnd.Next(0, characters.Length);
            k2 = rnd.Next(0, characters.Length);
            k3 = rnd.Next(0, characters.Length);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);
            string cod = s1.ToString() + characters[k1] + s2 + characters[k2] + s3 + characters[k3];
            ViewBag.trackingcode = cod;
            


            return View();
        }
        [HttpPost]
        public ActionResult CargoAdd(CargoDetail cargo)
        {
            c.CargoDetails.Add(cargo);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult CargoTracking(string id)
        {

            var values = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(values);
        }
    }
}