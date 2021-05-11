using FluentAssertions;
using NBA.Domain.Entities;
using NBA.Domain.Rules;
using System;
using Xunit;

namespace NBA.Tests
{
    public class PlayerTests : TestBase
    {
        private const int validAge = Domain.Utils.Settings.MinNBAPlayerAge + 1;
        private const int invalidAge = Domain.Utils.Settings.MinNBAPlayerAge - 1;

        [Fact]
        public void Player_CreateWithoutTeam_Success()
        {
            // Arrange
            var firstName = "Michael";
            var secondName = "Jordan";
            var birthDate = new DateTime(1963, 2, 17);

            // Act
            var player = new Player(firstName, secondName, birthDate);

            // Assert
            player.FirstName.Should().Be(firstName);
            player.SecondName.Should().Be(secondName);
            player.BirthDate.Should().Be(birthDate);
            player.TeamIdentity.Should().BeNull();
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
            var teamId = Guid.NewGuid();
            int number = 23;

            // Act
            player.SetTeamIdentity(teamId, number);

            // Assert
            player.TeamIdentity.TeamId.Should().Be(teamId);
            player.TeamIdentity.Number.Should().Be(number);
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
            var teamId = Guid.NewGuid();
            var number = 23;
            player.SetTeamIdentity(teamId, number);

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

            return new Player(firstName, secondName, birthDate);
        }
    }
}
