using NBA.ApplicationCore.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Models
{
    public class Game : Entity
    {
        public Guid AwayTeamId { get; private set; }

        public Team AwayTeam { get; private set; }

        public Guid HomeTeamId { get; private set; }

        public Team HomeTeam { get; private set; }

        public DateTime Date { get; private set; }

        public Score Score { get; private set; }

        protected Game() { }

        public Game(Guid awayTeamId, Guid homeTeamId, DateTime date)
        {
            AwayTeamId = awayTeamId;
            HomeTeamId = homeTeamId;
            Date = date;
        }

        public void SetScore(int awayTeamScore, int homeTeamScore)
        {
            CheckRule(new FutureGameScoreCannotBeSettedRule(Date));

            Score = new Score(awayTeamScore, homeTeamScore);
        }
    }
}
