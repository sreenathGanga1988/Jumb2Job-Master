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
    public class JobFieldAreasController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: AdminPanel/JobFieldAreas
        public ActionResult Index()
        {
            var jobFieldAreas = db.JobFieldAreas.Include(j => j.JobField);
            return View(jobFieldAreas.ToList());
        }

        // GET: AdminPanel/JobFieldAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobFieldArea jobFieldArea = db.JobFieldAreas.Find(id);
            if (jobFieldArea == null)
            {
                return HttpNotFound();
            }
            return View(jobFieldArea);
        }

        // GET: AdminPanel/JobFieldAreas/Create
        public ActionResult Create()
        {
            ViewBag.JobFieldId = new SelectList(db.JobFields, "JobFieldId", "JobFieldName");
            return View();
        }

        // POST: AdminPanel/JobFieldAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JobAreaId,JobAreaName,JobFieldId")] JobFieldArea jobFieldArea)
        {
            if (ModelState.IsValid)
            {
                db.JobFieldAreas.Add(jobFieldArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.JobFieldId = new SelectList(db.JobFields, "JobFieldId", "JobFieldName", jobFieldArea.JobFieldId);
            return View(jobFieldArea);
        }

        // GET: AdminPanel/JobFieldAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobFieldArea jobFieldArea = db.JobFieldAreas.Find(id);
            if (jobFieldArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.JobFieldId = new SelectList(db.JobFields, "JobFieldId", "JobFieldName", jobFieldArea.JobFieldId);
            return View(jobFieldArea);
        }

        // POST: AdminPanel/JobFieldAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobAreaId,JobAreaName,JobFieldId")] JobFieldArea jobFieldArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobFieldArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JobFieldId = new SelectList(db.JobFields, "JobFieldId", "JobFieldName", jobFieldArea.JobFieldId);
            return View(jobFieldArea);
        }

        // GET: AdminPanel/JobFieldAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobFieldArea jobFieldArea = db.JobFieldAreas.Find(id);
            if (jobFieldArea == null)
            {
                return HttpNotFound();
            }
            return View(jobFieldArea);
        }

        // POST: AdminPanel/JobFieldAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            JobFieldArea jobFieldArea = db.JobFieldAreas.Find(id);
            db.JobFieldAreas.Remove(jobFieldArea);
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
