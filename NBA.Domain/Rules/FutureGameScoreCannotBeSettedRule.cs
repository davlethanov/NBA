using System;

namespace NBA.Domain.Rules
{
    public class FutureGameScoreCannotBeSettedRule : IBusinessRule
    {
        private readonly DateTime gameDate;
        public FutureGameScoreCannotBeSettedRule(DateTime gameDate)
        {
            this.gameDate = gameDate;
        }

        public string Message => "Cannot set the score of the future game";

        public bool IsBroken() => DateTime.Now < gameDate;
    }
}
