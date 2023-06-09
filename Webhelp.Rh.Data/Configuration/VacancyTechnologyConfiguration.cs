using System.Data.Entity.ModelConfiguration;
using Webhelp.Rh.Domain.Entities.Vacancy;

namespace Webhelp.Rh.Data.Configuration
{
    public class VacancyTechnologyConfiguration : EntityTypeConfiguration<VacancyTechnology>
    {
        public VacancyTechnologyConfiguration()
        {
            HasKey(k => new { k.VacancyId, k.TechnologyId });

            Property(vc => vc.Linguee)
                .HasColumnType("decimal");

            HasRequired(vt => vt.Vacancy)
                .WithMany(t => t.Technologies)
                .HasForeignKey(vt => vt.VacancyId);

            HasRequired(vt => vt.Technology)
                .WithMany(t => t.Vacancies)
                .HasForeignKey(vt => vt.TechnologyId);
        }
    }
}
