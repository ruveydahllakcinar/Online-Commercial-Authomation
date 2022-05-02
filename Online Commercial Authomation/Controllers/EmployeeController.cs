using System;
using System.Collections.Generic;
using System.IO;
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
            
            return View();
        }
        [HttpPost]
        public ActionResult EmployeeAdd(Employee employee)
        {
            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName); /*Dosya uzanstısı alınır*/
                string href = "~/Image/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(href));
                employee.EmployeeImage = "/Image/" + filename + extension;
            }
            c.Employees.Add(employee);
            c.SaveChanges();
            return RedirectToAction("Index");
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

            if (Request.Files.Count > 0)
            {
                string filename = Path.GetFileName(Request.Files[0].FileName);
                string extension = Path.GetExtension(Request.Files[0].FileName); /*Dosya uzanstısı alınır*/
                string href = "~/Image/" + filename + extension;
                Request.Files[0].SaveAs(Server.MapPath(href));
                employee.EmployeeImage = "/Image/" + filename + extension;
            }
            employee.DepartmentId = em.DepartmentId;
            c.SaveChanges();
            return RedirectToAction("Index");

        }
        public ActionResult EmployeeList()
        {
            var values = c.Employees.ToList();
            return View(values);
        }
             
    }
}