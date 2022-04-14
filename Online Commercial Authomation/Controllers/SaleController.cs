using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;

namespace Online_Commercial_Authomation.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.SalesMoves.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult SaleAdd()
        {
            List<SelectListItem> values1 = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductsId.ToString()
                                            }).ToList();
            ViewBag.vl1 = values1;

            List<SelectListItem> values2 = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurname,
                                                Value = x.CurrentId.ToString()
                                            }).ToList();



            List<SelectListItem> values3 = (from x in c.Employees.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                Value = x.EmployeeId.ToString()
                                            }).ToList();


            ViewBag.vl1 = values1;
            ViewBag.vl2 = values2;
            ViewBag.vl3 = values3;
            return View();
        }
        [HttpPost]
        public ActionResult SaleAdd(SaleMove sale)
        {
            sale.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SalesMoves.Add(sale);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SaleFind(int id)
        {
            List<SelectListItem> values1 = (from x in c.Products.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.ProductName,
                                                Value = x.ProductsId.ToString()
                                            }).ToList();
            ViewBag.vl1 = values1;

            List<SelectListItem> values2 = (from x in c.Currents.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.CurrentName + " " + x.CurrentSurname,
                                                Value = x.CurrentId.ToString()
                                            }).ToList();



            List<SelectListItem> values3 = (from x in c.Employees.ToList()
                                            select new SelectListItem
                                            {
                                                Text = x.EmployeeName + " " + x.EmployeeSurname,
                                                Value = x.EmployeeId.ToString()
                                            }).ToList();


            ViewBag.vl1 = values1;
            ViewBag.vl2 = values2;
            ViewBag.vl3 = values3;
            var values = c.SalesMoves.Find(id);
            return View("SaleFind", values);
        }
        public ActionResult SaleUpdate(SaleMove s)
        {
            var value = c.SalesMoves.Find(s.SalesId);
            value.CurrentId = s.CurrentId;
            value.Number = s.Number;
            value.Price = s.Price;
            value.EmployeeId = s.EmployeeId;
            value.Date = s.Date;
            value.TotalAmount = s.TotalAmount;
            value.ProductsId = s.ProductsId;
            c.SaveChanges();
            return RedirectToAction("Index");

        }

        public ActionResult SaleDetail(int id)
        {
            var values = c.SalesMoves.Where(X => X.SalesId == id).ToList();
            return View(values);
        }
    }
}