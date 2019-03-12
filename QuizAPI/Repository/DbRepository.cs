using QuizAPI.Models;
using QuizAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizAPI.Repository
{
    class DbRepository
    {
    }

    public static class QuestionRepository
    {
        public static QuizContext cntxt = new QuizContext();

        public static List<QuestionViewModel> GetQuestion()
        {
            //  List<Question> questions = cntxt.Questions.ToList();


            var q = (from qst in cntxt.Questions
                     select new QuestionViewModel
                     {
                         QuestionId = qst.QuestionId,
                         FullQuestion = qst.FullQuestion,
                         AnswerOption1 = qst.AnswerOption1,
                         AnswerOption2 = qst.AnswerOption2,
                         AnswerOption3 = qst.AnswerOption3,
                         AnswerOption4 = qst.AnswerOption4,
                         CorrectAnswer = qst.CorrectAnswerIndex,
                         UserAnswer = "",
                         isCorrect = "",
                         Mark = qst.Mark,
                         AreaofKnowledge = qst.AreaofKnowledge,
                         AnswerExplanation = qst.AnswerExplanation
                     }).ToList();

            return q;
        }

        public static List<QuestionViewModel> GetQuestionofExamofLanguage(int CertificationId, int LanguageId)
        {
            //  List<Question> questions = cntxt.Questions.ToList();


            var q = (from qst in cntxt.Questions
                     where qst.LanguageId == LanguageId && qst.CertificationId == CertificationId
                     select new QuestionViewModel
                     {
                         QuestionId = qst.QuestionId,
                         FullQuestion = qst.FullQuestion,
                         AnswerOption1 = qst.AnswerOption1,
                         AnswerOption2 = qst.AnswerOption2,
                         AnswerOption3 = qst.AnswerOption3,
                         AnswerOption4 = qst.AnswerOption4,
                         CorrectAnswer = qst.CorrectAnswerIndex,
                         UserAnswer = "",
                         isCorrect = "",
                         Mark = qst.Mark,
                         AreaofKnowledge = qst.KnowledgeArea.KnowledgeAreaName,
                         AnswerExplanation = qst.AnswerExplanation
                     }).ToList();

            return q;
        }

        public static Question GetQuestion(int Quid)
        {
            Question question = cntxt.Questions.Where(u => u.QuestionId == Quid).FirstOrDefault();

            return question;
        }


        /// <summary>
        /// Get Specified number of Questions of Certification
        /// </summary>
        /// <param name="numberofQuestion"></param>
        /// <param name="certificationId"></param>
        /// <param name="LanguageId"></param>
        /// <returns></returns>
        public static List<QuestionViewModel> GetNumberofQuestionQuestion(int numberofQuestion, int certificationId, int LanguageId)
        {
            //  List<Question> questions = cntxt.Questions.ToList();


            var q = (from qst in cntxt.Questions
                     where qst.LanguageId == LanguageId && qst.CertificationId == certificationId
                     select new QuestionViewModel
                     {
                         QuestionId = qst.QuestionId,
                         FullQuestion = qst.FullQuestion,
                         AnswerOption1 = qst.AnswerOption1.Trim(),
                         AnswerOption2 = qst.AnswerOption2.Trim(),
                         AnswerOption3 = qst.AnswerOption3.Trim(),
                         AnswerOption4 = qst.AnswerOption4.Trim(),
                         CorrectAnswer = qst.CorrectAnswerIndex.Trim(),
                         UserAnswer = "",
                         isCorrect = "",
                         Mark = qst.Mark,
                         AreaofKnowledge = qst.KnowledgeArea.KnowledgeAreaName,
                         AnswerExplanation = qst.AnswerExplanation.ToString() + "/" + qst.AreaofKnowledge.ToString()
                     }).OrderBy(a => Guid.NewGuid()).Take(numberofQuestion).ToList();






            foreach (var element in q)
            {
                Random random = new Random();
                var numbers = Enumerable.Range(0, 4);

                String[] Answers = new String[4] { element.AnswerOption1, element.AnswerOption2, element.AnswerOption3, element.AnswerOption4 };


                int[] shuffle = numbers.OrderBy(a => random.NextDouble()).ToArray();

                element.AnswerOption1 = Answers[shuffle[0]];
                element.AnswerOption2 = Answers[shuffle[1]];
                element.AnswerOption3 = Answers[shuffle[2]];
                element.AnswerOption4 = Answers[shuffle[3]];




            }





            return q;
        }



        /// <summary>
        /// Get Specified number of Questions of Exam
        /// </summary>
        /// <param name="numberofQuestion"></param>
        /// <param name="examId"></param>
        /// <param name="LanguageId"></param>
        /// <returns></returns>
        public static List<QuestionViewModel> GetNumberofQuestionQuestionofExam(int numberofQuestion, int examId, int LanguageId)
        {
            //  List<Question> questions = cntxt.Questions.ToList();


            var q = (from qst in cntxt.Questions
                     where qst.LanguageId == LanguageId && qst.ExamId == examId
                     select new QuestionViewModel
                     {
                         QuestionId = qst.QuestionId,
                         FullQuestion = qst.FullQuestion,
                         AnswerOption1 = qst.AnswerOption1.Trim(),
                         AnswerOption2 = qst.AnswerOption2.Trim(),
                         AnswerOption3 = qst.AnswerOption3.Trim(),
                         AnswerOption4 = qst.AnswerOption4.Trim(),
                         CorrectAnswer = qst.CorrectAnswerIndex.Trim(),
                         UserAnswer = "",
                         isCorrect = "",
                         Mark = qst.Mark,
                         AreaofKnowledge = qst.KnowledgeArea.KnowledgeAreaName,
                         AnswerExplanation = qst.AnswerExplanation.ToString() + "/" + qst.AreaofKnowledge.ToString()
                     }).OrderBy(a => Guid.NewGuid()).Take(numberofQuestion).ToList();






            foreach (var element in q)
            {
                Random random = new Random();
                var numbers = Enumerable.Range(0, 4);

                String[] Answers = new String[4] { element.AnswerOption1, element.AnswerOption2, element.AnswerOption3, element.AnswerOption4 };
                int[] shuffle = numbers.OrderBy(a => random.NextDouble()).ToArray();
                element.AnswerOption1 = Answers[shuffle[0]];
                element.AnswerOption2 = Answers[shuffle[1]];
                element.AnswerOption3 = Answers[shuffle[2]];
                element.AnswerOption4 = Answers[shuffle[3]];

            }





            return q;
        }








        public static List<QuestionViewModel> GetNumberofQuestionQuestion(int numberofQuestion, int certificationId, int knowledgeAreaID, int LanguageId)
        {
            //  List<Question> questions = cntxt.Questions.ToList();


            var q = (from qst in cntxt.Questions
                     where qst.LanguageId == LanguageId && qst.CertificationId == certificationId && qst.KnowledgeAreaId == knowledgeAreaID
                     select new QuestionViewModel
                     {
                         QuestionId = qst.QuestionId,
                         FullQuestion = qst.FullQuestion,
                         AnswerOption1 = qst.AnswerOption1.Trim(),
                         AnswerOption2 = qst.AnswerOption2.Trim(),
                         AnswerOption3 = qst.AnswerOption3.Trim(),
                         AnswerOption4 = qst.AnswerOption4.Trim(),
                         CorrectAnswer = qst.CorrectAnswerIndex.Trim(),
                         UserAnswer = "",
                         isCorrect = "",
                         Mark = qst.Mark,
                         AreaofKnowledge = qst.KnowledgeArea.KnowledgeAreaName,
                         AnswerExplanation = qst.AnswerExplanation.ToString() + "/" + qst.AreaofKnowledge.ToString()
                     }).OrderBy(a => Guid.NewGuid()).Take(numberofQuestion).ToList();






            foreach (var element in q)
            {
                Random random = new Random();
                var numbers = Enumerable.Range(0, 4);

                String[] Answers = new String[4] { element.AnswerOption1, element.AnswerOption2, element.AnswerOption3, element.AnswerOption4 };


                int[] shuffle = numbers.OrderBy(a => random.NextDouble()).ToArray();

                element.AnswerOption1 = Answers[shuffle[0]];
                element.AnswerOption2 = Answers[shuffle[1]];
                element.AnswerOption3 = Answers[shuffle[2]];
                element.AnswerOption4 = Answers[shuffle[3]];




            }





            return q;
        }




      


        public static List<QuestionViewModel> GetNumberofQuestionByPreviousExam(int numberofQuestion, String Exam = "")
        {
            //  List<Question> questions = cntxt.Questions.ToList();


            var q = (from qst in cntxt.Questions
                     where qst.AreaofKnowledge == Exam
                     select new QuestionViewModel
                     {
                         QuestionId = qst.QuestionId,
                         FullQuestion = qst.FullQuestion,
                         AnswerOption1 = qst.AnswerOption1.Trim(),
                         AnswerOption2 = qst.AnswerOption2.Trim(),
                         AnswerOption3 = qst.AnswerOption3.Trim(),
                         AnswerOption4 = qst.AnswerOption4.Trim(),
                         CorrectAnswer = qst.CorrectAnswerIndex.Trim(),
                         UserAnswer = "",
                         isCorrect = "",
                         Mark = qst.Mark,
                         AreaofKnowledge = qst.KnowledgeArea.KnowledgeAreaName,
                         AnswerExplanation = qst.AnswerExplanation.ToString() + "/" + qst.AreaofKnowledge.ToString()
                     }).OrderBy(a => Guid.NewGuid()).Take(numberofQuestion).ToList();






            foreach (var element in q)
            {
                Random random = new Random();
                var numbers = Enumerable.Range(0, 4);

                String[] Answers = new String[4] { element.AnswerOption1, element.AnswerOption2, element.AnswerOption3, element.AnswerOption4 };


                int[] shuffle = numbers.OrderBy(a => random.NextDouble()).ToArray();

                element.AnswerOption1 = Answers[shuffle[0]];
                element.AnswerOption2 = Answers[shuffle[1]];
                element.AnswerOption3 = Answers[shuffle[2]];
                element.AnswerOption4 = Answers[shuffle[3]];




            }





            return q;
        }




        public static List<QuestionViewModel> GetSingleQuestion(int QuestionID  )
        {
            //  List<Question> questions = cntxt.Questions.ToList();


            var q = (from qst in cntxt.Questions
                     where qst.QuestionId == QuestionID
                     select new QuestionViewModel
                     {
                         QuestionId = qst.QuestionId,
                         FullQuestion = qst.FullQuestion,
                         AnswerOption1 = qst.AnswerOption1.Trim(),
                         AnswerOption2 = qst.AnswerOption2.Trim(),
                         AnswerOption3 = qst.AnswerOption3.Trim(),
                         AnswerOption4 = qst.AnswerOption4.Trim(),
                         CorrectAnswer = qst.CorrectAnswerIndex.Trim(),
                         UserAnswer = "",
                         isCorrect = "",
                         Mark = qst.Mark,
                         AreaofKnowledge = qst.KnowledgeArea.KnowledgeAreaName,
                         AnswerExplanation = qst.AnswerExplanation.ToString() + "/" + qst.AreaofKnowledge.ToString()
                     }).ToList();






            foreach (var element in q)
            {
                Random random = new Random();
                var numbers = Enumerable.Range(0, 4);

                String[] Answers = new String[4] { element.AnswerOption1, element.AnswerOption2, element.AnswerOption3, element.AnswerOption4 };


                int[] shuffle = numbers.OrderBy(a => random.NextDouble()).ToArray();

                element.AnswerOption1 = Answers[shuffle[0]];
                element.AnswerOption2 = Answers[shuffle[1]];
                element.AnswerOption3 = Answers[shuffle[2]];
                element.AnswerOption4 = Answers[shuffle[3]];




            }





            return q;
        }


        public static List<KnowledgeViewModel> AreaofKnowledge()
        {
            List<KnowledgeViewModel> knowledgeViewModels = new List<KnowledgeViewModel>();

            var ast = cntxt.Questions.Select(u => new { u.LanguageId, u.CertificationId, u.KnowledgeAreaId, u.KnowledgeArea.Certification.CertificationName, u.KnowledgeArea.KnowledgeAreaName, u.LanguageMaster.LanguageName }).Distinct();


            foreach (var element in ast)
            {

                KnowledgeViewModel knwledgemdl = new KnowledgeViewModel();

                knwledgemdl.CertificationId = element.CertificationId;
                knwledgemdl.KnowledgeAreaId = element.KnowledgeAreaId;
                knwledgemdl.KnowledgeAreaName = element.KnowledgeAreaName;
                knwledgemdl.LanguageName = element.LanguageName;

                knowledgeViewModels.Add(knwledgemdl);
            }


            return knowledgeViewModels;
        }



        public static List<string> getOldQuestionPaperName(int certificationid)
        {

            var val = cntxt.Questions.Where(u => u.CertificationId == certificationid).Select(u => u.AreaofKnowledge).Distinct().ToList();

            return val;
        }

    }


    public static class CertificationRepository
    {
        public static QuizContext cntxt = new QuizContext();

        public static void InsertCertification(Certification cert)
        {

            cntxt.Certifications.Add(cert);
            cntxt.SaveChanges();
        }

        public static List<CertificationNames> GetAllCertifications()
        {
            List<CertificationNames> certificationNames = cntxt.Certifications.Select(cert => new CertificationNames { CertificationID = cert.CertificationId, Certificationname = cert.CertificationName }).ToList();

            return certificationNames;
        }
    }


    public static class KnowledgeAreaRepository
    {
        public static QuizContext cntxt = new QuizContext();

        public static void InsertKnowledgeArea(KnowledgeArea knowledgeArea)
        {

            cntxt.KnowledgeAreas.Add(knowledgeArea);
            cntxt.SaveChanges();
        }

        public static List<KnowledgeAreaNames> GetAllknowledgeArea()
        {
            List<KnowledgeAreaNames> knowledgeAreaNames = cntxt.KnowledgeAreas.Select(cert => new KnowledgeAreaNames { KnowledgeAreaname = cert.KnowledgeAreaName, KnowledgeAreaID = cert.KnowledgeAreaId }).ToList();

            return knowledgeAreaNames;
        }

        public static List<KnowledgeArea> GetAllknowledgeAreaOfCertification(int CertificationID)
        {
            List<KnowledgeArea> knowledgeAreaNames = cntxt.KnowledgeAreas.Where(x => x.CertificationId == CertificationID).ToList();

            return knowledgeAreaNames;
        }
    }




    public static class QuestionPercentageRepository
    {
        public static QuizContext cntxt = new QuizContext();



        public static List<QuestionViewModel> GetTestExamQuestions(int examid, int numberofQuestion, int languageid)
        {

            List<QuestionViewModel> MainList = new List<QuestionViewModel>();
            var q = cntxt.QuestionPercentageDetails.Where(x => x.ExamId == examid);



            foreach (var element in q)
            {

                decimal percent = decimal.Parse(element.TotalPercentage.ToString());

                int questionnumbers = Convert.ToInt32((percent / 100) * numberofQuestion);

                List<QuestionViewModel> lst = new List<QuestionViewModel>();
                lst = QuestionRepository.GetNumberofQuestionQuestionofExam(questionnumbers, examid, examid);

                foreach (QuestionViewModel qmodel in lst)
                {

                    MainList.Add(qmodel);

                }


            }
            return MainList;
        }


        //public static QuestionPercentage GetQuestionPercentage(int CertificationID)
        //{
        //    QuestionPercentage questionPercentage = null;
        //    try
        //    {
        //        questionPercentage = questionPercentage = cntxt.QuestionPercentages.Where(x => x.CertificationId == CertificationID).First();
        //    }
        //    catch (Exception)
        //    {


        //    }


        //    return questionPercentage;
        //}




        //public static Decimal GetKnowledgeAreaQuestionPercentageofCertification(int questionpercentageid, int knowledgeareaid)
        //{
        //    Decimal percentage = 0;

        //    try
        //    {
        //        var q = cntxt.QuestionPercentageDetails.Where(x => x.QuestionPercentageId == questionpercentageid && x.KnowledgeAreaId == knowledgeareaid).First();
        //    }
        //    catch (Exception)
        //    {


        //    }

        //    return percentage;

        //}


        //public static QuestionPercentage CreateQuestionPercentage(int CertificationID)
        //{
        //    QuestionPercentage questionPercentage = null;


        //    if (CertificationID != 0)
        //    {

        //        questionPercentage = GetQuestionPercentage(CertificationID);


        //        if (questionPercentage == null)
        //        {
        //            questionPercentage = new QuestionPercentage();
        //            questionPercentage.QuestionPercentageId = 0;
        //            questionPercentage.CertificationId = CertificationID;

        //        }



        //        List<KnowledgeArea> knowledgeArealist = KnowledgeAreaRepository.GetAllknowledgeAreaOfCertification(CertificationID);

        //        foreach (KnowledgeArea element in knowledgeArealist)
        //        {

        //            if (!questionPercentage.QuestionPercentageDetails.Any(f => f.KnowledgeAreaId == element.KnowledgeAreaId))
        //            {

        //                QuestionPercentageDetail det = new QuestionPercentageDetail();
        //                det.KnowledgeAreaId = element.KnowledgeAreaId;
        //                det.KnowledgeArea = element;
        //                det.TotalPercentage = 0;

        //                questionPercentage.QuestionPercentageDetails.Add(det);
        //            }





        //        }

        //    }

        //    return questionPercentage;
        //}


        public static void InsertQuestionPercentageDetails(QuestionPercentageDetail questionPercentageDetail)
        {
            if (questionPercentageDetail.QuestionPercentageDetailId != 0)
            {







            }

            else
            {


                cntxt.QuestionPercentageDetails.Add(questionPercentageDetail);
                cntxt.SaveChanges();





            }


        }

        public static List<Certification> GetAllCertifications()
        {
            List<Certification> certifications = cntxt.Certifications.ToList();
            return certifications;
        }
    }



}
