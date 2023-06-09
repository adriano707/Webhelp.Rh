using System;

namespace Webhelp.Rh.Domain.Entities.Vacancy
{
    public class VacancyTechnology
    {
        public Vacancy Vacancy { get; set; }
        public Guid VacancyId { get; set; }
        public Technology.Technology Technology { get; set; }
        public Guid TechnologyId { get; set; }
        public decimal Linguee { get; set; }

        public VacancyTechnology()
        {
            
        }
    }
}
