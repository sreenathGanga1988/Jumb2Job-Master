using System.Data.Entity;
using QuizAPI.Models;


public class QuizContext : DbContext
{

    public QuizContext()
        : base("name = QuizConnectionString")
    {



        Database.SetInitializer<QuizContext>(

new MigrateDatabaseToLatestVersion<QuizContext, QuizAPI.Migrations.Configuration>());

        Database.Initialize(false);




    }

    public DbSet<Question> Questions { get; set; }
    public DbSet<Certification> Certifications { get; set; }
    public DbSet<Candidate> Candidates { get; set; }
    public DbSet<Exam> Exams { get; set; }
    public DbSet<CandidateExam> CandidateExams { get; set; }
    public DbSet<CandidateExamDetail> CandidateExamDetails { get; set; }
    public DbSet<CandidateExamQuestionDetail> CandidateExamQuestionDetails { get; set; }
    public System.Data.Entity.DbSet<KnowledgeArea> KnowledgeAreas { get; set; }
    public System.Data.Entity.DbSet<QuestionPercentageDetail> QuestionPercentageDetails { get; set; }
    public System.Data.Entity.DbSet<LanguageMaster> LanguageMasters { get; set; }
    public System.Data.Entity.DbSet<CountryMaster> CountryMasters { get; set; }
    public System.Data.Entity.DbSet<JobFieldArea> JobFieldAreas { get; set; }
    public System.Data.Entity.DbSet<JobField> JobFields { get; set; }
    public System.Data.Entity.DbSet<JobVaccancy> JobVaccancys { get; set; }
    public System.Data.Entity.DbSet<SiteUrl> SiteUrls { get; set; }
    public System.Data.Entity.DbSet<ExamTableMain> ExamTableMains { get; set; }
    public System.Data.Entity.DbSet<ExamTableKnowledgeArea> ExamTableKnowledgeAreas { get; set; }
    public System.Data.Entity.DbSet<CandidateLogin> CandidateLogins { get; set; }
    public System.Data.Entity.DbSet<CandidateResult> CandidateResults { get; set; }
    public System.Data.Entity.DbSet<CandidateResultDetail> CandidateResultDetails { get; set; }



    public System.Data.Entity.DbSet<CertificationQuestionLink> CertificationQuestionLinks { get; set; }

    public System.Data.Entity.DbSet<QuizAPI.Models.TopicMaster> TopicMasters { get; set; }

    public System.Data.Entity.DbSet<QuizAPI.Models.TopicNote> TopicNotes { get; set; }

    public System.Data.Entity.DbSet<QuizAPI.Models.TopicNoteComment> TopicNoteComments { get; set; }

}