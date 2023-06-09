namespace Webhelp.Rh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IncludeVacancyTechnologyEntity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.VacancyTechnology",
                c => new
                    {
                        VacancyId = c.Guid(nullable: false),
                        TechnologyId = c.Guid(nullable: false),
                        Linguee = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => new { t.VacancyId, t.TechnologyId })
                .ForeignKey("dbo.Technology", t => t.TechnologyId, cascadeDelete: true)
                .ForeignKey("dbo.Vacancy", t => t.VacancyId, cascadeDelete: true)
                .Index(t => t.VacancyId)
                .Index(t => t.TechnologyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VacancyTechnology", "VacancyId", "dbo.Vacancy");
            DropForeignKey("dbo.VacancyTechnology", "TechnologyId", "dbo.Technology");
            DropIndex("dbo.VacancyTechnology", new[] { "TechnologyId" });
            DropIndex("dbo.VacancyTechnology", new[] { "VacancyId" });
            DropTable("dbo.VacancyTechnology");
        }
    }
}
