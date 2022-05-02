using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;

namespace Online_Commercial_Authomation.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context c = new Context();
        public ActionResult Index()
        {
            var values1 = c.Currents.Count().ToString();
            ViewBag.v1 = values1;
            var values2 = c.Products.Count().ToString();
            ViewBag.v2 = values2;
            var values3 = c.Employees.Count().ToString();
            ViewBag.v3 = values3;
            var values4 = c.Categories.Count().ToString();
            ViewBag.v4 = values4;
            var values5 = c.Products.Sum(x=>x.Stock).ToString();
            ViewBag.v5 = values5;
            var values6 = (from x in c.Products select x.ProductBrand).Distinct().Count().ToString();
            ViewBag.v6 = values6;
            var values7 = c.Products.Count(x => x.Stock<=20).ToString();
            ViewBag.v7 = values7;
            var values8 = (from x in c.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault();
            ViewBag.v8 = values8;
            var values9 = (from x in c.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault();
            ViewBag.v9 = values9;
            var values10 = c.Products.Count(x => x.ProductName == "Fridge").ToString();
            ViewBag.v10 = values10;
            var values11 = c.Products.Count(x => x.ProductName == "Laptop").ToString();
            ViewBag.v11 = values11;
            var values12 = c.Products.GroupBy(x => x.ProductBrand).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault();
            ViewBag.v12 = values12;
            var values13 = c.Products.Where(p=>p.ProductsId==(c.SalesMoves.GroupBy(x => x.ProductsId).OrderByDescending(z => z.Count()).Select(y => y.Key).FirstOrDefault())).Select(k=>k.ProductName).FirstOrDefault();
            ViewBag.v13 = values13;
            var values14 = c.SalesMoves.Sum(x => x.TotalAmount).ToString();
            ViewBag.v14 = values14;

            DateTime today = DateTime.Today;
            var values15 = c.SalesMoves.Count(x => x.Date == today).ToString();
            ViewBag.v15 = values15;
            var values16 = c.SalesMoves.Where(x => x.Date == today).Sum(y =>(decimal?) y.TotalAmount).ToString();
            ViewBag.v16 = values16;
            return View();
        }

        public ActionResult EasyTables()
        {
            var query = from x in c.Currents
                        group x by x.CurrentCity into g
                        select new GroupClass
                        {
                            City = g.Key,
                            Total = g.Count()
                        };
            return View(query.ToList());
        }
        public PartialViewResult Partial1()
        {
            var query2 = from x in c.Employees
                         group x by x.Department.DepartmentName into g
                         select new GroupClass2
                         {
                             Department = g.Key,
                             Number = g.Count()
                         };
            return PartialView(query2.ToList());
        }
        public PartialViewResult Partial2()
        {
            var query = c.Currents.ToList();
            return PartialView(query);
        }
        public PartialViewResult Partial3()
        {
            var query = c.Products.ToList();
            return PartialView(query);
        }
        public PartialViewResult Partial4()
        {
            var query = c.Categories.ToList();
            return PartialView(query);
        }

        public PartialViewResult Partial5()
        {

            var query3 = from x in c.Products
                         group x by x.ProductBrand into g
                         select new GroupClass3
                         {
                             Brand = g.Key,
                             Number = g.Count()
                         };
            return PartialView(query3.ToList());
        }
    }
}