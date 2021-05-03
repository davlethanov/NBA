using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public class TeamCityCannotBeEmptyRule : IBusinessRule
    {
        private readonly string city;

        public TeamCityCannotBeEmptyRule(string city)
        {
            this.city = city;
        }
        public string Message => "Team city cannot be empty";

        public bool IsBroken() => string.IsNullOrEmpty(city);
    }
}
