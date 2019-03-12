namespace QuizAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class addedexam : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Questions", "ExamId", c => c.Int(nullable: true));
            CreateIndex("dbo.Questions", "ExamId");
            AddForeignKey("dbo.Questions", "ExamId", "dbo.Exams", "ExamId", cascadeDelete: false);
        }

        public override void Down()
        {
            DropForeignKey("dbo.Questions", "ExamId", "dbo.Exams");
            DropIndex("dbo.Questions", new[] { "ExamId" });
            DropColumn("dbo.Questions", "ExamId");
        }
    }
}
