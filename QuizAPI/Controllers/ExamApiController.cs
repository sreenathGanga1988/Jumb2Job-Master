using QuizAPI.Models;
using QuizAPI.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace QuizAPI.Controllers
{
    public class ExamApiController : ApiController
    {
        public ExamViewModal GetExamData(int examid = 0)
        {
            ExamViewModal exammodel = new ExamViewModal();

            exammodel = ExamRepository.GetExamDetails(examid);

            return exammodel;
        }

        public ExamViewModal Post(ExamViewModal examviewmodal)
        {
            return ExamRepository.CalculateResultData(examviewmodal);
        }


        public Candidateviewmodal LoginUser(Candidateviewmodal model)
        {


            return ExamRepository.LoginUser(model);
        }
        public Candidateviewmodal RegisterUser(Candidateviewmodal model)
        {


            return ExamRepository.RegisterUser(model);
        }


    }

    public static class ExamRepository
    {
        public static ExamViewModal GetExamDetails(int examid)
        {
            ExamViewModal examviewmodal = new ExamViewModal();
            examviewmodal.QuestionSheet = new List<QuestionViewModel>();
            examviewmodal.ExamKnowledgeViewModals = new List<ExamKnowledgeViewModal>();
            examviewmodal.ToppersViewModels = new List<ToppersViewModel>();
            using (QuizContext cntxt = new QuizContext())
            {
                ExamTableMain exammain = cntxt.ExamTableMains.Find(examid);

                if (exammain != null)
                {
                    examviewmodal.MarkPerQstn = exammain.MarkPerQstn;
                    examviewmodal.NegativemarkPerQstn = exammain.NegativemarkPerQstn;
                    examviewmodal.ExamTableMainId = exammain.ExamTableMainId;
                    examviewmodal.ExamName = exammain.ExamName;
                    examviewmodal.TotalQuestion = exammain.TotalQuestion;
                    examviewmodal.ExamMinutes = exammain.ExamMinutes;
                    examviewmodal.UsedMinutes = 0;
                    examviewmodal.Cuttoff = exammain.Cuttoff;
                    if (exammain.ExamTableKnowledgeAreas.Count > 0)
                    {
                        var qpercentagecount = exammain.ExamTableKnowledgeAreas.Sum(u => u.Percentage);
                        if (int.Parse(qpercentagecount.ToString()) == 100)
                        {
                            foreach (var element in exammain.ExamTableKnowledgeAreas)
                            {
                                int xpectedqstn = ((element.Percentage * examviewmodal.TotalQuestion) / 100);
                                var tempQuestionViewModellist = GetNumberofQuestionofKnowledgeArea(xpectedqstn, examid, element.KnowledgeAreaID, exammain.LanguageId);

                                foreach (var tempelement in tempQuestionViewModellist)
                                {
                                    examviewmodal.QuestionSheet.Add(tempelement);
                                }

                                ExamKnowledgeViewModal examKnowledgeViewModal = new ExamKnowledgeViewModal();
                                examKnowledgeViewModal.KnowledgeAreaID = element.KnowledgeAreaID;
                                examKnowledgeViewModal.KnowledgeAreaName = element.KnowledgeArea.KnowledgeAreaName;
                                examKnowledgeViewModal.TotalQstn = tempQuestionViewModellist.Count;
                                examviewmodal.ExamKnowledgeViewModals.Add(examKnowledgeViewModal);
                            }
                        }
                    }
                }
            }
            try
            {
                examviewmodal.QuestionSheet.ShuffleMe();
                examviewmodal.ToppersViewModels = GetTopper(examid);

            }
            catch (Exception)
            {

                throw;
            }
            return examviewmodal;
        }

        public static List<QuestionViewModel> GetNumberofQuestionofKnowledgeArea(int numberofQuestion, int examid, int knowledgeAreaID, int LanguageId)
        {
            //  List<Question> questions = cntxt.Questions.ToList();
            using (QuizContext cntxt = new QuizContext())
            {


                var certificationid = cntxt.Exams.Where(u => u.ExamId == examid).Select(u => u.CertificationId).FirstOrDefault();



                var q = (from qst in cntxt.Questions
                         where qst.LanguageId == LanguageId && qst.CertificationId == certificationid && qst.KnowledgeAreaId == knowledgeAreaID
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
        }

        public static ExamViewModal CalculateResultData(ExamViewModal examViewModal)
        {
            int correctAnswercount = 0;
            int WrongAnswerCount = 0;
            int NoAnswerCount = 0;
            foreach (QuestionViewModel qvmodel in examViewModal.QuestionSheet)
            {
                var question = QuizAPI.Repository.QuestionRepository.GetQuestion(qvmodel.QuestionId);

                qvmodel.CorrectAnswer = question.CorrectAnswerIndex;

                int knowledgeareaid = question.KnowledgeAreaId;



                if (qvmodel.UserAnswer.Trim() == "")
                {
                    qvmodel.isCorrect = "S";
                    NoAnswerCount++;
                }
                else
                {
                    if (qvmodel.UserAnswer.Trim() == qvmodel.CorrectAnswer.Trim())
                    {
                        qvmodel.isCorrect = "Y";
                        correctAnswercount++;


                    }
                    else
                    {
                        qvmodel.isCorrect = "N";
                        WrongAnswerCount++;
                    }
                }


                var asd = from cnt in examViewModal.ExamKnowledgeViewModals
                          where cnt.KnowledgeAreaID == knowledgeareaid
                          select cnt;
                foreach (var element in asd)
                {
                    if (qvmodel.isCorrect == "Y")
                    {
                        element.CorrectAnswerCount = element.CorrectAnswerCount + 1;
                    }
                    else if (qvmodel.isCorrect == "S")
                    {
                        element.NoAnswerCount = element.NoAnswerCount + 1;
                    }
                    else if (qvmodel.isCorrect == "N")
                    {
                        element.WrongAnswersCount = element.WrongAnswersCount + 1;
                    }
                }
            }



            examViewModal.correctAnswercount = correctAnswercount;
            examViewModal.WrongAnswerCount = WrongAnswerCount;
            examViewModal.NoAnswerCount = NoAnswerCount;

            examViewModal.TotalMark = correctAnswercount * examViewModal.MarkPerQstn;
            examViewModal.Negativemark = WrongAnswerCount * examViewModal.NegativemarkPerQstn;

            examViewModal.FinalMark = examViewModal.TotalMark - examViewModal.Negativemark;





            using (QuizContext cntxt = new QuizContext())
            {

                CandidateResult canreslt = new CandidateResult();
                canreslt.CandidateId = examViewModal.Candidateviewmodal.CandidateId;
                canreslt.ExamTableMainId = examViewModal.ExamTableMainId;
                canreslt.correctAnswercount = examViewModal.correctAnswercount;
                canreslt.WrongAnswerCount = examViewModal.WrongAnswerCount;
                canreslt.NoAnswerCount = examViewModal.NoAnswerCount;
                canreslt.UsedMinutes = examViewModal.UsedMinutes;
                canreslt.TotalQuestion = examViewModal.TotalQuestion;
                canreslt.TotalMark = examViewModal.TotalMark;
                canreslt.Negativemark = examViewModal.Negativemark;
                canreslt.FinalMark = examViewModal.FinalMark;
                canreslt.ExamDate = DateTime.Now;
                cntxt.CandidateResults.Add(canreslt);
                cntxt.SaveChanges();

                foreach (ExamKnowledgeViewModal knwmdl in examViewModal.ExamKnowledgeViewModals)
                {
                    CandidateResultDetail canresltdet = new CandidateResultDetail();
                    canresltdet.CandidateResultId = canreslt.CandidateResultId;
                    canresltdet.KnowledgeAreaID = knwmdl.KnowledgeAreaID;
                    canresltdet.TotalQstn = knwmdl.TotalQstn;
                    canresltdet.WrongAnswersCount = knwmdl.WrongAnswersCount;
                    canresltdet.NoAnswerCount = knwmdl.NoAnswerCount;
                    canresltdet.CorrectAnswerCount = knwmdl.CorrectAnswerCount;
                    cntxt.CandidateResultDetails.Add(canresltdet);
                    cntxt.SaveChanges();
                }














            }









            return examViewModal;
        }

        public static Candidateviewmodal RegisterUser(Candidateviewmodal model)
        {
            using (QuizContext cntxt = new QuizContext())
            {

                if (!cntxt.Candidates.Any(o => o.CandidateName == model.CandidateName))
                {

                    Candidate cndate = new Candidate();
                    cndate.CandidateName = model.CandidateName;
                    cndate.Password = model.Password;
                    cndate.CandidateEmail = model.EmailID;
                    cndate.AddedDate = DateTime.Now;
                    cntxt.Candidates.Add(cndate);
                    cntxt.SaveChanges();
                    CandidateLogin cndlog = new CandidateLogin();
                    cndlog.CandidateId = cndate.CandidateId;
                    cndlog.LogDate = DateTime.Now;
                    cntxt.CandidateLogins.Add(cndlog);

                    cntxt.SaveChanges();
                    model.isValidUser = true;
                    model.LoginMessage = "Candidate Sucessfully Added";
                    model.isValidUser = true;
                    model.CandidateId = model.CandidateId;

                }
                else
                {
                    model.isValidUser = false;
                    model.LoginMessage = "User Name Already Used;Try another name ";

                }

            }

            return model;
        }


        public static Candidateviewmodal LoginUser(Candidateviewmodal model)
        {
            model.isValidUser = false;
            model.LoginMessage = "Wrong Username or password ";
            using (QuizContext cntxt = new QuizContext())
            {

                var q = from can in cntxt.Candidates
                        where can.CandidateName == model.CandidateName && can.Password == model.Password
                        select can;
                foreach (var element in q)
                {
                    CandidateLogin cndlog = new CandidateLogin();
                    cndlog.CandidateId = element.CandidateId;
                    cndlog.LogDate = DateTime.Now;
                    cntxt.CandidateLogins.Add(cndlog);
                    model.isValidUser = true;
                    model.LoginMessage = "Candidate Sucessfully Added";
                    model.isValidUser = true;
                    model.CandidateId = element.CandidateId;
                }




                cntxt.SaveChanges();

            }

            return model;
        }


        public static void ShuffleMe<T>(this IList<T> list)
        {
            Random random = new Random();
            int n = list.Count;

            for (int i = list.Count - 1; i > 1; i--)
            {
                int rnd = random.Next(i + 1);

                T value = list[rnd];
                list[rnd] = list[i];
                list[i] = value;
            }
        }






        public static List<ToppersViewModel> GetTopper(int examid)
        {
           


            List<ToppersViewModel> ToppersViewModellist = new List<ToppersViewModel>();
            using (QuizContext cntxt = new QuizContext())
            {
                
                var q = cntxt.CandidateResults.Where(u => u.FinalMark >= u.ExamTableMain.Cuttoff).OrderByDescending(u => u.FinalMark).Take(100);

                foreach (CandidateResult element in q)
                {

                    var can = cntxt.Candidates.Where(u => u.CandidateId == element.CandidateId).FirstOrDefault();
                    string username = "";
                    if (can != null)
                    {
                        username = can.CandidateName;

                    }

                    ToppersViewModel toppersViewModel = new ToppersViewModel();
                    toppersViewModel.UserName = username;
                    toppersViewModel.FinalMark = element.FinalMark;
                    toppersViewModel.ExamDate = element.ExamDate;
                    ToppersViewModellist.Add(toppersViewModel);
                }
                                                          
            }
            return ToppersViewModellist;
        }




    }









    public class ToppersViewModel
    {

        public String UserName { get; set; }
        public int correctAnswercount { get; set; }
        public int WrongAnswerCount { get; set; }
        public int NoAnswerCount { get; set; }
        public int UsedMinutes { get; set; }
        public Decimal FinalMark { get; set; }
        public DateTime ExamDate { get; set; }
        public int Nooftries { get; set; }

    }




    public class ExamViewModal
    {
        public int UserId { get; set; }
        public String UserName { get; set; }

        public int ExamTableMainId { get; set; }
        public String ExamName { get; set; }

        public int ExamMinutes { get; set; }

        public int correctAnswercount { get; set; }
        public int WrongAnswerCount { get; set; }
        public int NoAnswerCount { get; set; }
        public int UsedMinutes { get; set; }

        public int TotalQuestion { get; set; }
        public Decimal TotalMark { get; set; }
        public Decimal Negativemark { get; set; }
        public Decimal FinalMark { get; set; }

        public List<QuestionViewModel> QuestionSheet { get; set; }
        public List<ExamKnowledgeViewModal> ExamKnowledgeViewModals { get; set; }
        public List<ToppersViewModel> ToppersViewModels { get; set; }

        public Candidateviewmodal Candidateviewmodal { get; set; }
        public Decimal MarkPerQstn { get; set; }
        public Decimal NegativemarkPerQstn { get; set; }

        public int Cuttoff { get; set; }
    }

    public class ExamKnowledgeViewModal
    {
        public int KnowledgeAreaID { get; set; }
        public String KnowledgeAreaName { get; set; }
        public int TotalQstn { get; set; }
        public int WrongAnswersCount { get; set; }
        public int NoAnswerCount { get; set; }
        public int CorrectAnswerCount { get; set; }
    }

    public class Candidateviewmodal
    {
        public Candidateviewmodal()
        {
            CandidateId = 0;
            CandidateName = "Guest";
            isValidUser = false;
            LoginMessage = "";
            Password = "";
        }
        public int CandidateId { get; set; }
        public String CandidateName { get; set; }
        public String Password { get; set; }
        public String EmailID { get; set; }

        public Boolean isValidUser { get; set; }
        public String LoginMessage { get; set; }
    }

}