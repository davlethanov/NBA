using NBA.ApplicationCore.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Models
{
    public class Score : ValueObject<Score>
    {
        public int AwayTeamScore { get; private set; }
        public int HomeTeamScore { get; private set; }

        public Score(int awayTeamScore, int homeTeamScore)
        {
            CheckRule(new ScoreCannotBeNegativeRule(awayTeamScore));
            CheckRule(new ScoreCannotBeNegativeRule(homeTeamScore));

            AwayTeamScore = awayTeamScore;
            HomeTeamScore = homeTeamScore;
        }

        protected override bool EqualsCore(Score other)
        {
            return AwayTeamScore == other.AwayTeamScore && HomeTeamScore == other.HomeTeamScore;
        }

        protected override int GetHashCodeCore()
        {
            return AwayTeamScore.GetHashCode() ^ HomeTeamScore.GetHashCode();
        }
    }
}
