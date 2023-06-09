using System;

namespace Webhelp.Rh.Domain.Entities.Technology
{
    public class Technology
    {
        public Guid Id { get; private set; }
        public string Name { get; private set; }

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
