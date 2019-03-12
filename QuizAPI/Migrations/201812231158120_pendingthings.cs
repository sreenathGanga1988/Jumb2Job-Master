namespace QuizAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pendingthings : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SiteUrls", "PageHeading", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.SiteUrls", "PageHeading");
        }
    }
}
