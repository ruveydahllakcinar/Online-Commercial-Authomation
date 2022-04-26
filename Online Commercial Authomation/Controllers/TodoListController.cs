using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;
namespace Online_Commercial_Authomation.Controllers
{
    public class TodoListController : Controller
    {
        // GET: TodoList
        Context c = new Context();
        public ActionResult Index()
        {
            var value1 = c.Currents.Count().ToString();
            ViewBag.v1 = value1;
            var value2 = c.Products.Count().ToString();
            ViewBag.v2 = value2;
            var value3 = c.Categories.Count().ToString();
            ViewBag.v3 = value3;
            var value4 = (from x in c.Currents select x.CurrentCity).Distinct().Count().ToString();
            ViewBag.v4 = value4;

            var todolist = c.Todolists.ToList();
            return View(todolist);
        }

    }
}