using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public class PlayerFirstNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string firstName;

        public PlayerFirstNameCannotBeEmptyRule(string firstName)
        {
            this.firstName = firstName;
        }
        public string Message => "Player first name cannot be empty";

        public bool IsBroken() => string.IsNullOrEmpty(firstName);
    }
}
