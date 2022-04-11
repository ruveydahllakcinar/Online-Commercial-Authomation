using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;
namespace Online_Commercial_Authomation.Controllers
{
    public class CurrentController : Controller
    {
        // GET: Current
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Currents.Where(x => x.Situation == true).ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult CurrentAdd()
        {

            return View();
        }
        [HttpPost]
        public ActionResult CurrentAdd(Current current)
        {
            current.Situation = true;
            c.Currents.Add(current);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CurrentDelete(int id)
        {
            var cr = c.Currents.Find(id);
            cr.Situation = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CurrentFind(int id)
        {
            var current = c.Currents.Find(id);
            return View("CurrentFind", current);
        }

        public ActionResult CurrentUpdate(Current p)
        {
            if (!ModelState.IsValid)
            {
                return View("CurrentFind");
            }
            var cur = c.Currents.Find(p.CurrentId);
            cur.CurrentName = p.CurrentName;
            cur.CurrentSurname = p.CurrentSurname;
            cur.CurrentCity = p.CurrentCity;
            cur.CurrentMail = p.CurrentMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CurrentSale(int id)
        {
            var values = c.SalesMoves.Where(x => x.CurrentId == id).ToList();
            var cr = c.Currents.Where(x => x.CurrentId == id).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.currents = cr;
            return View(values);
        }
    }
}