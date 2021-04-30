using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.Models
{
    public class Player
    {
        public Guid Id { get; private set; }

        public string FirstName { get; private set; }

        public string SecondName { get; private set; }

        public DateTime BirthDate { get; private set; }

        public Guid TeamId { get; private set; }

        protected Player() { }

        public Player(string firstName, string secondName, DateTime birthDate, Guid teamId)
        {
            FirstName = firstName;
            SecondName = secondName;
            BirthDate = birthDate;
            TeamId = teamId;
        }
    }
}
