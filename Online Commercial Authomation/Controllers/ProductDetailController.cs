using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;

namespace Online_Commercial_Authomation.Controllers
{
    public class ProductDetailController : Controller
    {
        // GET: ProductDetail
        Context c = new Context();
        public ActionResult Index()
        {
            ProductDetail pd = new ProductDetail();
            //var values = c.Products.Where(x => x.ProductsId == 1).ToList();
            pd.Values1=c.Products.Where(x => x.ProductsId == 1).ToList();
            pd.Values2 = c.Details.Where(y => y.DetailId == 1).ToList();
            return View(pd);
        }

    }
}