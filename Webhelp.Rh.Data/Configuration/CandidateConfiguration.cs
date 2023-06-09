using System.Data.Entity.ModelConfiguration;
using Webhelp.Rh.Domain.Entities.Candidate;

namespace Webhelp.Rh.Data.Configuration
{
    public class CandidateConfiguration : EntityTypeConfiguration<Candidate>
    {
        public CandidateConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Name)
                .HasColumnType("varchar")
                .HasMaxLength(250);

            Property(c => c.Email)
                .HasColumnType("varchar")
                .HasMaxLength(100); ;

            Property(c => c.Phone)
                .HasColumnType("varchar")
                .HasMaxLength(100); ;

            HasMany(c => c.Technologies)
                .WithRequired(t => t.Candidate)
                .HasForeignKey(c => c.CandidateId);
        }
    }
}
