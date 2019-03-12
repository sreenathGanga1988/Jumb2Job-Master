using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
namespace QuizAPI.Models
{
    public class LanguageMaster
    {
        [Key]
        public int LanguageId { get; set; }
        [Required(ErrorMessage = "Enter Correct Language")]
        [Display(Name = "Language Name")]
        public string LanguageName { get; set; }
        public virtual List<Question> Questions { get; set; }
    }


    public class Certification
    {
        [Key]
        public int CertificationId { get; set; }
        [Display(Name = "Certification Name")]
        public string CertificationName { get; set; }
        public virtual List<KnowledgeArea> KnowlwdgeAreas { get; set; }
        public virtual List<Question> Questions { get; set; }

    }
    public class Exam
    {
        [Key]
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Enter Exam Name")]
        [Display(Name = "Exam Name")]
        public string ExamName { get; set; }

        [Required(ErrorMessage = "Enter Certification for Exam")]
        [Display(Name = " Certification")]
        public int CertificationId { get; set; }
        public virtual Certification Certification { get; set; }
        public virtual List<QuestionPercentageDetail> QuestionPercentageDetails { get; set; }
        //}
        public virtual List<Question> Questions { get; set; }
    }

    public class KnowledgeArea
    {

        [Key]
        public int KnowledgeAreaId { get; set; }
        [Required(ErrorMessage = "Enter Correct Certification")]
        [Display(Name = "Certification")]
        public int CertificationId { get; set; }
        [Display(Name = "Name")]
        public string KnowledgeAreaName { get; set; }
        [Display(Name = "Remark")]
        public string Remark { get; set; }
        public virtual Certification Certification { get; set; }
        public virtual List<QuestionPercentageDetail> QuestionPercentageDetails { get; set; }
        public virtual List<Question> Questions { get; set; }
    }

    //public class QuestionPercentage
    //{
    //    [Key]
    //    public int QuestionPercentageId { get; set; }
    //    [Required(ErrorMessage = "Enter Correct Certification")]
    //    [Display(Name = "Certification")]
    //    public int CertificationId { get; set; }
    //    public virtual Certification Certification { get; set; }
    //    public virtual List<QuestionPercentageDetail> QuestionPercentageDetails { get; set; }
    //}

    public class QuestionPercentageDetail
    {
        [Key]
        public int QuestionPercentageDetailId { get; set; }


        [Required(ErrorMessage = "Select Exam")]
        [Display(Name = "Exam")]
        public int ExamId { get; set; }

        [Required(ErrorMessage = "Enter Correct Knowlege Area")]
        [Display(Name = "Knowlege Area")]
        public int KnowledgeAreaId { get; set; }
        public int TotalPercentage { get; set; }


        public virtual Exam Exam { get; set; }
        public virtual KnowledgeArea KnowledgeArea { get; set; }
    }



    public class Question
    {
        [Key]
        public int QuestionId { get; set; }

        [Required(ErrorMessage = "Select Certification")]
        [Display(Name = "Certification")]
        public int CertificationId { get; set; }

        [Required(ErrorMessage = "Select Exam")]
        [Display(Name = "Exam")]
        public int ExamId { get; set; }


        [Display(Name = "Study Area")]
        public int KnowledgeAreaId { get; set; }

        [Required(ErrorMessage = "Select Language")]
        [Display(Name = "Language :")]
        public int LanguageId { get; set; }

        [Required(ErrorMessage = "Enter Question")]
        [Display(Name = "Question")]
        public string FullQuestion { get; set; }

        [Required(ErrorMessage = "Enter Answer Option 1")]
        [Display(Name = "Option 1")]
        public string AnswerOption1 { get; set; }

        [Required(ErrorMessage = "Answer Option 2")]
        [Display(Name = "Option 2")]
        public string AnswerOption2 { get; set; }

        [Required(ErrorMessage = "Answer Option 3")]
        [Display(Name = "Option 3")]
        public string AnswerOption3 { get; set; }

        [Required(ErrorMessage = "Answer Option 4")]
        [Display(Name = "Option 4")]
        public string AnswerOption4 { get; set; }

        [Required(ErrorMessage = "Enter Correct Answer")]
        [Display(Name = "Correct Answer")]
        public string CorrectAnswerIndex { get; set; }

        [Display(Name = "Mark for Question")]
        public int? Mark { get; set; }
        [Display(Name = "QuestionType")]
        public string AreaofKnowledge { get; set; }

        [Display(Name = "Explanation of Answer")]
        public string AnswerExplanation { get; set; }

        [Display(Name = "PreviousQuestion")]
        public bool AskedOn { get; set; }

        [Display(Name = "Can be used for Test")]
        public bool isDisplayOnly { get; set; }



        public virtual LanguageMaster LanguageMaster { get; set; }
        public virtual KnowledgeArea KnowledgeArea { get; set; }


        public virtual Certification Certification { get; set; }

        public virtual List<CandidateExamQuestionDetail> CandidateExamQuestionDetails { get; set; }

        public virtual Exam Exam { get; set; }
    }


    public class Candidate
    {
        [Key]
        public int CandidateId { get; set; }

        [Required(ErrorMessage = "Enter CandidateName")]
        [Display(Name = "Candidate Name")]
        public string CandidateName { get; set; }

        [Required(ErrorMessage = "Enter Candidate Email")]
        [Display(Name = " Email/Username")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string CandidateEmail { get; set; }


        [Required(ErrorMessage = "Enter Password")]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password")]
        [Display(Name = "Confirm Password")]
        [Compare("Password")]
        public string ConfirmPasswod { get; set; }

        public virtual List<CandidateExam> CandidateExam { get; set; }
    }



