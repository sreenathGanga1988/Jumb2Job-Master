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
    public class KnowledgeAreasController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: AdminPanel/KnowledgeAreas
        public ActionResult Index()
        {
            var knowledgeAreas = db.KnowledgeAreas.Include(k => k.Certification);
            return View(knowledgeAreas.ToList());
        }

        // GET: AdminPanel/KnowledgeAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgeArea knowledgeArea = db.KnowledgeAreas.Find(id);
            if (knowledgeArea == null)
            {
                return HttpNotFound();
            }
            return View(knowledgeArea);
        }

        // GET: AdminPanel/KnowledgeAreas/Create
        public ActionResult Create()
        {
            ViewBag.CertificationId = new SelectList(db.Certifications, "CertificationId", "CertificationName");
            return View();
        }

        // POST: AdminPanel/KnowledgeAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "KnowledgeAreaId,CertificationId,KnowledgeAreaName,Remark")] KnowledgeArea knowledgeArea)
        {
            if (ModelState.IsValid)
            {
                db.KnowledgeAreas.Add(knowledgeArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CertificationId = new SelectList(db.Certifications, "CertificationId", "CertificationName", knowledgeArea.CertificationId);
            return View(knowledgeArea);
        }

        // GET: AdminPanel/KnowledgeAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgeArea knowledgeArea = db.KnowledgeAreas.Find(id);
            if (knowledgeArea == null)
            {
                return HttpNotFound();
            }
            ViewBag.CertificationId = new SelectList(db.Certifications, "CertificationId", "CertificationName", knowledgeArea.CertificationId);
            return View(knowledgeArea);
        }

        // POST: AdminPanel/KnowledgeAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "KnowledgeAreaId,CertificationId,KnowledgeAreaName,Remark")] KnowledgeArea knowledgeArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(knowledgeArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CertificationId = new SelectList(db.Certifications, "CertificationId", "CertificationName", knowledgeArea.CertificationId);
            return View(knowledgeArea);
        }

        // GET: AdminPanel/KnowledgeAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KnowledgeArea knowledgeArea = db.KnowledgeAreas.Find(id);
            if (knowledgeArea == null)
            {
                return HttpNotFound();
            }
            return View(knowledgeArea);
        }

        // POST: AdminPanel/KnowledgeAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KnowledgeArea knowledgeArea = db.KnowledgeAreas.Find(id);
            db.KnowledgeAreas.Remove(knowledgeArea);
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
