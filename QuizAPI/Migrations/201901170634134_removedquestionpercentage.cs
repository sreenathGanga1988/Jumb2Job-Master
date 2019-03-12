namespace QuizAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class removedquestionpercentage : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.QuestionPercentages", "CertificationId", "dbo.Certifications");
            DropForeignKey("dbo.QuestionPercentageDetails", "QuestionPercentageId", "dbo.QuestionPercentages");
            DropIndex("dbo.QuestionPercentageDetails", new[] { "QuestionPercentageId" });
            DropIndex("dbo.QuestionPercentages", new[] { "CertificationId" });
            AddColumn("dbo.QuestionPercentageDetails", "ExamId", c => c.Int(nullable: false));
            CreateIndex("dbo.QuestionPercentageDetails", "ExamId");
            AddForeignKey("dbo.QuestionPercentageDetails", "ExamId", "dbo.Exams", "ExamId", cascadeDelete: false);
            DropColumn("dbo.QuestionPercentageDetails", "QuestionPercentageId");
            DropTable("dbo.QuestionPercentages");
        }

        public override void Down()
        {
            CreateTable(
                "dbo.QuestionPercentages",
                c => new
                    {
                        QuestionPercentageId = c.Int(nullable: false, identity: true),
                        CertificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuestionPercentageId);

            AddColumn("dbo.QuestionPercentageDetails", "QuestionPercentageId", c => c.Int(nullable: false));
            DropForeignKey("dbo.QuestionPercentageDetails", "ExamId", "dbo.Exams");
            DropIndex("dbo.QuestionPercentageDetails", new[] { "ExamId" });
            DropColumn("dbo.QuestionPercentageDetails", "ExamId");
            CreateIndex("dbo.QuestionPercentages", "CertificationId");
            CreateIndex("dbo.QuestionPercentageDetails", "QuestionPercentageId");
            AddForeignKey("dbo.QuestionPercentageDetails", "QuestionPercentageId", "dbo.QuestionPercentages", "QuestionPercentageId", cascadeDelete: true);
            AddForeignKey("dbo.QuestionPercentages", "CertificationId", "dbo.Certifications", "CertificationId", cascadeDelete: false);
        }
    }
}
