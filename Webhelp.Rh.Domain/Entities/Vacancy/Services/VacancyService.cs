using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Webhelp.Rh.Domain.Entities.Relations;
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
            var vacancy = _repository.Query<Vacancy>()
                .Include(c => c.Technologies.Select(t => t.Technology))
                .FirstOrDefault(v => v.Id == id);

            return vacancy;
        }

        public async Task<Vacancy> Create(string name, Guid[] technologyIds)
        {
            var technologies = await GetTechnologiesByIds(technologyIds);

            List<VacancyTechnology> vacancyTechnologies = technologies.Select(t => new VacancyTechnology(t)).ToList();

            Vacancy vacancy = new Vacancy(name, vacancyTechnologies);

            await _repository.InsertAsync(vacancy);
            await _repository.SaveChangeAsync();

            return vacancy;
        }

        public async Task<List<Vacancy>> GetAll()
        {
            var vacancies = _repository.Query<Vacancy>().ToList();
            return vacancies;
        }

        public async Task<Vacancy> Update(Guid id, string name, Guid[] technologyIds)
        {
            var vacancy = _repository.Query<Vacancy>()
                .FirstOrDefault(v => v.Id == id);

            var technologies = await GetTechnologiesByIds(technologyIds);

            if (vacancy == null)
            {
                throw new Exception("Vaga não encontrada");
            }

            var vacancyTechnologies = technologies.Select(t => new VacancyTechnology(t)).ToList();

            vacancy.Update(name, vacancyTechnologies);

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

        private async Task<List<Technology.Technology>> GetTechnologiesByIds(Guid[] technologyIds)
        {
            if (technologyIds != null)
            {
                var technologies = _repository.Query<Technology.Technology>()
                    .Where(t => technologyIds.Contains(t.Id))
                    .ToList();

                return technologies;
            }
            
            return new List<Technology.Technology>();
        }
    }
}
