using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webhelp.Rh.Domain.Repository;

namespace Webhelp.Rh.Domain.Entities.Vacancy.Services
{
    public class VacancyService : IVacancyService
    {
        private readonly IRepository _repository;

        public VacancyService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Vacancy> GetById(Guid id)
        {
            var vacancy = _repository.Query<Vacancy>().FirstOrDefault(v => v.Id == id);
            return vacancy;
        }

        public async Task<Vacancy> Create(string name)
        {
            Vacancy vacancy = new Vacancy(name);

            await _repository.InsertAsync(vacancy);
            await _repository.SaveChangeAsync();

            return vacancy;
        }

        public async Task<List<Vacancy>> GetAll()
        {
            var vacancies = _repository.Query<Vacancy>().ToList();
            return vacancies;
        }

        public async Task<Vacancy> Update(Guid id, string name)
        {
            var vacancy = _repository.Query<Vacancy>()
                .FirstOrDefault(v => v.Id == id);

            if (vacancy == null)
            {
                throw new Exception("Vaga não encontrada");
            }

            vacancy.Update(name);

            _repository.Update(vacancy);
            await _repository.SaveChangeAsync();

            return vacancy;
        }

        public async Task Delete(Guid id)
        {
            var vacancy = _repository.Query<Vacancy>().FirstOrDefault(v => v.Id == id);

            if (vacancy == null)
            {
                throw new Exception("Vaga não encontrada");
            }

            _repository.Delete(vacancy);
            await _repository.SaveChangeAsync();
        }
    }
}
