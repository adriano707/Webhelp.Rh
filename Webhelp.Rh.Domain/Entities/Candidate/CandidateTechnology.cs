using System;

namespace Webhelp.Rh.Domain.Entities.Relations
{
    public class CandidateTechnology
    {
        public Candidate.Candidate Candidate { get; set; }
        public Guid CandidateId { get; set; }
        public Technology.Technology Technology { get; set; }
        public Guid TechnologyId { get; set; }

        public CandidateTechnology() {
                
        }

        public CandidateTechnology(Technology.Technology technology){
            Technology = technology;
        }
    }
}
