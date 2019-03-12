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
    public class CountryMastersController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: AdminPanel/CountryMasters
        public ActionResult Index()
        {
            return View(db.CountryMasters.ToList());
        }

        // GET: AdminPanel/CountryMasters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryMaster countryMaster = db.CountryMasters.Find(id);
            if (countryMaster == null)
            {
                return HttpNotFound();
            }
            return View(countryMaster);
        }

        // GET: AdminPanel/CountryMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/CountryMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CountryId,CountryName")] CountryMaster countryMaster)
        {
            if (ModelState.IsValid)
            {
                db.CountryMasters.Add(countryMaster);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(countryMaster);
        }

        // GET: AdminPanel/CountryMasters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryMaster countryMaster = db.CountryMasters.Find(id);
            if (countryMaster == null)
            {
                return HttpNotFound();
            }
            return View(countryMaster);
        }

        // POST: AdminPanel/CountryMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CountryId,CountryName")] CountryMaster countryMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(countryMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(countryMaster);
        }

        // GET: AdminPanel/CountryMasters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CountryMaster countryMaster = db.CountryMasters.Find(id);
            if (countryMaster == null)
            {
                return HttpNotFound();
            }
            return View(countryMaster);
        }

        // POST: AdminPanel/CountryMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CountryMaster countryMaster = db.CountryMasters.Find(id);
            db.CountryMasters.Remove(countryMaster);
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
