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
    public class Registration_TableController : Controller
    {
        private demonstrationEntities1 db = new demonstrationEntities1();

        // GET: Registration_Table
        public ActionResult Index()
        {
            return View(db.Registration_Table.ToList());
        }

        // GET: Registration_Table/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration_Table registration_Table = db.Registration_Table.Find(id);
            if (registration_Table == null)
            {
                return HttpNotFound();
            }
            return View(registration_Table);
        }

        // GET: Registration_Table/Create
        public ActionResult Register()
        {
            return View();
        }

        // POST: Registration_Table/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register([Bind(Include = "FullName,LastName,UserName,Password")] Registration_Table registration_Table)
        {
            if (ModelState.IsValid)
            {
                db.Registration_Table.Add(registration_Table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(registration_Table);
        }

        // GET: Registration_Table/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration_Table registration_Table = db.Registration_Table.Find(id);
            if (registration_Table == null)
            {
                return HttpNotFound();
            }
            return View(registration_Table);
        }

        // POST: Registration_Table/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FullName,LastName,UserName,Password")] Registration_Table registration_Table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration_Table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(registration_Table);
        }

        // GET: Registration_Table/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration_Table registration_Table = db.Registration_Table.Find(id);
            if (registration_Table == null)
            {
                return HttpNotFound();
            }
            return View(registration_Table);
        }

        // POST: Registration_Table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Registration_Table registration_Table = db.Registration_Table.Find(id);
            db.Registration_Table.Remove(registration_Table);
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
