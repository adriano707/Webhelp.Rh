using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Webhelp.Rh.Data.Configuration;
using Webhelp.Rh.Domain.Entities.Candidate;
using Webhelp.Rh.Domain.Entities.Technology;
using Webhelp.Rh.Domain.Entities.Vacancy;

namespace Webhelp.Rh.Data
{
    public class RhDbContext : DbContext
    {
        public DbSet<Technology> Technology { get; set; }
        public DbSet<Candidate> Candidate { get; set; }
        public DbSet<Vacancy> Vacancy { get; set; }

        public RhDbContext() : base("App") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CandidateConfiguration());
            modelBuilder.Configurations.Add(new TechnologyConfiguration());
            modelBuilder.Configurations.Add(new CandidateTechnologyConfiguration());
            modelBuilder.Configurations.Add(new VacancyTechnologyConfiguration());
            modelBuilder.Configurations.Add(new VacancyConfiguration());
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
