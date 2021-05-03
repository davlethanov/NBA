using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public class TeamPlayerMustHaveNonNegativeNumberRule : IBusinessRule
    {
        private readonly Guid? teamId;
        private readonly int? number;

        public TeamPlayerMustHaveNonNegativeNumberRule(Guid? teamId, int? number)
        {
            this.teamId = teamId;
            this.number = number;
        }

        public string Message => "Team player must have non negative number";

        public bool IsBroken() => teamId.HasValue && (!number.HasValue || number < 0);
    }
}
