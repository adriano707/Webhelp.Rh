using System;
using System.Collections.Generic;
using Webhelp.Rh.Domain.Entities.Relations;

namespace Webhelp.Rh.Domain.Entities.Candidate
{
    public class Candidate
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public List<CandidateTechnology> Technologies { get; set; }

        public Candidate(){}

        public Candidate(string name, string email, string phone, List<CandidateTechnology> technologies)
        {
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
            Email = email ?? throw new ArgumentNullException(nameof(email));
            Phone = phone ?? throw new ArgumentNullException(nameof(phone));
        }

        public void Update(string name, string email, string phone, List<CandidateTechnology> technologies)
        {
            Name = name;
            Email = email; 
            Phone = phone;
            Technologies = technologies;
        }
    }
}
