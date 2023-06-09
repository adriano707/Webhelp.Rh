using System;
using System.Collections.Generic;
using Webhelp.Rh.Domain.Entities.Relations;
using Webhelp.Rh.Domain.Entities.Vacancy;

namespace Webhelp.Rh.Domain.Entities.Technology
{
    public class Technology
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<CandidateTechnology> Candidates { get; private set; }
        public List<VacancyTechnology> Vacancies { get; private set; }

        public Technology(){
            
        }

        public Technology(string name)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Update(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
