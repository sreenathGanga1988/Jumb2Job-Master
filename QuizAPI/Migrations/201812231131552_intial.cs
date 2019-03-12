namespace QuizAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class intial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CertificationQuestionLinks",
                c => new
                    {
                        CertificationQuestionLinkId = c.Int(nullable: false, identity: true),
                        ToCertificationId = c.Int(nullable: false),
                        ToKnowledgeAreaId = c.Int(nullable: false),
                        FromCertificationId = c.Int(nullable: false),
                        FromKnowledgeAreaId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.CertificationQuestionLinkId);
            
            CreateTable(
                "dbo.SiteUrls",
                c => new
                    {
                        SiteUrlId = c.Int(nullable: false, identity: true),
                        PageUrlAddress = c.String(nullable: false),
                        PageTittle = c.String(nullable: false),
                        PageDescription = c.String(nullable: false),
                        PageKeywords = c.String(nullable: false),
                        PageSlugName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.SiteUrlId);
            
            AddColumn("dbo.Exams", "ExamName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exams", "ExamName");
            DropTable("dbo.SiteUrls");
            DropTable("dbo.CertificationQuestionLinks");
        }
    }
}
