using NBA.Domain.Base;
using NBA.Domain.Rules;

namespace NBA.Domain.Entities
{
    public class Score : ValueObject<Score>
    {
        public int AwayTeamScore { get; private set; }
        public int HomeTeamScore { get; private set; }

        public GameResult AwayTeamResult { get; private set; }
        public GameResult HomeTeamResult { get; private set; }

        public Score(int awayTeamScore, int homeTeamScore)
        {
            CheckRule(new ScoreCannotBeNegativeRule(awayTeamScore));
            CheckRule(new ScoreCannotBeNegativeRule(homeTeamScore));
            CheckRule(new BasketballDrawImpossileRule(awayTeamScore, homeTeamScore));

            AwayTeamScore = awayTeamScore;
            HomeTeamScore = homeTeamScore;
            if (awayTeamScore > homeTeamScore)
            {
                AwayTeamResult = GameResult.Win;
                HomeTeamResult = GameResult.Loose;
            }
            else
            {
                AwayTeamResult = GameResult.Loose;
                HomeTeamResult = GameResult.Win;
            }
        }

        protected override bool EqualsCore(Score other)
        {
            return AwayTeamScore == other.AwayTeamScore && HomeTeamScore == other.HomeTeamScore &&
                    AwayTeamResult == other.AwayTeamResult && HomeTeamResult == other.HomeTeamResult;
        }

        protected override int GetHashCodeCore()
        {
            return AwayTeamScore.GetHashCode() ^ HomeTeamScore.GetHashCode() ^
                    AwayTeamResult.GetHashCode() ^ HomeTeamResult.GetHashCode();
        }
    }
}
