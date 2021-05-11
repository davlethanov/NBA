using NBA.Domain.Base;
using NBA.Domain.Rules;
using System;

namespace NBA.Domain.Entities
{
    public class TeamIdentity : ValueObject<TeamIdentity>
    {
        public Guid TeamId { get; private set; }

        public Team Team { get; private set; }

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
