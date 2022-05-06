using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjectAssignments.Models;

namespace ProjectAssignments.Controllers
{
    public class ProjectAssigmentTablesController : Controller
    {
        private demonstrationEntities5 db = new demonstrationEntities5();

        // GET: ProjectAssigmentTables
        public ActionResult Index()
        {
            return View(db.ProjectAssigmentTables.ToList());
        }

        // GET: ProjectAssigmentTables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectAssigmentTable projectAssigmentTable = db.ProjectAssigmentTables.Find(id);
            if (projectAssigmentTable == null)
            {
                return HttpNotFound();
            }
            return View(projectAssigmentTable);
        }

        // GET: ProjectAssigmentTables/Create
        public ActionResult ProjectAssign()
        {
            return View();
        }

        // POST: ProjectAssigmentTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProjectAssign([Bind(Include = "EmpName,ProjectName,ProjectManager,ProjectStartDate,ProjectEndDate,Department,Admin")] ProjectAssigmentTable projectAssigmentTable)
        {
            if (ModelState.IsValid)
            {
                db.ProjectAssigmentTables.Add(projectAssigmentTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(projectAssigmentTable);
        }

        // GET: ProjectAssigmentTables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectAssigmentTable projectAssigmentTable = db.ProjectAssigmentTables.Find(id);
            if (projectAssigmentTable == null)
            {
                return HttpNotFound();
            }
            return View(projectAssigmentTable);
        }

        // POST: ProjectAssigmentTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpName,ProjectName,ProjectManager,ProjectStartDate,ProjectEndDate,Department,Admin")] ProjectAssigmentTable projectAssigmentTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectAssigmentTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(projectAssigmentTable);
        }

        // GET: ProjectAssigmentTables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectAssigmentTable projectAssigmentTable = db.ProjectAssigmentTables.Find(id);
            if (projectAssigmentTable == null)
            {
                return HttpNotFound();
            }
            return View(projectAssigmentTable);
        }

        // POST: ProjectAssigmentTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            ProjectAssigmentTable projectAssigmentTable = db.ProjectAssigmentTables.Find(id);
            db.ProjectAssigmentTables.Remove(projectAssigmentTable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
