using System;
using System.Collections.Generic;

namespace Webhelp.Rh.Domain.Entities.Vacancy
{
    public class Vacancy
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public List<VacancyTechnology> Technologies { get; private set; }

        public Vacancy(){
            
        }

        public Vacancy(string name, List<VacancyTechnology> technologies){
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Technologies = technologies;
        }

        public void Update(string name, List<VacancyTechnology> technologies)
        {
            Name = name;
            Technologies = technologies;
        }
    }

    
}
