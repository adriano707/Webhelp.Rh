using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Webhelp.Rh.Domain.Entities.Candidate.Services
{
    public interface ITechnologyService
    {
        Task<Technology.Technology> GetById(Guid id);
        Task<Technology.Technology> Create(string name);
        Task<List<Technology.Technology>> GetAll();
        Task<Technology.Technology> Update(Guid id, string name);
        Task Delete(Guid id);
    }
}
