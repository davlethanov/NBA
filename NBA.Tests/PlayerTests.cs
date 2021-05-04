using FluentAssertions;
using NBA.ApplicationCore.Models;
using NBA.ApplicationCore.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NBA.Tests
{
    public class PlayerTests : TestBase
    {
        private const int validAge = ApplicationCore.Utils.Settings.MinNBAPlayerAge + 1;
        private const int invalidAge = ApplicationCore.Utils.Settings.MinNBAPlayerAge - 1;

        [Fact]
        public void Player_CreateWithoutTeam_Success()
        {
            // Arrange
            var firstName = "Michael";
            var secondName = "Jordan";
            var birthDate = new DateTime(1963, 2, 17);
            var teamId = Guid.NewGuid();
            var number = 23;

            // Act
            var player = new Player(firstName, secondName, birthDate, teamId, number);

            // Assert
            player.FirstName.Should().Be(firstName);
            player.SecondName.Should().Be(secondName);
            player.BirthDate.Should().Be(birthDate);
            player.TeamIdentity.TeamId.Should().Be(teamId);
            player.TeamIdentity.Number.Should().Be(number);
        }

        [Fact]
        public void Player_Create_Success()
        {
            // Arrange
            var firstName = "Michael";
            var secondName = "Jordan";
            var birthDate = new DateTime(1963, 2, 17);
            var teamId = Guid.NewGuid();
            var number = 23;

            // Act
            var player = new Player(firstName, secondName, birthDate, teamId, number);

            // Assert
            player.FirstName.Should().Be(firstName);
            player.SecondName.Should().Be(secondName);
            player.BirthDate.Should().Be(birthDate);
            player.TeamIdentity.TeamId.Should().Be(teamId);
            player.TeamIdentity.Number.Should().Be(number);
        }

        [Fact]
        public void Player_CreateWithEmptyFirstName_FirstNameCannotBeEmptyRuleIsBroken()
        {
            AssertBrokenRule<FirstNameCannotBeEmptyRule>(
                () => new Player(firstName: string.Empty, "SecondName", DateTime.Today.AddYears(-validAge)));
        }

        [Fact]
        public void Player_CreateWithEmptySecondName_SecondNameCannotBeEmptyRuleIsBroken()
        {
            AssertBrokenRule<SecondNameCannotBeEmptyRule>(
                () => new Player("FirstName", secondName: string.Empty, DateTime.Today.AddYears(-validAge)));
        }

        [Fact]
        public void Player_CreateTooYoung_PlayerAgeMustBeOverSettingMinValueRuleIsBroken()
        {
            AssertBrokenRule<PlayerAgeMustBeOverSettingMinValueRule>(
                () => new Player("FirstName", "SecondName", DateTime.Today.AddYears(-invalidAge)));
        }

        [Fact]
        public void Player_CreateWithoutTeamButWithNumber_PlayerWithoutTeamCannotHasNumberRuleIsBroken()
        {
            AssertBrokenRule<PlayerWithoutTeamCannotHasNumberRule>(
                () => new Player("FirstName", "SecondName", DateTime.Today.AddYears(-validAge), null, 23));
        }

        [Fact]
        public void Player_CreateWithTeamButWithoutNumber_TeamPlayerMustHaveNumberRuleIsBroken()
        {
            AssertBrokenRule<TeamPlayerMustHaveNumberRule>(
                () => new Player("FirstName", "SecondName", DateTime.Today.AddYears(-validAge), Guid.NewGuid(), null));
        }

        [Fact]
        public void Player_CreateWithNegativeNumber_NumberCannotBeNegativeRuleIsBroken()
        {
            AssertBrokenRule<NumberCannotBeNegativeRule>(
                () => new Player("FirstName", "SecondName", DateTime.Today.AddYears(-validAge), Guid.NewGuid(), -23));
        }

        [Fact]
        public void Player_SetFirstName_Success()
        {
            // Arrange
            var player = CreatePlayer();
            var newFirstName = "Cobe";

            // Act
            player.SetFirstName(newFirstName);

            // Assert
            player.FirstName.Should().Be(newFirstName);
        }

        [Fact]
        public void Player_SetEmptyFirstName_FirstNameCannotBeEmptyRuleIsBroken()
        {
            var player = CreatePlayer();

            AssertBrokenRule<FirstNameCannotBeEmptyRule>(() => player.SetFirstName(string.Empty));
        }

        [Fact]
        public void Player_SetSecondName_Success()
        {
            // Arrange
            var player = CreatePlayer();
            var newSecondName = "Bryant";

            // Act
            player.SetSecondName(newSecondName);

            // Assert
            player.SecondName.Should().Be(newSecondName);
        }

        [Fact]
        public void Player_SetEmptySecondName_SecondNameCannotBeEmptyRuleIsBroken()
        {
            var player = CreatePlayer();

            AssertBrokenRule<SecondNameCannotBeEmptyRule>(() => player.SetSecondName(string.Empty));
        }

        [Fact]
        public void Player_SetBirthDate_Success()
        {
            // Arrange
            var player = CreatePlayer();
            var newBirthDate = new DateTime(1978, 8, 23);

            // Act
            player.SetBirthDate(newBirthDate);

            // Assert
            player.BirthDate.Should().Be(newBirthDate);
        }

        [Fact]
        public void Player_SetTooYoungBirthDate_PlayerAgeMustBeOverSettingMinValueRuleIsBroken()
        {
            var player = CreatePlayer();

            AssertBrokenRule<PlayerAgeMustBeOverSettingMinValueRule>(() => player.SetBirthDate(DateTime.Today.AddYears(-invalidAge)));
        }

        [Fact]
        public void Player_SetTeamIdentity_Succes()
        {
            // Arrange
            var player = CreatePlayer();
            var newTeamId = Guid.NewGuid();
            int newNumber = 24;

            // Act
            player.SetTeamIdentity(newTeamId, newNumber);

            // Assert
            player.TeamIdentity.TeamId.Should().Be(newTeamId);
            player.TeamIdentity.Number.Should().Be(newNumber);
        }

        [Fact]
        public void Player_SetTeamIdentityWithNegativeNumber_NumberCannotBeNegativeRuleIsBroken()
        {
            var player = CreatePlayer();

            AssertBrokenRule<NumberCannotBeNegativeRule>(() => player.SetTeamIdentity(Guid.NewGuid(), -23));
        }

        [Fact]
        public void Player_CancelTeamIdentity_Succes()
        {
            // Arrange
            var player = CreatePlayer();

            // Act
            player.CancelTeamIdentity();

            // Assert
            player.TeamIdentity.Should().BeNull();
        }

        private Player CreatePlayer()
        {
            var firstName = "Michael";
            var secondName = "Jordan";
            var birthDate = new DateTime(1963, 2, 17);
            var teamId = Guid.NewGuid();
            var number = 23;

            return new Player(firstName, secondName, birthDate, teamId, number);
        }
    }
}
