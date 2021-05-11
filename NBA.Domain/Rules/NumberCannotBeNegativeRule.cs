using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Domain.Rules
{
    public class NumberCannotBeNegativeRule : IBusinessRule
    {
        private readonly int number;

        public NumberCannotBeNegativeRule(int number)
        {
            this.number = number;
        }
        public string Message => "Number cannot be negativeRule";

        public bool IsBroken() => number < 0;
    }
}
