using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizAPI.Models;

namespace QuizAPI.Areas.AdminPanel.Controllers
{
    public class JobFieldsController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: AdminPanel/JobFields
        public ActionResult Index()
        {
            return View(db.JobFields.ToList());
        }

        // GET: AdminPanel/JobFields/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobField jobField = db.JobFields.Find(id);
            if (jobField == null)
            {
                return HttpNotFound();
            }
            return View(jobField);
        }

        // GET: AdminPanel/JobFields/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/JobFields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobFieldId,JobFieldName")] JobField jobField)
        {
            if (ModelState.IsValid)
            {
                db.JobFields.Add(jobField);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobField);
        }

        // GET: AdminPanel/JobFields/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobField jobField = db.JobFields.Find(id);
            if (jobField == null)
            {
                return HttpNotFound();
            }
            return View(jobField);
        }

        // POST: AdminPanel/JobFields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobFieldId,JobFieldName")] JobField jobField)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobField).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobField);
        }

        // GET: AdminPanel/JobFields/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobField jobField = db.JobFields.Find(id);
            if (jobField == null)
            {
                return HttpNotFound();
            }
            return View(jobField);
        }

        // POST: AdminPanel/JobFields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobField jobField = db.JobFields.Find(id);
            db.JobFields.Remove(jobField);
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
