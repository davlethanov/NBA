using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public class SecondNameCannotBeEmptyRule : IBusinessRule
    {
        private readonly string secondName;

        public SecondNameCannotBeEmptyRule(string secondName)
        {
            this.secondName = secondName;
        }
        public string Message => "Second name cannot be empty";

        public bool IsBroken() => string.IsNullOrEmpty(secondName);
    }
}
