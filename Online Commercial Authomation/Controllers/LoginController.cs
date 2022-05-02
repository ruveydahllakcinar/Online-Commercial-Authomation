using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Online_Commercial_Authomation.Models.Classes;


namespace Online_Commercial_Authomation.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context c = new Context();
        public ActionResult Index()
        {
            return View();
        }
        /*REGISTER HERE*/
        [HttpGet]
        public PartialViewResult PartialRegister()
        {
            return PartialView();
        }
        [HttpPost]
        public PartialViewResult PartialRegister(Current current)
        {
            c.Currents.Add(current);
            c.SaveChanges();
            return PartialView();
        }

        /*CURRENT LOGIN*/
        [HttpGet]
        public ActionResult CurrentLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CurrentLogin1(Current crr)
        {
            var informations = c.Currents.FirstOrDefault(x => x.CurrentMail == crr.CurrentMail && x.CurrentPassword == crr.CurrentPassword);
            if (informations != null)
            {
                FormsAuthentication.SetAuthCookie(informations.CurrentMail, false);
                Session["CurrentMail"] = informations.CurrentMail.ToString();
                return RedirectToAction("Index", "CurrentPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AdminLogin(Admin admin)
        {
            var informations = c.Admins.FirstOrDefault(x => x.UserName==admin.UserName && admin.Password == admin.Password);
            if (informations!=null)
            {
                FormsAuthentication.SetAuthCookie(informations.UserName, false);
                Session["UserName"] = informations.UserName.ToString();
                return RedirectToAction("Index", "Category");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
            
        
        }
    }
}