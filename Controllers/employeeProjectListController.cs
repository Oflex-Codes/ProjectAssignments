using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAssignments.Controllers
{
    public class employeeProjectListController : Controller
    {
        // GET: employeeProjectList
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult home(string username)
        {
            return View();
        }
    }
}