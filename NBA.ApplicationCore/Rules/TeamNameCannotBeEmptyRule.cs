using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public class TeamNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string name;

        public TeamNameCannotBeEmptyRule(string name)
        {
            this.name = name;
        }
        public string Message => "Team name cannot be empty";

        public bool IsBroken() => string.IsNullOrEmpty(name);
    }
}
