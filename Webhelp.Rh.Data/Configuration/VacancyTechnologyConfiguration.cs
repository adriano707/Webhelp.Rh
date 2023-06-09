using System.Data.Entity.ModelConfiguration;
using Webhelp.Rh.Domain.Entities.Vacancy;

namespace Webhelp.Rh.Data.Configuration
{
    public class VacancyTechnologyConfiguration : EntityTypeConfiguration<VacancyTechnology>
    {
        public VacancyTechnologyConfiguration()
        {
            HasKey(k => new { k.VacancyId, k.TechnologyId });

            HasRequired(vt => vt.Vacancy)
                .WithMany()
                .HasForeignKey(vt => vt.VacancyId);

            HasRequired(vt => vt.Technology)
                .WithMany()
                .HasForeignKey(vt => vt.TechnologyId);
        }
    }
}
