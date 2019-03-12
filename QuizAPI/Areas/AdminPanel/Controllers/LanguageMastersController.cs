using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QuizAPI.Models;

namespace QuizAPI.Areas.AdminPanel.Controllers
{
    public class LanguageMastersController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: AdminPanel/LanguageMasters
        public async Task<ActionResult> Index()
        {
            return View(await db.LanguageMasters.ToListAsync());
        }

        // GET: AdminPanel/LanguageMasters/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageMaster languageMaster = await db.LanguageMasters.FindAsync(id);
            if (languageMaster == null)
            {
                return HttpNotFound();
            }
            return View(languageMaster);
        }

        // GET: AdminPanel/LanguageMasters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/LanguageMasters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "LanguageId,LanguageName")] LanguageMaster languageMaster)
        {
            if (ModelState.IsValid)
            {
                db.LanguageMasters.Add(languageMaster);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(languageMaster);
        }

        // GET: AdminPanel/LanguageMasters/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageMaster languageMaster = await db.LanguageMasters.FindAsync(id);
            if (languageMaster == null)
            {
                return HttpNotFound();
            }
            return View(languageMaster);
        }

        // POST: AdminPanel/LanguageMasters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "LanguageId,LanguageName")] LanguageMaster languageMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(languageMaster).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(languageMaster);
        }

        // GET: AdminPanel/LanguageMasters/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LanguageMaster languageMaster = await db.LanguageMasters.FindAsync(id);
            if (languageMaster == null)
            {
                return HttpNotFound();
            }
            return View(languageMaster);
        }

        // POST: AdminPanel/LanguageMasters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            LanguageMaster languageMaster = await db.LanguageMasters.FindAsync(id);
            db.LanguageMasters.Remove(languageMaster);
            await db.SaveChangesAsync();
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
