using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuizAPI.Models.ViewModel
{
    public class QuizViewModel
    {

    }
    public class CertificationNames
    {
        public int CertificationID { get; set; }
        public String Certificationname { get; set; }
    }
    public class KnowledgeAreaNames
    {
        public int KnowledgeAreaID { get; set; }
        public String KnowledgeAreaname { get; set; }
    }
    public class CertificationQuestionPercentageDetails
    {
        public int KnowledgeAreadID { get; set; }
        public String KnowkledgeAreaName { get; set; }
        public Decimal Percentage { get; set; }
    }

    public class QuestionViewModel
    {

        public int QuestionId { get; set; }
        public int CertificationId { get; set; }
        public string FullQuestion { get; set; }
        public string AnswerOption1 { get; set; }
        public string AnswerOption2 { get; set; }
        public string AnswerOption3 { get; set; }
        public string AnswerOption4 { get; set; }
        public string CorrectAnswer { get; set; }
        public string UserAnswer { get; set; }
        public string isCorrect { get; set; }

        public int? Mark { get; set; }
        public string AreaofKnowledge { get; set; }
        public string AnswerExplanation { get; set; }


    }

    public class KnowledgeViewModel
    {
        public int CertificationId { get; set; }
        public int KnowledgeAreaId { get; set; }
        public int LanguageId { get; set; }
        public string LanguageName { get; set; }
        public string KnowledgeAreaName { get; set; }
        public string KnowledgeDisplaynameName { get; set; }


    }




    public class ExamResultViewModel
    {
        public List<QuestionViewModel> QuestionViewModels { get; set; }
        public List<ResultKnowledgeAreaViewModel> ResultKnowledgeAreaViewModels { get; set; }

    }

    public class ResultKnowledgeAreaViewModel
    {
        public string KnowledgeAreaName { get; set; }
        public int QuestionsAsked { get; set; }
        public int QuestionsCorrect { get; set; }
        public int QuestionsWrong { get; set; }
        public int QuestionsSkipped { get; set; }

    }



}