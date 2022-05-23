using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
            var values = c.Currents.FirstOrDefault(x => x.CurrentMail == mail);
            ViewBag.m = mail;
            return View(values);
        }
        public ActionResult MyOrders()
        {
            var mail = (string)Session["CurrentMail"];
            var id = c.Currents.Where(x => x.CurrentMail == mail.ToString()).Select(y => y.CurrentId).FirstOrDefault();
            var values = c.SalesMoves.Where(x => x.CurrentId == id).ToList();
            return View(values);
        }
        public ActionResult IncomingMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = c.Messages.Where(x=>x.Buyer==mail).ToList();
            var inboxnumber = c.Messages.Count(x => x.Buyer == mail).ToString();
            ViewBag.inbox = inboxnumber;
            var sentnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sent = sentnumber;
            return View(messages);
        }
        public ActionResult SentMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = c.Messages.Where(x => x.Sender == mail).ToList();
            var inboxnumber = c.Messages.Count(x => x.Buyer == mail).ToString();
            ViewBag.inbox = inboxnumber;
            var sentnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sent = sentnumber;
            return View(messages);
        }
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
        [HttpGet]
        public ActionResult NewMessage()
        {
            var mail = (string)Session["CurrentMail"];
            var messages = c.Messages.Where(x => x.Sender == mail).ToList();
            var inboxnumber = c.Messages.Count(x => x.Buyer == mail).ToString();
            ViewBag.inbox = inboxnumber;
            var sentnumber = c.Messages.Count(x => x.Sender == mail).ToString();
            ViewBag.sent = sentnumber;
            return View(messages);
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
    }
}