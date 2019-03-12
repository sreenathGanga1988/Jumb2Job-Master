using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Controllers
{
    public class HRInterviewController : Controller
    {
        // GET: HRInterview
        [Route("Preparing-for-Interview-Successfully")]
        public ActionResult PreparingforInterview()
        {
            ViewBag.Title = "Preparing for Interview steps";
            ViewBag.MetaDescription = "Prepare yourSelf for an interview;prepare yourself and be confident before interview,overcome interview fear ";
            ViewBag.MetaKeywords = "prepare for interview ,hack Interview,overcome interview fear";
            return View();
        }

        // GET: HRInterview/InterviewDoesandDont
        [Route("HRInterview/InterviewDoesandDont")]
        [Route("Interview-Does-and-Dont")]
        public ActionResult InterviewDoesandDont()
        {
            ViewBag.Title = "Dos and Dont Does of Interview";
            ViewBag.MetaDescription = "Thing to be avoided in an  interview and those to be included  in interview ";
            ViewBag.MetaKeywords = "Dos and Dont Does of Interview ,Avoid interview ,dont do in inbterview";


            return View();
        }

        [Route("Common-HR-Interview-Questions")]
        [Route("HRInterview/CommonHRQuestions")]
        public ActionResult CommonHRQuestions()
        {
            ViewBag.Title = "Common Questions asked in HR Interview";
            ViewBag.MetaDescription = "Most Common Hr Interview Questions,Like Tell me About yourSelf,Strength,Weekness, Professional Growth,Why do i hire you ";
            ViewBag.MetaKeywords = "Careers, Leadership, Lifestyle, ask, Canada, candidate, career, common questions, employee, employer, Employment, Glassdoor, Google, interview, interviewer,  job, Job interview, job seeker, prepare, Question, uncommon questions, Work, YouTube";









            return View();
        }


        public ActionResult HrInterviewTips()
        {
            return View();
        }
    }
}