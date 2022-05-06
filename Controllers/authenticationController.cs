using ProjectAssignments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectAssignments.Controllers
{
    public class authenticationController : Controller
    {
        // GET: authentication
        private demonstrationEntities1 dbadmin = new demonstrationEntities1();
        private employees dbemployee = new employees();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(AdminAndEmployee adminAndEmployee)
        {

            if(adminAndEmployee == null)return View();
            if (adminAndEmployee.IsAdmin)
            {
                Registration_Table rgTable= dbadmin.Registration_Table.FirstOrDefault(admins => admins.UserName == adminAndEmployee.username && admins.Password == adminAndEmployee.password);
                if(rgTable == null)
                {
                    ModelState.AddModelError("","username or password wrong");
                    return View();
                }
                FormsAuthentication.SetAuthCookie(adminAndEmployee.username, false);
                return RedirectToAction("home", "Homepage", new { username = adminAndEmployee.username });

            }
            else
            {
                EmployeesTable emTable = dbemployee.EmployeesTables.FirstOrDefault(emp => emp.EmpName == adminAndEmployee.username && emp.password == adminAndEmployee.password);
                if(emTable == null)
                {
                    ModelState.AddModelError("", " wrong username or password ");
                }
                else
                {
                    FormsAuthentication.SetAuthCookie(adminAndEmployee.username, false);
                    return RedirectToAction("home", "Projects", new { username = adminAndEmployee.username });
                }

            }
            return View();
        }

        public ActionResult register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(Registration_Table registration)
        {
            if(registration == null)
            {
                ModelState.AddModelError("", "Something went wrong");
                return View();
            }
            if (ModelState.IsValid)
            {
                dbadmin.Registration_Table.Add(registration);
                dbadmin.SaveChanges();
                return RedirectToAction("login");
            }
           return View();
        }
    }
}