using System.Data.Entity.ModelConfiguration;
using Webhelp.Rh.Domain.Entities.Technology;

namespace Webhelp.Rh.Data.Configuration
{
    public class TechnologyConfiguration : EntityTypeConfiguration<Technology>
    {
        public TechnologyConfiguration()
        {
            HasKey(t => t.Id);
            Property(t => t.Name).HasColumnType("varchar")
                .HasMaxLength(100); ;
        }
    }
}
