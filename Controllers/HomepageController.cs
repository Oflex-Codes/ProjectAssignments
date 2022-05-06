using ProjectAssignments.Data;
using ProjectAssignments.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ProjectAssignments.Controllers
{
    public class HomepageController : Controller
    {
        // GET: Homepage
        private employees dbemployee = new employees();
        private projectEntities dbProject = new projectEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult home(String username)
        {
            usernameStore usernamestore = new usernameStore();
            usernamestore.username = username;
            return View(usernamestore);
        }
        public ActionResult employeeregistration(String username)
        {
            //check if username is null
            EmployeesTable employee=new EmployeesTable();
            employee.admin = username;
            employee.EntryDate= DateTime.Now;
            return View(employee);
        }
        [HttpPost]  
        public ActionResult employeeregistration(EmployeesTable employee)
        {

            if (employee.admin.Equals(""))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (!employee.EmpName.Equals(""))
            {
                EmployeesTable exist =dbemployee.EmployeesTables.FirstOrDefault(exit=>exit.EmpName.Equals(employee.EmpName));
                if (exist != null)
                {
                    ModelState.AddModelError(string.Empty, "Employee Name already Exist");
                    return View();
                }
            }
            else 
            {
                ModelState.AddModelError(string.Empty, "Please enter all the fields");
                return View();
            }
            if (employee.Position.Equals("") || employee.Position.Equals("---Select---"))
            {
                ModelState.AddModelError(string.Empty, "Please enter all the fields");
                return View();
            }
            if (employee.EmployementDate.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Please enter all the fields");
                return View();
            }
            if (employee.salary.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Please enter all the fields");
                return View();
            }
            if (employee.age<100|| employee.age > 0)
            {
                ModelState.AddModelError(string.Empty, "enters valid age");
                return View();
            }
            if (employee.VaxOrNot!=0&&employee.VaxOrNot != 1)
            {
                ModelState.AddModelError(string.Empty, "please select if you are vacinated or not");
                return View();
            }
           
            if (employee.password.Equals("")|| employee.password.Length<6)
            {
                ModelState.AddModelError(string.Empty, "Password must be more than 6 characters");
                return View();
            }
           

            employee.isComplete = 0;
            dbemployee.EmployeesTables.Add(employee);
            dbemployee.SaveChanges();
            return RedirectToAction("employeeregistration", "Homepage", new { username = employee.admin });
        }
        public ActionResult addproject(String username)
        {
            ViewBag.Message = "";
            List<EmployeesTable> employees = dbemployee.EmployeesTables.ToList();
            if (employees.Count < 0)
            {
                ModelState.AddModelError("", "No Employees");
                return View();
            }
            ViewBag.EmployeesList= new SelectList(employees, "EmpName", "EmpName");
            Project project = new Project();
            project.Admin = username;

            return View(project);
        }
        [HttpPost]
        public ActionResult addproject(Project project)
        {
            List<EmployeesTable> employees = dbemployee.EmployeesTables.ToList();
            
            if (employees.Count < 0)
            {
                ModelState.AddModelError("", "No Employees");
                return View();
            }
            ViewBag.EmployeesList = new SelectList(employees, "EmpName", "EmpName");
            if (project == null)
            {
                ModelState.AddModelError(string.Empty, "Something wrong happened.");
                return View();
            }
            if (project.EmpName.Equals("")|| project.EmpName.Equals("---select---"))
            {
                ModelState.AddModelError(string.Empty, "Add employee name");
                return View();
            }
            if (project.ProjectName.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Enter project name");
                return View();
            }
            if (project.ProjectManager.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "enter project manager's name");
                return View();
            }
            if (project.ProjectStartDate.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Enter start date of the project.");
                return View();
            }
            if (project.ProjectEndDate.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Enter end date of the project.");
                return View();
            }
            if (project.Department.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "enter department.");
                return View();
            }
            if (project.Admin.Equals(""))
            {
                ModelState.AddModelError(string.Empty, "Something wrong happened.");
                return View();
            }
            project.projectis = random();
            project.isComplete = 0;
            dbProject.Projects.Add(project);
            dbProject.SaveChanges();
            ViewBag.Message = "Success";
            return RedirectToAction("addproject", "Homepage", new { username = project.Admin });
        }
        private int random()
        {
            Random random = new Random();
            int projectId=random.Next(Int32.MaxValue);
            Project exit = dbProject.Projects.FirstOrDefault(p=>p.projectis==projectId);

            while(exit != null)
            {
                projectId = (projectId + random.Next(Int32.MaxValue))%Int32.MaxValue;
                exit = dbProject.Projects.FirstOrDefault(p => p.projectis == projectId);
            }
            return projectId;
        }
    }
}