using FluentAssertions;
using NBA.Domain.Entities;
using NBA.Domain.Rules;
using Xunit;

namespace NBA.Tests
{
    public class TeamTests : TestBase
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
            team.FullName.Should().Be($"{city} {name}");
        }

        [Fact]
        public void Team_CreateWithEmptyName_TeamNameCannotBeEmptyRuleIsBroken()
        {
            AssertBrokenRule<TeamNameCannotBeEmptyRule>(() => new Team(name: string.Empty, "City"));
        }

        [Fact]
        public void Team_CreateWithEmptyCity_TeamCityCannotBeEmptyRuleIsBroken()
        {
            AssertBrokenRule<TeamCityCannotBeEmptyRule>(() => new Team("Name", city: string.Empty));
        }

        [Fact]
        public void Team_SetName_Success()
        {
            // Arrange
            var team = CreateTeam();
            var newName = "Bulls";

            // Act
            team.SetName(newName);

            // Assert
            team.Name.Should().Be(newName);
        }

        [Fact]
        public void Team_SetEmptyName_TeamNameCannotBeEmptyRuleIsBroken()
        {
            var team = CreateTeam();

            AssertBrokenRule<TeamNameCannotBeEmptyRule>(() => team.SetName(string.Empty));
        }

        [Fact]
        public void Team_SetCity_Success()
        {
            // Arrange
            var team = CreateTeam();
            var newCity = "Chicago";

            // Act
            team.SetCity(newCity);

            // Assert
            team.City.Should().Be(newCity);
        }

        [Fact]
        public void Team_SetEmptyCity_TeamCityCannotBeEmptyRuleIsBroken()
        {
            var team = CreateTeam();

            AssertBrokenRule<TeamCityCannotBeEmptyRule>(() => team.SetCity(string.Empty));
        }

        private Team CreateTeam()
        {
            var name = "Ural";
            var city = "Yekaterinburg";
            var team = new Team(name, city);
            return team;
        }
    }
}
