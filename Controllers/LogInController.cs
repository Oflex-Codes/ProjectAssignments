using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.ComponentModel.DataAnnotations;
using ProjectAssignments.Models;

namespace ProjectAssignments.Controllers
{
    
    public class LogInController : Controller
    {
        demonstrationEntities1 db = new demonstrationEntities1();
        // GET: LogIn
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult Login(Registration_Table user)
        {
            var usr = db.Registration_Table.FirstOrDefault(u => u.UserName == user.UserName && u.Password == user.Password);
            if(usr != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                return RedirectToAction("Employee", "EmployeTables");
            }
            else
            {
                ModelState.AddModelError("", "Username Or Password incorrect");
            }
            return View(user);
        }

    }
}