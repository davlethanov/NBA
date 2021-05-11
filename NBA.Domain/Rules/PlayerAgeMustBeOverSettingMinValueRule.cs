using NBA.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Domain.Rules
{
    public class PlayerAgeMustBeOverSettingMinValueRule : IBusinessRule
    {
        private readonly DateTime birthDate;

        public PlayerAgeMustBeOverSettingMinValueRule(DateTime birthDate)
        {
            this.birthDate = birthDate;
        }
        public string Message => "NBA player must be over 18 years old";

        public bool IsBroken() => birthDate.GetAge() < Settings.MinNBAPlayerAge;
    }
}
