using System.Data.Entity.ModelConfiguration;
using Webhelp.Rh.Domain.Entities.Relations;

namespace Webhelp.Rh.Data.Configuration
{
    public class CandidateTechnologyConfiguration : EntityTypeConfiguration<CandidateTechnology>
    {
        public CandidateTechnologyConfiguration()
        {
            HasKey(k => new { k.CandidateId, k.TechnologyId});

            HasRequired(ct => ct.Candidate)
                .WithMany()
                .HasForeignKey(ct => ct.CandidateId);

            HasRequired(ct => ct.Technology)
                .WithMany()
                .HasForeignKey(ct => ct.TechnologyId);
        }
    }
}
