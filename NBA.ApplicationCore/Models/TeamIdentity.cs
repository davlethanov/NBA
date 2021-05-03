using NBA.ApplicationCore.Rules;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Models
{
    public class TeamIdentity : ValueObject<TeamIdentity>
    {
        public Guid TeamId { get; private set; }

        public int Number { get; private set; }

        public TeamIdentity(Guid teamId, int number)
        {
            CheckRule(new NumberCannotBeNegativeRule(number));

            TeamId = teamId;
            Number = number;
        }

        protected override bool EqualsCore(TeamIdentity other)
        {
            return TeamId == other.TeamId && Number == other.Number;
        }

        protected override int GetHashCodeCore()
        {
            return TeamId.GetHashCode() ^ Number.GetHashCode();
        }
    }
}
