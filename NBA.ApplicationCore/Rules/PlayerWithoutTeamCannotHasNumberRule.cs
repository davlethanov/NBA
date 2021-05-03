using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public class PlayerWithoutTeamCannotHasNumberRule : IBusinessRule
    {
        private readonly Guid? teamId;
        private readonly int? number;

        public PlayerWithoutTeamCannotHasNumberRule(Guid? teamId, int? number)
        {
            this.teamId = teamId;
            this.number = number;
        }

        public string Message => "Player without team cannot has number";

        public bool IsBroken() => !teamId.HasValue && number.HasValue;
    }
}
