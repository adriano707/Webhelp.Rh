using System;

namespace Webhelp.Rh.Web.ViewModel
{
    public class VacancyViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid[] Technologies { get; set; }
    }
}