using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;

namespace Online_Commercial_Authomation.Controllers
{
    public class InvoiceController : Controller
    {
        // GET: Invoice
        Context c = new Context();
        public ActionResult Index()
        {
            var list = c.Invoices.ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult InvoiceAdd()
        {
            //c.Categories.Add();
            return View();
        }
        [HttpPost]
        public ActionResult InvoiceAdd(Invoice invoice)
        {
            c.Invoices.Add(invoice);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceFind(int id)
        {

            var invoice = c.Invoices.Find(id);
            return View("InvoiceFind", invoice);
        }
        public ActionResult InvoiceUpdate(Invoice invoice)
        {
            var ct = c.Invoices.Find(invoice.InvoicesId);
            ct.SerialNumber = invoice.SerialNumber;
            ct.RowNumber = invoice.RowNumber;
            ct.TaxAuthority = invoice.TaxAuthority;
            ct.Date = invoice.Date;
            ct.Time = invoice.Time;
            ct.Submitter = invoice.Submitter;
            ct.Recipient = invoice.Recipient;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoiceDetail(int id)
        {
            var values = c.InvoiceItems.Where(x => x.InvoicesId == id).ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult NewItem()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewItem(InvoiceItem i)
        {
            c.InvoiceItems.Add(i);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Dinamic()
        {
            DinamicInvoice di = new DinamicInvoice();
            di.Invoices = c.Invoices.ToList();
            di.InvoiceItems = c.InvoiceItems.ToList();
            return View(di);

        }

        public ActionResult SaveInvoice(string SerialNumber, string RowNumber, DateTime Date, string TaxAuthority, string Time, string Submitter, string Recipient, string Total, InvoiceItem[] items)
        {
            Invoice i = new Invoice();
            i.SerialNumber = SerialNumber;
            i.RowNumber = RowNumber;
            i.Date = Date;
            i.TaxAuthority = TaxAuthority;
            i.Time = Time;
            i.Submitter = Submitter;
            i.Recipient = Recipient;
            i.Total = decimal.Parse(Total);
         
            foreach (var x in items)
            {
                InvoiceItem it = new InvoiceItem();
                it.Explanation = x.Explanation;
                it.UnitPrice = x.UnitPrice;
                it.InvoicesId = x.InvoicesId;
                it.Quantity = x.Quantity;
                it.Amount = x.Amount;
                c.InvoiceItems.Add(it);
            }
            c.Invoices.Add(i);
            c.SaveChanges();
            return Json("Transaction Successful", JsonRequestBehavior.AllowGet);
        }
    }
}