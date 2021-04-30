using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Models
{
    public class Game
    {
        public Guid Id { get; private set; }

        public Guid AwayTeamId { get; private set; }

        public Guid HomeTeamId { get; private set; }

        public DateTime Date { get; private set; }

        public int? AwayTeamScore { get; private set; }

        public int? HomeTeamScore { get; private set; }

        protected Game() { }

        public Game(Guid awayTeamId, Guid homeTeamId, DateTime date)
        {
            AwayTeamId = awayTeamId;
            HomeTeamId = homeTeamId;
            Date = date;
        }
    }
}
