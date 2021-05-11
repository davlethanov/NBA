
namespace NBA.Domain.Rules
{
    public class BasketballDrawImpossileRule : IBusinessRule
    {
        private readonly int awayTeamScore;
        private readonly int homeTeamScore;

        public BasketballDrawImpossileRule(int awayTeamScore, int homeTeamScore)
        {
            this.awayTeamScore = awayTeamScore;
            this.homeTeamScore = homeTeamScore;
        }

        public string Message => "Draw is impossible in basketball";

        public bool IsBroken() => awayTeamScore == homeTeamScore;
    }
}
