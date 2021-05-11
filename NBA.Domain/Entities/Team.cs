using NBA.Domain.Base;
using NBA.Domain.Rules;

namespace NBA.Domain.Entities
{
    public class Team : Entity
    {
        public string Name { get; private set; }

        public string City { get; private set; }

        public string FullName => $"{City} {Name}";

        protected Team() { }

        public Team(string name, string city)
        {
            CheckRule(new TeamNameCannotBeEmptyRule(name));
            CheckRule(new TeamCityCannotBeEmptyRule(city));

            Name = name;
            City = city;
        }

        public void SetName(string name)
        {
            CheckRule(new TeamNameCannotBeEmptyRule(name));

            Name = name;
        }

        public void SetCity(string city)
        {
            CheckRule(new TeamCityCannotBeEmptyRule(city));

            City = city;
        }
    }
}
