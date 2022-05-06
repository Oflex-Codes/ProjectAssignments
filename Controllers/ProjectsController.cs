using ProjectAssignments.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectAssignments.Controllers
{
    public class ProjectsController : Controller
    {
        private projectEntities dbProject = new projectEntities();
        // GET: Projects
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult home(string username)
        {
            
            List<Project> allProjects=dbProject.Projects.ToList();
            List<Project> projects=new List<Project>();
            foreach (Project project in allProjects)
            {
                if(project.EmpName.Equals(username))projects.Add(project);  
            }
            return View(projects);
        }
        public ActionResult complete(string username)
        {
            string[] info= username.Split('-');
            string user=info[0];    
            int projectid=Int32.Parse(info[1]);

            Project project = dbProject.Projects.SingleOrDefault(p=>p.projectis==projectid);
            if (project == null)
            {
                return View("Error");
            }
            project.isComplete = 1;
            if (ModelState.IsValid)
            {
                dbProject.Entry(project).State = EntityState.Modified;
                dbProject.SaveChanges();
                ViewBag.user=user;
            }

            return View();
        }
    }
}