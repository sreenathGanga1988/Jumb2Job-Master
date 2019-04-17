using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizAPI.Controllers
{
    public class KeralaPSCController : Controller
    {
        // GET: KeralaPSC
        public ActionResult Index()
        {
            ViewBag.Heading = "Free PSC Training Online ";
            ViewBag.Title = "Free Online PSC Training-Try Previous Question PSC Papers";
            ViewBag.MetaDescription = "Study Kerala PSC online Free,Practise  Malayalam/ English PSC Questions,General Knowledge Question in English Kerala PSC GK Questions and Answers . View PSC Questions and answers for Kerala PSC Exams, UPSC Exams, Secretariat Assistant Exams, LGS Exams LDC Exams";
            ViewBag.MetaKeywords = "Free English General Knowledge,Kerala PSC Questions,Practise GK Questions,University Assistant Exam-Questions ";




            return View();
        }


        //Full PSC
        #region

        [Route("KeralaPSC/EnglishPSCQuestions")]
        [Route("Free-English-PSC-Questions")]
        public ActionResult EnglishPSCQuestions()
        {

            ViewBag.Heading = "Free English PSC Questions ";
            ViewBag.Title = "Sample General Knowledge English PSC Questions ,Previous PSC Questions  ";
            ViewBag.MetaDescription = "Study Kerala PSC online in English,Practise  English PSC Questions,General Knowledge Question in English Kerala PSC GK Questions and Answers . View PSC Questions and answers for Kerala PSC Exams, UPSC Exams, Secretariat Assistant Exams, LGS Exams LDC Exams";
            ViewBag.MetaKeywords = "Free English General Knowledge,Kerala PSC Questions,Practise GK Questions ";
            ViewBag.footer = "To Study/Practise Kerala PSC Questions in English or Malyalam,  click here <a href=" + Url.Action("index", "KeralaPSC") + ">Free English Kerala PSC Questions</a>";


            ViewBag.uri = "/api/pmp/GetQuestion";
            ViewBag.param = "{ certificationId: 2, languageID: 1, Number: 15 }";





            return View();


        }


        [Route("KeralaPSC/PSCMalayalamQuestions")]
        [Route("Free-Malayalam-PSC-Questions")]
        public ActionResult PSCMalayalamQuestions()
        {
            ViewBag.Heading = "Free  Malayalam PSC Questions";
            ViewBag.Title = "Sample PSC General Knowledge Questions in  Malayalam,Study PSC Online";
            ViewBag.MetaDescription = "Study Kerala PSC online in Malayalam,Practise Malayalam Kerala PSC Questions,General Knowledge Question in Malayalam";
            ViewBag.MetaKeywords = "Free Malayalam General Knowledge,Best Kerala PSC Questions,Practise GK Questions in Malayalam";
            ViewBag.uri = "/api/pmp/GetQuestion";
            ViewBag.param = "{ certificationId: 2, languageID: 2, Number: 15 }";

            return View();

        }




        [Route("KeralaPSC/OnlineMalayalamPSCTest")]
        [Route("Online-Malayalam-PSC-Test")]
        public ActionResult OnlineMalayalamPSCTest()
        {
            ViewBag.Heading = "Free Online Malayalam PSC Mock Exam";
            ViewBag.Title = "Online Malyalam PSC Test";
            ViewBag.MetaDescription = "Test out your Knowledge in Malyalam PSC Question Free,Online PSC Mock Exam Test Malayalam,Try 5 Questions each Time";
            ViewBag.MetaKeywords = "Online Mock Malyalam PSC Exam, Best PSC Online Mock Test,PSC Malayalm Online Test Free";
            ViewBag.footer = "To Study/Practise Kerala PSC Questions in English or Malyalam,  click here <a href=" + Url.Action("index", "KeralaPSC") + ">Free English Kerala PSC Questions</a>";


            ViewBag.uri = "/api/pmp/GetQuestion";
            ViewBag.param = "{ certificationId: 2, languageID: 2, Number: 5 }";

            return View();
        }
        [Route("KeralaPSC/OnlineEnglishPSCTest")]
        [Route("Online-English-PSC-Test")]
        public ActionResult OnlineEnglishPSCTest()
        {
            ViewBag.Heading = "Free Online English PSC Mock Exam";
            ViewBag.Title = "Online English PSC Test";
            ViewBag.MetaDescription = "Test out your Knowledge in Malyalam PSC Question Free,Online PSC Mock Exam Test Malayalam,Try 5 Questions each Time";
            ViewBag.MetaKeywords = "Online Mock Malyalam PSC Exam, Best PSC Online Mock Test,PSC Malayalm Online Test Free";
            ViewBag.footer = "To Study/Practise Kerala PSC Questions in English or Malyalam,  click here <a href=" + Url.Action("index", "KeralaPSC") + ">Free English Kerala PSC Questions</a>";


            ViewBag.uri = "/api/pmp/GetQuestion";
            ViewBag.param = "{ certificationId: 2, languageID: 1, Number: 5 }";





            return View();
        }

        #endregion




        //University Assistant
        #region
        [Route("KeralaPSC/KeralaPSCUniversityAssistantQuestions")]
        [Route("Online-PSC-University-Assistant-Sample-Questions")]
        public ActionResult KeralaPSCUniversityAssistantQuestions()
        {
            ViewBag.Heading = "Free Online University Assistant PSC Sample Questions";
            ViewBag.Title = "Free Online University Assistant PSC Questions-Degree Level Questions,Sample Questions";
            ViewBag.MetaDescription = "Free Kerala PSC Degree level Question including previous question Paper,University Assistant ,High School Assistant ,Sales Assistant Sample Question ";
            ViewBag.MetaKeywords = "Psc Questions online,University Assistant Questions,Degree level Questions,Kerala PSC Questions, Kerala PSc Question bank";

            ViewBag.uri = "/api/pmp/GetQuestionofExam";
            ViewBag.param = "{ examId: 1, languageID: 1, Number: 15 }";
            return View();
        }



        [Route("KeralaPSC/KeralaPSCUniversityAssistantTest")]
        [Route("Online-PSC-University-Assistant-Exam")]
        public ActionResult KeralaPSCUniversityAssistantTest()
        {
            ViewBag.Heading = "Online  University Assistant PSC mock exam";
            ViewBag.Title = "Online PSC University Assistant PSC Mock Exam (Previous year Questions)";
            ViewBag.MetaDescription = "Test out your Knowledge in Malyalam PSC Question Free,Online PSC Mock Exam Test Malayalam,Try 5 Questions each Time";
            ViewBag.MetaKeywords = "Online Mock Malyalam PSC Exam, Best PSC Online Mock Test,PSC Malayalm Online Test Free";
            ViewBag.uri = "/api/pmp/GetQuestionofExam";
            ViewBag.param = "{ examId: 1, languageID: 1, Number: 5 }";
            return View();
        }




        #endregion



        //LDC
        #region

        [Route("KeralaPSC/LDCSampleQuestions")]
        [Route("Online-PSC-LDC-Sample-Questions")]
        public ActionResult LDCSampleQuestions()
        {
            ViewBag.Heading = "Free Online LDC PSC Sample Questions";
            ViewBag.Title = "Free Online LDC PSC Questions-Degree Level Questions,Sample Questions";
            ViewBag.MetaDescription = "Free Kerala LDC Question including previous question Paper,University Assistant ,High School Assistant ,Sales Assistant Sample Question ";
            ViewBag.MetaKeywords = "Psc Questions online,LDC  Questions,Degree level Questions,Kerala PSC Questions, Kerala PSc Question bank,Lower Division Clerk";

            ViewBag.uri = "/api/pmp/GetQuestionofExam";
            ViewBag.param = "{ examId: 2, languageID: 2, Number: 15 }";
            return View();
        }



        [Route("KeralaPSC/KeralaPSCLDCTest")]
        [Route("Online-PSC-LDC-Exam")]
        public ActionResult KeralaPSCLDCTest()
        {
            ViewBag.Heading = "Online LDC Kerala PSC mock exam";
            ViewBag.Title = "Online  LDC PSC Mock Exam (Previous year Questions)";
            ViewBag.MetaDescription = "Test out your Knowledge in Malyalam PSC Question Free,Online PSC Mock Exam Test Malayalam,Try 5 Questions each Time";
            ViewBag.MetaKeywords = "Online Mock Malyalam PSC Exam, Best PSC Online Mock Test,PSC Malayalm Online Test Free";
            ViewBag.uri = "/api/pmp/GetQuestionofExam";
            ViewBag.param = "{ examId: 2, languageID: 2, Number: 5 }";
            return View();
        }

        #endregion

        //LGS
        #region
        [Route("KeralaPSC/LGSSampleQuestions")]
        [Route("Online-PSC-LGS-Sample-Questions")]
        public ActionResult LGSSampleQuestions()
        {
            ViewBag.Heading = "Free Online LGS PSC Sample Questions";
            ViewBag.Title = "Free Online LGS PSC Questions-Degree Level Questions,Sample Questions";
            ViewBag.MetaDescription = "Free Kerala LGS Question including previous question Paper,University Assistant ,High School Assistant ,Sales Assistant Sample Question ";
            ViewBag.MetaKeywords = "Psc Questions online,LGS  Questions,Degree level Questions,Kerala PSC Questions, Kerala PSc Question bank,Lower Division Clerk";

            ViewBag.uri = "/api/pmp/GetQuestionofExam";
            ViewBag.param = "{ examId: 3, languageID: 2, Number: 15 }";
            return View();
        }



        [Route("KeralaPSC/KeralaPSCLGSTest")]
        [Route("Online-PSC-LGS-Exam")]
        public ActionResult KeralaPSCLGCTest()
        {
            ViewBag.Heading = "Online LGC Kerala PSC mock exam";
            ViewBag.Title = "Online  LGC PSC Mock Exam (Previous year Questions)";
            ViewBag.MetaDescription = "Test out your Knowledge in Malyalam PSC Question Free,Online PSC Mock Exam Test Malayalam,Try 5 Questions each Time";
            ViewBag.MetaKeywords = "Online Mock Malyalam PSC Exam, Best PSC Online Mock Test,PSC Malayalm Online Test Free,LGS Mock Exam";
            ViewBag.uri = "/api/pmp/GetQuestionofExam";
            ViewBag.param = "{ examId: 3, languageID: 2, Number: 5 }";
            return View();
        }


        #endregion

        //VEO
        #region
        [Route("KeralaPSC/VEOSampleQuestions")]
        [Route("Online-PSC-VEO-Sample-Questions")]
        public ActionResult VEOSampleQuestions()
        {
            ViewBag.Heading = "Free Online LGS PSC Sample Questions";
            ViewBag.Title = "Free Online LGS PSC Questions-Degree Level Questions,Sample Questions";
            ViewBag.MetaDescription = "Free Kerala LGS Question including previous question Paper,University Assistant ,High School Assistant ,Sales Assistant Sample Question ";
            ViewBag.MetaKeywords = "Psc Questions online,LGS  Questions,Degree level Questions,Kerala PSC Questions, Kerala PSc Question bank,Lower Division Clerk";

            ViewBag.uri = "/api/pmp/GetQuestionofExam";
            ViewBag.param = "{ examId: 4, languageID: 2, Number: 15 }";
            return View();
        }



        [Route("KeralaPSC/KeralaPSCVEOTest")]
        [Route("Online-PSC-VEO-Exam")]
        public ActionResult KeralaPSCVEOTest()
        {
            ViewBag.Heading = "Online VEO Kerala PSC mock exam";
            ViewBag.Title = "Online  VEO PSC Mock Exam (Previous year Questions)";
            ViewBag.MetaDescription = "Test out your Knowledge in Malyalam PSC Question Free,Online PSC Mock Exam Test Malayalam,Try 5 Questions each Time";
            ViewBag.MetaKeywords = "Online Mock Malyalam PSC Exam, Best PSC Online Mock Test,PSC Malayalm Online Test Free,LGS Mock Exam";
            ViewBag.uri = "/api/pmp/GetQuestionofExam";
            ViewBag.param = "{ examId: 4, languageID: 2, Number: 5 }";
            return View();
        }


        #endregion



        public ActionResult QuestionDetails(int id = 0,int certificationId = 0, int languageID = 0)
        {
            ViewBag.QuestionID = id;
            ViewBag.Heading = "";
            ViewBag.Title = "";
            ViewBag.MetaDescription = "";
            ViewBag.MetaKeywords = "";
            ViewBag.uri = "/api/pmp/GetSingleQuestion";
            ViewBag.param = "{ QuestionID: " + id.ToString() + ",certificationId: 2, languageID: 2 }";



            return View();
        }
        public ActionResult Questions(int certificationId = 0, int languageID = 0, int knowledgeAeadid = 0, int Number = 0)
        {
            ViewBag.uri = "/api/pmp/GetQuestionofKnowledgeArea";
            ViewBag.param = "{ certificationId: " + certificationId + ", languageID:  " + languageID + ", knowledgeAeadid:  " + knowledgeAeadid + ",  Number:  " + Number + "}";


            return View();
        }


        public ActionResult PreviousQuestions(String exam = "", int Number = 15)
        {
            ViewBag.Title = exam + " Exam  Questions ,Kerala PSC";
            ViewBag.MetaDescription = exam + " Exam  Questions - Kerala PSC-Old Question";
            ViewBag.MetaKeywords = exam + " Exam  Questions,Kerala PSC-Old Question-" + exam + "";
            ViewBag.Heading = exam + " Exam  Questions";
            ViewBag.uri = "/api/pmp/GetPreviousQuestionPaper";

            ViewBag.param = "{ Number:  " + Number + ",Exam:\'" + exam + "\'}";

            return View();
        }
        public ActionResult PreviousQuestionMock(String exam = "", int Number = 5)
        {


            ViewBag.Title = "";
            ViewBag.MetaDescription = "";
            ViewBag.MetaKeywords = "";

            ViewBag.Heading = exam + " Exam Online ";
            ViewBag.uri = "/api/pmp/GetPreviousQuestionPaper";

            ViewBag.param = "{ Number:  " + Number + ",Exam:\"1\"}";

            return View();
        }




        public ActionResult PSCNotes(int Id = 1)
        {

            var q = TopicNotesRepo.getTopicmasterdata(Id);

            ViewBag.Title = q.TopicName + " Questions";
            ViewBag.MetaDescription = q.TopicDescription + " Questions";
            ViewBag.MetaKeywords = q.TopicName + "," + q.TopicDescription + "free online PSC Questions";

            ViewBag.Heading = q.TopicName + " Questions  Online ";
            ViewBag.uri = "/api/TopicNotesDataApi/get?id=" + Id + "";

            ViewBag.param = "{ id:  " + Id + " }";
            return View();
        }


    }
}