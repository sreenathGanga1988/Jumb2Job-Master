using QuizAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace QuizAPI.Controllers
{

    public class PMPController : ApiController
    {
        public List<QuestionViewModel> Get()
        {

            //List<string> List = new List<string>();
            //List.Add("sourav kayal");
            //List.Add("Ajay Joshi");
            //List.Add("Nontey Banerjee");
            //return List;

            return QuizAPI.Repository.QuestionRepository.GetQuestion();
        }

        public List<QuestionViewModel> GetQuestion(int certificationId = 0, int languageID = 0, int Number = 0)
        {
            return QuizAPI.Repository.QuestionRepository.GetNumberofQuestionQuestion(Number, certificationId, languageID);
        }

        public List<QuestionViewModel> GetQuestionofExam(int examId = 0, int languageID = 0, int Number = 0)
        {
            return QuizAPI.Repository.QuestionRepository.GetNumberofQuestionQuestionofExam(Number, examId, languageID);
        }



        public List<QuestionViewModel> GetQuestionofKnowledgeArea(int certificationId = 0, int languageID = 0, int knowledgeAeadid = 0, int Number = 0)
        {
            return QuizAPI.Repository.QuestionRepository.GetNumberofQuestionQuestion(Number, certificationId, languageID);
        }


        public List<QuestionViewModel> GetSingleQuestion(int QuestionID = 0, int certificationId = 0, int languageID = 0)
        {
            if (QuestionID==0) {
                if (certificationId != 0 && languageID !=0)
                {
                    return QuizAPI.Repository.QuestionRepository.GetNumberofQuestionQuestion(1, certificationId,languageID); 
                }
                }
            return QuizAPI.Repository.QuestionRepository.GetSingleQuestion(QuestionID);

        }




        public List<QuestionViewModel> GetPreviousQuestionPaper(int Number, string Exam = "")
        {
            return QuizAPI.Repository.QuestionRepository.GetNumberofQuestionByPreviousExam(Number, Exam);
        }


        public List<string> GetpreviousQuestionName(int certificationid = 0)
        {

            return QuizAPI.Repository.QuestionRepository.getOldQuestionPaperName(certificationid);


        }







        public List<QuestionViewModel> Post(List<QuestionViewModel> answerSheet)
        {
            foreach (QuestionViewModel qvmodel in answerSheet)
            {
                var question = QuizAPI.Repository.QuestionRepository.GetQuestion(qvmodel.QuestionId);

                qvmodel.CorrectAnswer = question.CorrectAnswerIndex;


                if (qvmodel.UserAnswer.Trim() == "")
                {
                    qvmodel.isCorrect = "S";
                }
                else
                {
                    if (qvmodel.UserAnswer.Trim() == qvmodel.CorrectAnswer.Trim())
                    {
                        qvmodel.isCorrect = "Y";
                    }
                    else
                    {
                        qvmodel.isCorrect = "N";

                    }
                }


            }

            return answerSheet;
        }


        public ExamResultViewModel PostTest(List<QuestionViewModel> answerSheet)
        {

            ExamResultViewModel examResultViewModel = new ExamResultViewModel();

            List<ResultKnowledgeAreaViewModel> resultKnowledgeAreaViewModellist = new List<ResultKnowledgeAreaViewModel>();

            foreach (QuestionViewModel qvmodel in answerSheet)
            {
                var question = QuizAPI.Repository.QuestionRepository.GetQuestion(qvmodel.QuestionId);

                qvmodel.CorrectAnswer = question.CorrectAnswerIndex;


                if (qvmodel.UserAnswer.Trim() == "")
                {
                    qvmodel.isCorrect = "S";
                }
                else
                {
                    if (qvmodel.UserAnswer.Trim() == qvmodel.CorrectAnswer.Trim())
                    {
                        qvmodel.isCorrect = "Y";
                    }
                    else
                    {
                        qvmodel.isCorrect = "N";

                    }
                }


            }



            var knowledgeare = answerSheet.Select(u => u.AreaofKnowledge).Distinct();

            foreach (var knw in knowledgeare)
            {

                ResultKnowledgeAreaViewModel rsk = new ResultKnowledgeAreaViewModel();

                rsk.KnowledgeAreaName = knw;

                List<QuestionViewModel> qst = answerSheet.Where(u => u.AreaofKnowledge == knw).ToList();

                int totalqstn = qst.Count();
                int correctqstn = qst.Where(u => u.isCorrect == "Y").Count();
                int wrongqstn = qst.Where(u => u.isCorrect == "N").Count();
                int skippedqstn = qst.Where(u => u.isCorrect == "S").Count();


                rsk.QuestionsAsked = totalqstn;
                rsk.QuestionsCorrect = correctqstn;
                rsk.QuestionsWrong = wrongqstn;
                rsk.QuestionsSkipped = skippedqstn;

                resultKnowledgeAreaViewModellist.Add(rsk);

            }

            examResultViewModel.QuestionViewModels = answerSheet;
            examResultViewModel.ResultKnowledgeAreaViewModels = resultKnowledgeAreaViewModellist;







            return examResultViewModel;
        }










    }
}
