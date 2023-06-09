using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Webhelp.Rh.Domain.Entities.Vacancy.Services
{
    public interface IVacancyService
    {
        Task<Vacancy> GetById(Guid id);
        Task<Vacancy> Create(string name);
        Task<List<Vacancy>> GetAll();
        Task<Vacancy> Update(Guid id, string name);
        Task Delete(Guid id);
    }
}
