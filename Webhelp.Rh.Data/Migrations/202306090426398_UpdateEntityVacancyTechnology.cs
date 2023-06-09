namespace Webhelp.Rh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateEntityVacancyTechnology : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CandidateTechnology", "Technology_Id", c => c.Guid());
            CreateIndex("dbo.CandidateTechnology", "Technology_Id");
            AddForeignKey("dbo.CandidateTechnology", "Technology_Id", "dbo.Technology", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateTechnology", "Technology_Id", "dbo.Technology");
            DropIndex("dbo.CandidateTechnology", new[] { "Technology_Id" });
            DropColumn("dbo.CandidateTechnology", "Technology_Id");
        }
    }
}
