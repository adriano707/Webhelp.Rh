namespace Webhelp.Rh.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Candidates",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 250, unicode: false),
                        Email = c.String(maxLength: 100, unicode: false),
                        Phone = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CandidateTechnologies",
                c => new
                    {
                        CandidateId = c.Guid(nullable: false),
                        TechnologyId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CandidateId, t.TechnologyId })
                .ForeignKey("dbo.Technologies", t => t.TechnologyId, cascadeDelete: true)
                .ForeignKey("dbo.Candidates", t => t.CandidateId, cascadeDelete: true)
                .Index(t => t.CandidateId)
                .Index(t => t.TechnologyId);
            
            CreateTable(
                "dbo.Technologies",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CandidateTechnologies", "CandidateId", "dbo.Candidates");
            DropForeignKey("dbo.CandidateTechnologies", "TechnologyId", "dbo.Technologies");
            DropIndex("dbo.CandidateTechnologies", new[] { "TechnologyId" });
            DropIndex("dbo.CandidateTechnologies", new[] { "CandidateId" });
            DropTable("dbo.Technologies");
            DropTable("dbo.CandidateTechnologies");
            DropTable("dbo.Candidates");
        }
    }
}
