using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Rules
{
    public class ScoreCannotBeNegativeRule : IBusinessRule
    {
        private readonly int score;

        public ScoreCannotBeNegativeRule(int score)
        {
            this.score = score;
        }

        public string Message => "Score cannot be negative";

        public bool IsBroken() => score < 0;
    }
}
