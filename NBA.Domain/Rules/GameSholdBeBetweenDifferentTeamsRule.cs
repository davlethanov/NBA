using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.Domain.Rules
{
    public class GameSholdBeBetweenDifferentTeamsRule : IBusinessRule
    {
        private readonly Guid awayTeamId;
        private readonly Guid homeTeamId;

        public GameSholdBeBetweenDifferentTeamsRule(Guid awayTeamId, Guid homeTeamId)
        {
            this.awayTeamId = awayTeamId;
            this.homeTeamId = homeTeamId;
        }

        public string Message => "Game should be between different teams";

        public bool IsBroken() => awayTeamId == homeTeamId;
    }
}
