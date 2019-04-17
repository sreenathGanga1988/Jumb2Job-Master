using QuizAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Areas.OnlineTest.Controllers
{
    public class TestController : Controller
    {
        // GET: OnlineTest/Test
        public ActionResult Index()
        {
            return View();
        }







       
        public ActionResult TestEngine()
        {
            ViewBag.Heading = "Free PSC Sample Exam Online ";
            ViewBag.Title = "Free Online PSC Exam Engine -Try Previous PSC Question in Exam format";
            ViewBag.MetaDescription = "Real Kerala PSC Mock Exam. Try 100 Questions each,Free PSC Sample Questions";
            ViewBag.MetaKeywords = "Free English General Knowledge,Kerala PSC Questions,Practise GK Questions,University Assistant Exam-Questions;Free PSC  Mock Exam ,Free PSC ";



            return View();
        }


        public ActionResult ResultEngine(ExamViewModal examviewmodal)
        {
            return View();
        }
    }



}