using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;

namespace Online_Commercial_Authomation.Controllers
{
    [Authorize]
    public class DepartmentController : Controller
    {
        // GET: Department
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Departments.Where(x => x.Situation == true).ToList();
            return View(values);
        }
        [Authorize(Roles ="A")]
        [HttpGet]
   
        public ActionResult DepartmentAdd()
        {
           
            return View();
        }
        [HttpPost]
        
        public ActionResult DepartmentAdd(Department department)
        {
            c.Departments.Add(department);
            c.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult DepartmentDelete(int id)
        {
            var dep = c.Departments.Find(id);
            dep.Situation = false;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentFind(int id)
        {
            var department = c.Departments.Find(id);
            return View("DepartmentFind", department);
        }

        public ActionResult DepartmentUpdate(Department dt)
        {
            var dept = c.Departments.Find(dt.DepartmentId);
            dept.DepartmentName = dt.DepartmentName;
            c.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DepartmentDetail(int id)
        {
            var values = c.Employees.Where(x => x.DepartmentId == id).ToList();

            var dpt = c.Departments.Where(x => x.DepartmentId == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.department = dpt;
            return View(values);
        }

        public ActionResult DepartmentEmployeeSale(int id)
        {
            var values = c.SalesMoves.Where(x => x.EmployeeId == id).ToList();
            var emp = c.Employees.Where(x => x.EmployeeId == id).Select(y => y.EmployeeName +" "+ y.EmployeeSurname).FirstOrDefault();
            ViewBag.demp = emp;
            return View(values);
        }
    }
}