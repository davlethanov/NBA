using FluentAssertions;
using NBA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NBA.Tests
{
    public class PlayerTests
    {
        [Fact]
        public void Player_Create_Success()
        {
            // Arrange
            var firstName = "Vasya";
            var secondName = "Pupkin";
            var birthDate = new DateTime(1990, 1, 1);
            var teamId = Guid.NewGuid();

            // Act
            var player = new Player(firstName, secondName, birthDate, teamId);

            // Assert
            player.FirstName.Should().Be(firstName);
            player.SecondName.Should().Be(secondName);
            player.BirthDate.Should().Be(birthDate);
            player.TeamId.Should().Be(teamId);
        }
    }
}
