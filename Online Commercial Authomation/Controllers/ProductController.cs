using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;
using PagedList;
using PagedList.Mvc;

namespace Online_Commercial_Authomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context c = new Context();
        public ActionResult Index(string p)
        { var products = from x in c.Products select x; 
            if (!string.IsNullOrEmpty(p))
            { products = products.Where(y => y.ProductName.Contains(p)); } 
            return View(products.ToList());
        }

        [HttpGet]
        public ActionResult ProductAdd()
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            return View();
        }

        [HttpPost]
        public ActionResult ProductAdd(Product product)
        {
            c.Products.Add(product);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductDelete(int id)
        {
            var pro = c.Products.Find(id);
            pro.Situation = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }



        public ActionResult ProductFind(int id)
        {
            List<SelectListItem> value1 = (from x in c.Categories.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.CategoryName,
                                               Value = x.CategoryId.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            var productvalue = c.Products.Find(id);
            return View("ProductFind", productvalue);
        }

        public ActionResult ProductUpdate(Product p)
        {
            var prd = c.Products.Find(p.ProductsId);
            prd.PurchasePrice = p.PurchasePrice;
            prd.Situation = p.Situation;
            prd.CategoryId = p.CategoryId;
            prd.ProductBrand = p.ProductBrand;
            prd.SalePrice = p.SalePrice;
            prd.Stock = p.Stock;
            prd.ProductName = p.ProductName;
            prd.ProductImage = p.ProductImage;
            c.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var values = c.Products.ToList();
            return View(values);
        }
    }
}