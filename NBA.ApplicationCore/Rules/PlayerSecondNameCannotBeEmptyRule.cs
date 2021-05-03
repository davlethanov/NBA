using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public class PlayerSecondNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string secondName;

        public PlayerSecondNameCannotBeEmptyRule(string secondName)
        {
            this.secondName = secondName;
        }
        public string Message => "Player second name cannot be empty";

        public bool IsBroken() => string.IsNullOrEmpty(secondName);
    }
}
