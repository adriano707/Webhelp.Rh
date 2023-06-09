using System;

namespace Webhelp.Rh.Web.ViewModel
{
    public class CandidateViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public Guid[] Technologies { get; set; }
    }
}