    public class CandidateExam
    {
        [Key]
        public int CandidateExamId { get; set; }
        public int CandidateId { get; set; }
        public virtual Candidate Candidate { get; set; }

        public int ExamId { get; set; }
        public virtual Exam Exam { get; set; }
        public virtual List<CandidateExamDetail> CandidateExamDetail { get; set; }
    }

    public class CandidateExamDetail
    {
        [Key]
        public int CandidateExamDetailId { get; set; }
        public int CandidateExamId { get; set; }
        public virtual CandidateExam CandidateExam { get; set; }
        public virtual List<CandidateExamQuestionDetail> CandidateExamQuestionDetail { get; set; }
    }

    public class CandidateExamQuestionDetail
    {
        [Key]
        public int CandidateExamQuestionDetailsId { get; set; }
        public int CandidateExamDetailId { get; set; }
        public int QuestionId { get; set; }
        public int SelectedAnswer { get; set; }
        public bool? IsCorrect { get; set; }
        public string Status { get; set; }

        public virtual Question Question { get; set; }
        public virtual CandidateExamDetail CandidateExamDetail { get; set; }
    }



    public class CountryMaster
    {
        [Key]
        public int CountryId { get; set; }
        [Required(ErrorMessage = "Enter Country")]
        [Display(Name = "Country Name")]
        public string CountryName { get; set; }
        public virtual List<JobVaccancy> JobVaccancys { get; set; }
    }

    public class JobField
    {
        [Key]
        public int JobFieldId { get; set; }
        [Required(ErrorMessage = "Enter Job Field")]
        [Display(Name = "Job Field")]
        public string JobFieldName { get; set; }
        public virtual List<JobFieldArea> JobFieldAreas { get; set; }
    }

    public class JobFieldArea
    {
        [Key]
        public int JobAreaId { get; set; }
        [Required(ErrorMessage = "Enter Job Area")]
        [Display(Name = "Job Area")]
        public string JobAreaName { get; set; }
        public int JobFieldId { get; set; }
        public virtual JobField JobField { get; set; }
        public virtual List<JobVaccancy> JobVaccancys { get; set; }
    }

    public class JobVaccancy
    {
        [Key]
        public int JobID { get; set; }
        [Display(Name = "Job Tittle")]
        public String JobTitle { get; set; }
        [Display(Name = "Country")]
        public int CountryId { get; set; }
        [Display(Name = "Job Area")]
        public int JobAreaId { get; set; }
        [Display(Name = "Job Location")]
        public String JobLocation { get; set; }
        [Display(Name = "Company  Name")]
        public String CompanyName { get; set; }
        [Display(Name = "Employment  Type")]
        public String EmploymentType { get; set; }
        [Display(Name = "Monthly  Salary")]
        public String MonthlySalary { get; set; }
        public String Benefits { get; set; }
        [Display(Name = "Min Work Experience Req")]
        public String MinimumWorkExperience { get; set; }
        [Display(Name = "Min Education  Req")]
        public String MinimumEducationLevel { get; set; }
        [Display(Name = "Advertised on")]
        public String ListedBy { get; set; }
        [Display(Name = "Company Size")]
        public String CompanySize { get; set; }
        [Display(Name = "Career Level")]
        public String CareerLevel { get; set; }
        public String Description { get; set; }
        public String Skills { get; set; }
        public String EmailID { get; set; }
        [Display(Name = "Contact Person")]
        public String ContactPerson { get; set; }
        [Display(Name = "Phone Number")]
        public String PhoneNumber { get; set; }

        public String Country { get; set; }
        [Display(Name = "Job Category")]
        public String JobCategory { get; set; }
        [Display(Name = "Posted Date")]
        public DateTime PostedDate { get; set; }
        [Display(Name = "Last Date")]
        public DateTime LasteDate { get; set; }
        [Display(Name = "Still Active")]
        public Boolean IsActive { get; set; }
        public virtual CountryMaster CountryMaster { get; set; }
        public virtual JobFieldArea JobFieldArea { get; set; }
    }




    public class CertificationQuestionLink
    {
        [Key]
        public int CertificationQuestionLinkId { get; set; }

        [Display(Name = "To Certification")]
        public int ToCertificationId { get; set; }
        [Display(Name = "To Knowledge Area")]
        public int ToKnowledgeAreaId { get; set; }

        [Display(Name = "From  Certification")]
        public int FromCertificationId { get; set; }
        [Display(Name = "From  Knowledge Area")]
        public int FromKnowledgeAreaId { get; set; }

    }







    public class SiteUrl
    {
        [Key]
        public int SiteUrlId { get; set; }

        [Required(ErrorMessage = "Enter URL")]
        [Display(Name = "Page  URL")]
        public string PageUrlAddress { get; set; }

        [Required(ErrorMessage = "Enter Tittle")]
        [Display(Name = "Page  Tittle")]
        public string PageTittle { get; set; }


        [Required(ErrorMessage = "Enter Description")]
        [Display(Name = "Page  Description")]
        public string PageDescription { get; set; }

        [Required(ErrorMessage = "Enter Keywords")]
        [Display(Name = "Page  Keywords")]
        public string PageKeywords { get; set; }

        [Required(ErrorMessage = "Page Heading")]
        [Display(Name = "Page  Heading")]
        public string PageHeading { get; set; }

        [Required(ErrorMessage = "Enter SlugName")]
        [Display(Name = "Page  SlugName")]
        public string PageSlugName { get; set; }
    }

}


