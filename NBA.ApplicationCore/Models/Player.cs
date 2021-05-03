using NBA.ApplicationCore.Rules;
using NBA.ApplicationCore.Utils;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Models
{
    public class Player : Entity
    {
        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public TeamIdentity TeamIdentity { get; private set; }

        protected Player() { }

        public Player(string firstName, string secondName, DateTime birthDate, Guid? teamId = null, int? number = null)
            : base()
        {
            CheckRule(new PlayerFirstNameCannotBeEmptyRule(firstName));
            CheckRule(new PlayerSecondNameCannotBeEmptyRule(secondName));
            CheckRule(new PlayerAgeMustBeOverSettingMinValueRule(birthDate));
            CheckRule(new PlayerWithoutTeamCannotHasNumberRule(teamId, number));
            CheckRule(new TeamPlayerMustHaveNonNegativeNumberRule(teamId, number));

            FirstName = firstName;
            SecondName = secondName;
            BirthDate = birthDate;

            if (teamId.HasValue)
            {
                TeamIdentity = new TeamIdentity(teamId.Value, number.Value);
            }
        }

        public void SetFirstName(string firstName)
        {
            CheckRule(new PlayerFirstNameCannotBeEmptyRule(firstName));

            FirstName = firstName;
        }

        public void SetSecondName(string secondName)
        {
            CheckRule(new PlayerSecondNameCannotBeEmptyRule(secondName));

            SecondName = secondName;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            CheckRule(new PlayerAgeMustBeOverSettingMinValueRule(birthDate));

            BirthDate = birthDate;
        }

        public void SetTeam(Guid teamId)
        {
            TeamIdentity = new TeamIdentity(teamId, TeamIdentity.Number);
        }

        public void SetNumber(int number)
        {
            TeamIdentity = new TeamIdentity(TeamIdentity.TeamId, number);
        }

        public void CancelTeam()
        {
            TeamIdentity = null;
        }
    }
}
