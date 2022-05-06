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
    public class EmployeTablesController : Controller
    {
        private demonstrationEntities4 db = new demonstrationEntities4();

        // GET: EmployeTables
        public ActionResult Index()
        {
            return View(db.EmployeTables.ToList());
        }

        // GET: EmployeTables/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeTable employeTable = db.EmployeTables.Find(id);
            if (employeTable == null)
            {
                return HttpNotFound();
            }
            return View(employeTable);
        }

        // GET: EmployeTables/Create
        public ActionResult Employee()
        {
            return View();
        }

        // POST: EmployeTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Employee([Bind(Include = "EmpName,EntryDate,EmployementDate,Salary,VaxOrNot,Age,Position,Admin,Password")] EmployeTable employeTable)
        {
            if (ModelState.IsValid)
            {

                db.EmployeTables.Add(employeTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(employeTable);
        }

        // GET: EmployeTables/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeTable employeTable = db.EmployeTables.Find(id);
            if (employeTable == null)
            {
                return HttpNotFound();
            }
            return View(employeTable);
        }

        // POST: EmployeTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpName,EntryDate,EmployementDate,Salary,VaxOrNot,Age,Position,Admin,Password")] EmployeTable employeTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employeTable);
        }

        // GET: EmployeTables/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeTable employeTable = db.EmployeTables.Find(id);
            if (employeTable == null)
            {
                return HttpNotFound();
            }
            return View(employeTable);
        }

        // POST: EmployeTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            EmployeTable employeTable = db.EmployeTables.Find(id);
            db.EmployeTables.Remove(employeTable);
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
