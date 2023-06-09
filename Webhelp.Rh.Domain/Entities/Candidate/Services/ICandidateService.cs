using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Webhelp.Rh.Domain.Entities.Candidate.Services
{
    public interface ICandidateService
    {
        Task<Candidate> GetById(Guid id);
        Task<Candidate> Create(string name, string email, string phone, Guid[] technologyIds);
        Task<List<Candidate>> GetAll();
        Task<Candidate> Update(Guid id, string name, string email, string phone, Guid[] technologyIds);
        Task Delete(Guid id);
    }
}
