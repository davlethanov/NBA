using NBA.Domain.Base;
using NBA.Domain.Rules;
using System;

namespace NBA.Domain.Entities
{
    public class Player : Entity
    {
        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public TeamIdentity TeamIdentity { get; private set; }

        protected Player() { }

        public Player(string firstName, string secondName, DateTime birthDate)
            : base()
        {
            CheckRule(new FirstNameCannotBeEmptyRule(firstName));
            CheckRule(new SecondNameCannotBeEmptyRule(secondName));
            CheckRule(new PlayerAgeMustBeOverSettingMinValueRule(birthDate));

            FirstName = firstName;
            SecondName = secondName;
            BirthDate = birthDate;
        }

        public void SetFirstName(string firstName)
        {
            CheckRule(new FirstNameCannotBeEmptyRule(firstName));

            FirstName = firstName;
        }

        public void SetSecondName(string secondName)
        {
            CheckRule(new SecondNameCannotBeEmptyRule(secondName));

            SecondName = secondName;
        }

        public void SetBirthDate(DateTime birthDate)
        {
            CheckRule(new PlayerAgeMustBeOverSettingMinValueRule(birthDate));

            BirthDate = birthDate;
        }

        public void SetTeamIdentity(Guid teamId, int number)
        {
            TeamIdentity = new TeamIdentity(teamId, number);
        }

        public void CancelTeamIdentity()
        {
            TeamIdentity = null;
        }
    }
}
