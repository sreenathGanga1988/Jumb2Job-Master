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

namespace QuizAPI.Controllers
{
    public class JobVaccanciesController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: JobVaccancies
        public async Task<ActionResult> Index(int countryid = 0, int jobfeildId = 0)
        {

            ViewBag.Title = "Uae And Indian Jobs";
            ViewBag.MetaDescription = "Jobs in Uae and India ,Hot Job Vaccancies,";
            ViewBag.MetaKeywords = "Driver job ,It Job ";

            var jobVaccancys = db.JobVaccancys.Include(j => j.CountryMaster).Include(j => j.JobFieldArea);
            string Tittle = "";

            if (countryid != 0)
            {
                jobVaccancys = jobVaccancys.Where(u => u.CountryId == countryid);

                Tittle = Tittle + jobVaccancys.FirstOrDefault().CountryMaster.CountryName.ToString() + "Jobs";
            }
            if (jobfeildId != 0)
            {
                jobVaccancys = jobVaccancys.Where(u => u.JobFieldArea.JobFieldId == jobfeildId);
                Tittle = jobVaccancys.FirstOrDefault().JobFieldArea.JobAreaName.ToString() + "Jobs" + Tittle;
            }


            if (Tittle != "")
            {
                ViewBag.Title = Tittle;
            }


            return View(await jobVaccancys.ToListAsync());
        }










        // GET: JobVaccancies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobVaccancy jobVaccancy = await db.JobVaccancys.FindAsync(id);
            if (jobVaccancy == null)
            {
                return HttpNotFound();
            }
            return View(jobVaccancy);
        }

        // GET: JobVaccancies/Create
        public ActionResult Create()
        {
            ViewBag.CountryId = new SelectList(db.CountryMasters, "CountryId", "CountryName");
            ViewBag.JobAreaId = new SelectList(db.JobFieldAreas, "JobAreaId", "JobAreaName");
            ViewBag.EmploymentType = new SelectList(
    new List<SelectListItem>
    {

        new SelectListItem { Selected = true, Text = "Permanent", Value = "Permanent"},
        new SelectListItem { Selected = false, Text = "Contract", Value = "Contract"},
        new SelectListItem { Selected = false, Text = "Part-time", Value = "Part-time"},
        new SelectListItem { Selected = false, Text = "Intership", Value = "Intership"},
        new SelectListItem { Selected = false, Text = "Trainee", Value = "Trainee"},
    }, "Value", "Text", 1);

            return View();
        }

        // POST: JobVaccancies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "JobID,JobTitle,CountryId,JobAreaId,JobLocation,CompanyName,EmploymentType,MonthlySalary,Benefits,MinimumWorkExperience,MinimumEducationLevel,ListedBy,CompanySize,CareerLevel,Description,Skills,EmailID,ContactPerson,PhoneNumber,Country,JobCategory,PostedDate,LasteDate,IsActive")] JobVaccancy jobVaccancy)
        {
            if (ModelState.IsValid)
            {
                db.JobVaccancys.Add(jobVaccancy);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CountryId = new SelectList(db.CountryMasters, "CountryId", "CountryName", jobVaccancy.CountryId);
            ViewBag.JobAreaId = new SelectList(db.JobFieldAreas, "JobAreaId", "JobAreaName", jobVaccancy.JobAreaId);
            return View(jobVaccancy);
        }

        // GET: JobVaccancies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobVaccancy jobVaccancy = await db.JobVaccancys.FindAsync(id);
            if (jobVaccancy == null)
            {
                return HttpNotFound();
            }
            ViewBag.CountryId = new SelectList(db.CountryMasters, "CountryId", "CountryName", jobVaccancy.CountryId);
            ViewBag.JobAreaId = new SelectList(db.JobFieldAreas, "JobAreaId", "JobAreaName", jobVaccancy.JobAreaId);
            return View(jobVaccancy);
        }

        // POST: JobVaccancies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "JobID,JobTitle,CountryId,JobAreaId,JobLocation,CompanyName,EmploymentType,MonthlySalary,Benefits,MinimumWorkExperience,MinimumEducationLevel,ListedBy,CompanySize,CareerLevel,Description,Skills,EmailID,ContactPerson,PhoneNumber,Country,JobCategory,PostedDate,LasteDate,IsActive")] JobVaccancy jobVaccancy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobVaccancy).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CountryId = new SelectList(db.CountryMasters, "CountryId", "CountryName", jobVaccancy.CountryId);
            ViewBag.JobAreaId = new SelectList(db.JobFieldAreas, "JobAreaId", "JobAreaName", jobVaccancy.JobAreaId);
            return View(jobVaccancy);
        }

        // GET: JobVaccancies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobVaccancy jobVaccancy = await db.JobVaccancys.FindAsync(id);
            if (jobVaccancy == null)
            {
                return HttpNotFound();
            }
            return View(jobVaccancy);
        }

        // POST: JobVaccancies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            JobVaccancy jobVaccancy = await db.JobVaccancys.FindAsync(id);
            db.JobVaccancys.Remove(jobVaccancy);
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
