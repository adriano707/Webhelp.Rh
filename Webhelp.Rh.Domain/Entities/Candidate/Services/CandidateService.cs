using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Webhelp.Rh.Domain.Entities.Relations;
using Webhelp.Rh.Domain.Repository;

namespace Webhelp.Rh.Domain.Entities.Candidate.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly IRepository _repository;

        public CandidateService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Candidate> GetById(Guid id)
        {
            var candidate = _repository.Query<Candidate>()
                .Include(c => c.Technologies.Select(t => t.Technology))
                .FirstOrDefault(c => c.Id == id);
            return candidate;
        }

        public async Task<List<Candidate>> GetAll()
        {
            var candidate = _repository.Query<Candidate>().ToList();
            return candidate;
        }

        public async Task<Candidate> Update(Guid id, string name, string email, string phone, Guid[] technologies)
        {
            var candidate = _repository.Query<Candidate>().FirstOrDefault(c => c.Id == id);

            if (candidate == null)
            {
                throw new Exception("Candidato não encontrado");
            }

            var listTechnologies = _repository.Query<Technology.Technology>()
                .Where(t => technologies.Contains(t.Id))
                .ToList();

            var candidatesTechnologies = listTechnologies.Select(t => new CandidateTechnology(t)).ToList();

            candidate.Update(name, email, phone, candidatesTechnologies);

            _repository.Update(candidate);
            await _repository.SaveChangeAsync();

            return candidate;
        }

        public async Task Delete(Guid id)
        {
            var candidate = _repository.Query<Candidate>().FirstOrDefault(c => c.Id == id);

            if (candidate == null)
            {
                throw new Exception("Candidato não encontrado");
            }

            _repository.Delete(candidate);
            await _repository.SaveChangeAsync();
        }

        public async Task<Candidate> Create(string name, string email, string phone, Guid[] technologies)
        {
            var listTechnologies = _repository.Query<Technology.Technology>()
                .Where(t => technologies.Contains(t.Id))
                .ToList();

            List<CandidateTechnology> candidateTechnologies = listTechnologies.Select(t => new CandidateTechnology(t)).ToList();

            Candidate candidate = new Candidate(name, email, phone, candidateTechnologies);

            await _repository.InsertAsync(candidate);
            await _repository.SaveChangeAsync();

            return candidate;
        }
    }
}
