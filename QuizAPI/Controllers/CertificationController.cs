using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Controllers
{
    public class CertificationController : Controller
    {
        // GET: Certification
        public ActionResult Index()
        {
            ViewBag.Heading = "Free Online Certifcation Sample Questions-Mock Exam";
            return View();
        }
        [Route("Certification/SamplePMPQuestion")]
        [Route("Free-Sample-PMP-Questions-PMBOK6")]
        public ActionResult SamplePMPQuestion()
        {
            ViewBag.Title = "Sample PMP Questions Based on PMBOK6";
            ViewBag.MetaDescription = "Free Sample PMP Questions Based on PMBOK6 ,PmBook Edition 6 PMP Questions ";
            ViewBag.MetaKeywords = "Free PmBook6 Sample Questions,Sample PMP Questions ";
            ViewBag.Heading = "Free PMP Sample Questions";

            ViewBag.uri = "/api/pmp/GetQuestion";
            ViewBag.param = "{ certificationId:1, languageID: 1, Number: 15 }";
            return View();

        }



        [Route("Certification/PMPMockTest")]
        [Route("Free-Sample-PMP-Mock-Exam")]
        public ActionResult PMPMockTest()
        {

            ViewBag.Title = "Sample PMP Exam Based on PMBOK6-Stimulator";
            ViewBag.MetaDescription = "Free Sample PMP Exam Based on PMBOK6 ,PmBook Edition 6 PMP Stimulator Questions ";
            ViewBag.MetaKeywords = "Free PmBook6 Sample Questions,Sample PMP Mock Exam,Free PMP Stimulator ";
            ViewBag.Heading = "Free PMP Mock Exam";

            ViewBag.uri = "/api/pmp/GetQuestion";
            ViewBag.param = "{ certificationId:1, languageID: 1, Number: 15 }";

            return View();
        }



        public ActionResult MicrosoftCertifications()
        {
            return View();
        }

        public ActionResult MCSDQuestions()
        {
            return View();
        }
        [Route("Certification/MCSD70480HtmlandJavascript")]
        [Route("Free-MCSD-70-480-Html-and-Javascript-Sample Questions")]
        public ActionResult MCSD70480HtmlandJavascript()
        {

            ViewBag.Title = "Free 70-480 Exam Questions and Answers";
            ViewBag.MetaDescription = "Get  real exam questions for 70-480 Programming in HTML5 with JavaScript and CSS3. Access online the  get ready for the test. ";
            ViewBag.MetaKeywords = "MCSD -70-480 Questions,Free Mirosoft certification Questions, ";

            ViewBag.Heading = "MCSD- Exam ref70-480 (Html5 and Javascript) Free Sample Questions";

            ViewBag.uri = "/api/pmp/GetQuestionofKnowledgeArea";
            ViewBag.param = "{ certificationId: 4, languageID: 1, knowledgeAeadid: 1, Number: 30 }";

            return View();
        }



        [Route("Certification/DHASampleQuestionForNurses")]
        [Route("Fdha-exam-sample-questions-for-nurses")]
        public ActionResult DHASampleQuestionForNurses()
        {

            ViewBag.Title = "Free dha exam sample questions for nurses";
            ViewBag.MetaDescription = "DHA Question Paper-Explanations and Answer for Nurse .Here Frequently Asked Questions  moh and had Licencing exams";
            ViewBag.MetaKeywords = "MCSD -70-480 Questions,Free Mirosoft certification Questions, ";

            ViewBag.Heading = " Frequently asked dha exam sample questions for nurses free";

            ViewBag.uri = "/api/pmp/GetQuestionofKnowledgeArea";
            ViewBag.param = "{ certificationId: 4, languageID: 1, knowledgeAeadid: 1, Number: 30 }";

            return View();
        }






    }
}