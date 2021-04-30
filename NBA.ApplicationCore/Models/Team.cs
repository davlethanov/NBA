using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Models
{
    public class Team
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string City { get; private set; }

        public string FullName => $"{City} {Name}";

        protected Team() { }

        public Team(string name, string city)
        {
            Name = name;
            City = city;
        }
    }
}
