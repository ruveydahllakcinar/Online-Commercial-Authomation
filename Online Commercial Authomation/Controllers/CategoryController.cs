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
    public class CategoryController : Controller
    {
        // GET: Category
        Context c = new Context();
        public ActionResult Index(int page =1)
        {
            var values = c.Categories.ToList().ToPagedList(page, 4);
            return View(values);
        }

        [HttpGet]
        public ActionResult CategoryAdd()
        {
            //c.Categories.Add();
            return View();
        }
        [HttpPost]
        public ActionResult CategoryAdd(Category k)
        {
            c.Categories.Add(k);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryDelete(int id)
        {
           var cat = c.Categories.Find(id);
            c.Categories.Remove(cat);
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult CategoryFind(int id)
        {
            var category = c.Categories.Find(id);
            return View("CategoryFind" , category);
        }
        public ActionResult CategoryUpdate(Category category)
        {
            var ct = c.Categories.Find(category.CategoryId);
            ct.CategoryName = category.CategoryName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Cascading()
        {

            Cascading cs = new Cascading();
            cs.Categories = new SelectList(c.Categories, "CategoryId", "CategoryName");
            cs.Products = new SelectList(c.Products, "ProductsId", "ProductName");
            return View(cs);
        }

        public JsonResult ProductBring(int p)
        {
            var productlist = (from x in c.Products
                               join y in c.Categories on x.Category.CategoryId equals y.CategoryId
                               where x.Category.CategoryId == p
                               select new
                               {
                                   Text = x.ProductName,
                                   Value = x.ProductsId.ToString()
                               }).ToList();

            return Json(productlist, JsonRequestBehavior.AllowGet);
        }
    }

}