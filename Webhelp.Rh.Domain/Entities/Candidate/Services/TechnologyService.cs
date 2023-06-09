using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Webhelp.Rh.Domain.Repository;

namespace Webhelp.Rh.Domain.Entities.Candidate.Services
{
    public class TechnologyService : ITechnologyService
    {
        private readonly IRepository _repository;

        public TechnologyService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Technology.Technology> GetById(Guid id)
        {
            var technology = _repository.Query<Technology.Technology>().FirstOrDefault(c => c.Id == id);
            return technology;
        }

        public async Task<Technology.Technology> Create(string name)
        {
            Technology.Technology technology = new Technology.Technology(name);

            await _repository.InsertAsync(technology);
            await _repository.SaveChangeAsync();

            return technology;
        }

        public async Task<List<Technology.Technology>> GetAll()
        {
            var technologies = _repository.Query<Technology.Technology>().ToList();
            return technologies;
        }

        public async Task<Technology.Technology> Update(Guid id, string name)
        {
            var technology = _repository.Query<Technology.Technology>().FirstOrDefault(c => c.Id == id);

            if (technology == null)
            {
                throw new Exception("Tecnologia não encontrada");
            }

            technology.Update(id, name);

            _repository.Update(technology);
            await _repository.SaveChangeAsync();

            return technology;
        }

        public async Task Delete(Guid id)
        {
            var technology = _repository.Query<Technology.Technology>().FirstOrDefault(c => c.Id == id);

            if (technology == null)
            {
                throw new Exception("Tecnologia não encontrada");
            }

            _repository.Delete(technology);
            await _repository.SaveChangeAsync();
        }
    }
}
