using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Online_Commercial_Authomation.Models.Classes;

namespace Online_Commercial_Authomation.Controllers
{
    public class CurrentPanelController : Controller
    {
        // GET: CurrentPanel
       
        Context c = new Context();
        [Authorize]
        public ActionResult Index()
        {
            var mail = (string)Session["CurrentMail"];
            var values = c.Messages.Where(x => x.Buyer == mail).ToList();
            ViewBag.m = mail;
            var mailid = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentId).FirstOrDefault();
            ViewBag.mid = mailid;
            /*Total Sale*/
            var totalsale = c.SalesMoves.Where(x => x.CurrentId == mailid).Count();
            ViewBag.totalsale = totalsale;
            /*Total Amount*/
            var totalamount = c.SalesMoves.Where(x => x.CurrentId == mailid).Sum(y => y.TotalAmount);
            ViewBag.totalamount = totalamount;
            /*Number Of Total*/
            var numberoftotal = c.SalesMoves.Where(x => x.CurrentId == mailid).Sum(y => y.Number);
            ViewBag.numberoftotal = numberoftotal;
            /*Name and Surname*/
            var namesurname = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentName + " " + y.CurrentSurname).FirstOrDefault();
            ViewBag.namesurname = namesurname;
            return View(values);
        }
        [Authorize]
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = c.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var values = c.SalesMoves.Where(x => x.CurrentId == id).ToList();
            return View(values);
        }
        [Authorize]
        public ActionResult IncomingMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = c.Messages.Where(x=>x.Buyer==mail).OrderByDescending(x=>x.MessageId).ToList();
            var inboxnumber = c.Messages.Count(x => x.Buyer == mail).ToString();
            ViewBag.inbox = inboxnumber;
            var sentnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sent = sentnumber;
            return View(messages);
        }
        [Authorize]
        public ActionResult SentMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = c.Messages.Where(x => x.Sender == mail).OrderByDescending(x => x.MessageId).ToList();
            var inboxnumber = c.Messages.Count(x => x.Buyer == mail).ToString();
            ViewBag.inbox = inboxnumber;
            var sentnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sent = sentnumber;
            return View(messages);
        }
        [Authorize]
        public ActionResult MessageDetail(int id)
        {
            var values = c.Messages.Where(x => x.MessageId == id).ToList();
            var mail = (string)Session["CurrentMail"];
            var messages = c.Messages.Where(x => x.Sender == mail).ToList();
            var inboxnumber = c.Messages.Count(x => x.Buyer == mail).ToString();
            ViewBag.inbox = inboxnumber;
            var sentnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sent = sentnumber;
            return View(messages);
        }
        [Authorize]
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = c.Messages.Where(x => x.Sender == mail).OrderByDescending(x => x.MessageId).ToList();
            var inboxnumber = c.Messages.Count(x => x.Buyer == mail).ToString();
            ViewBag.inbox = inboxnumber;
            var sentnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sent = sentnumber;
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            var mail = (string)Session["CurrentMail"];
            message.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            message.Sender = mail;
            c.Messages.Add(message);
            c.SaveChanges();
            return View();
        }
        [Authorize]
        public ActionResult CargoTracking(string p)
        {
            var cargoes = from x in c.CargoDetails select x;
            cargoes = cargoes.Where(y => y.TrackingCode.Contains(p)); 
            return View(cargoes.ToList());
        }
        [Authorize]
        public ActionResult CurrentCargo(string id)
        {
            var values = c.CargoTrackings.Where(x => x.TrackingCode == id).ToList();
            return View(values);
        }
        [Authorize]
        public ActionResult SignOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
        public PartialViewResult PartialSettings() /*Settings page in profile*/
        {
            var mail = (string)Session["CurrentMail"];
            var id = c.Currents.Where(x => x.CurrentMail == mail).Select(y => y.CurrentId).FirstOrDefault();
            var CurrentsFind = c.Currents.Find(id);
            return PartialView("PartialSettings", CurrentsFind);

        }

        public PartialViewResult PartialNotices()
        {
            var values = c.Messages.Where(x => x.Sender == "admin").ToList();
            return PartialView(values);
        }
        public ActionResult CurrentInformationUpdate(Current cr)
        {
            var current = c.Currents.Find(cr.CurrentId);
            current.CurrentName = cr.CurrentName;
            current.CurrentSurname = cr.CurrentSurname;
            current.CurrentPassword = cr.CurrentPassword;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}