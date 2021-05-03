using FluentAssertions;
using NBA.ApplicationCore.Models;
using System;
using Xunit;

namespace NBA.Tests
{
    public class TeamTests
    {
        [Fact]
        public void Team_Create_Success()
        {
            // Arrange
            var name = "Ural";
            var city = "Yekaterinburg";

            // Act
            var team = new Team(name, city);

            // Assert
            team.Name.Should().Be(name);
            team.City.Should().Be(city);
        }
    }
}
