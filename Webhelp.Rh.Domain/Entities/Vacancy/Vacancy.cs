using System;

namespace Webhelp.Rh.Domain.Entities.Vacancy
{
    public class Vacancy
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

        public Vacancy(){
            
        }

        public Vacancy(string name){
            Id = Guid.NewGuid();
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }

        public void Update(string name)
        {
            Name = name;
        }
    }

    
}
