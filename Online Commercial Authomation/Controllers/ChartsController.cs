using Online_Commercial_Authomation.Models.Classes;
using System.Collections;
using System.Linq;
using System.Web.Helpers;
using System.Web.Mvc;

namespace Online_Commercial_Authomation.Controllers
{
    public class ChartsController : Controller
    {
        // GET: Charts
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
        Context c = new Context();

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


    }
}