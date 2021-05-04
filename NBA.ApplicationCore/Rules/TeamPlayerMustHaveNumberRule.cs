using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public class TeamPlayerMustHaveNumberRule : IBusinessRule
    {
        private readonly Guid? teamId;
        private readonly int? number;

        public TeamPlayerMustHaveNumberRule(Guid? teamId, int? number)
        {
            this.teamId = teamId;
            this.number = number;
        }

        public string Message => "Team player must have number";

        public bool IsBroken() => teamId.HasValue && !number.HasValue;
    }
}
