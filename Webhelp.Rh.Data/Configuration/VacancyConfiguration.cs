using System.Data.Entity.ModelConfiguration;
using Webhelp.Rh.Domain.Entities.Vacancy;

namespace Webhelp.Rh.Data.Configuration
{
    public class VacancyConfiguration : EntityTypeConfiguration<Vacancy>
    {
        public VacancyConfiguration()
        {
            HasKey(v => v.Id);
            Property(v => v.Name).HasColumnType("varchar")
                .HasMaxLength(100); ;
        }
    }
}
