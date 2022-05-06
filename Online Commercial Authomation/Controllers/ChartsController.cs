using Online_Commercial_Authomation.Models.Classes;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Online_Commercial_Authomation.Controllers
{
    public class ChartsController : Controller
    {
        // GET: Charts
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            var drawchart = new Chart(600, 600);
            drawchart.AddTitle("Category - Product Stock Number").AddLegend("Stock").AddSeries("Values", xValue: new[] { "Fridge", "Small Appliances", "Computer", "Phone", "Furniture", "Decoration" }, yValues: new[] { 85, 65, 98,75,65,10 }).Write();
            return File(drawchart.ToWebImage().GetBytes(), "image/jpeg");


        }
        

        public ActionResult Index3()
        {
            ArrayList xvalue = new ArrayList();
            ArrayList yvalue = new ArrayList();
            var result = c.Products.ToList();
            result.ToList().ForEach(x => xvalue.Add(x.ProductName));
            result.ToList().ForEach(y => yvalue.Add(y.Stock));
            var chart = new Chart(width: 800, height: 800).AddTitle("Stocks").AddSeries(chartType: "Pie", name: "Stock", xValue: xvalue, yValues: yvalue);
            return File(chart.ToWebImage().GetBytes(), "image/jpeg");
        }

        public ActionResult Index4()
        {
            return View();
        }
        public ActionResult VisualizeProductResult()
        {
            return Json(ProductList(), JsonRequestBehavior.AllowGet);
        }
        public List<GoogleChart> ProductList()
        {
            List<GoogleChart> cls = new List<GoogleChart>();
            cls.Add(new GoogleChart()
            {
                ProductName="Computer",
                Stock =120
            });
            cls.Add(new GoogleChart()
            {
                ProductName = "Fridge",
                Stock = 200
            });
            cls.Add(new GoogleChart()
            {
                ProductName = "Washing Machine",
                Stock = 70
            });
            cls.Add(new GoogleChart()
            {
                ProductName = "Computer",
                Stock = 120
            });
            cls.Add(new GoogleChart()
            {
                ProductName = "Furniture",
                Stock = 20
            });
            cls.Add(new GoogleChart()
            {
                ProductName = "Small Appliances",
                Stock = 150
            });
            return cls;
        }
        public ActionResult Index5()
        {
            return View();
        }
        public ActionResult VisualizeProductResult2()
        {
            return Json(ProductList2(), JsonRequestBehavior.AllowGet);
        }


        public List<GoogleChart2> ProductList2()
        {
            List<GoogleChart2> chart = new List<GoogleChart2>();
            using (var c = new Context())
            {
                chart = c.Products.Select(x => new GoogleChart2
                {
                    prdt = x.ProductName,
                    stck = x.Stock
                }).ToList();
            }


            return chart;
        }
    }

}

