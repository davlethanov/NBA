using FluentAssertions;
using NBA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NBA.Tests
{
    public class GameTests
    {
        [Fact]
        public void Game_Create_Success()
        {
            // Arrange
            var awayTeamId = Guid.NewGuid();
            var homeTeamId = Guid.NewGuid();
            var date = DateTime.Today;

            // Act
            var game = new Game(awayTeamId, homeTeamId, date);

            // Assert
            game.AwayTeamId.Should().Be(awayTeamId);
            game.HomeTeamId.Should().Be(homeTeamId);
            game.Date.Should().Be(date);
            game.Score.Should().BeNull();
        }
    }
}
