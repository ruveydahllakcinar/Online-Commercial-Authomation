using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Online_Commercial_Authomation.Models.Classes;

namespace Online_Commercial_Authomation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context c = new Context();
        public ActionResult Index()
        {
            var values = c.Employees.ToList();
            return View(values);
        }
        [HttpGet]
        public ActionResult EmployeeAdd()
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            
            return View("EmployeeList");
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employee employee)
        {
            c.Employees.Add(employee);
            c.SaveChanges();
            return RedirectToAction("EmployeeList");
        }

        public ActionResult EmployeeFind(int id)
        {
            List<SelectListItem> value1 = (from x in c.Departments.ToList()
                                           select new SelectListItem
                                           {
                                               Text = x.DepartmentName,
                                               Value = x.DepartmentId.ToString()
                                           }).ToList();
            ViewBag.vl1 = value1;
            var emp = c.Employees.Find(id);
            return View("EmployeeFind", emp);
        }
        public ActionResult EmployeeUpdate(Employee em)
        {
            var employee = c.Employees.Find(em.EmployeeId);
            employee.EmployeeName = em.EmployeeName;
            employee.EmployeeSurname = em.EmployeeSurname;
            employee.EmployeeImage = em.EmployeeImage;
            employee.DepartmentId = em.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("EmployeeList");

        }
        public ActionResult EmployeeList()
        {
            var values = c.Employees.ToList();
            return View(values);
        }
             
    }
}