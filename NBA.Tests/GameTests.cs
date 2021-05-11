using FluentAssertions;
using NBA.Domain.Base;
using NBA.Domain.Entities;
using NBA.Domain.Rules;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace NBA.Tests
{
    public class GameTests : TestBase
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

        [Fact]
        public void Game_SetScore_Success()
        {
            // Arrange
            var pastGame = CreatePastGame();
            var awayTeamScore = 100;
            var homeTeamScore = 120;

            // Act
            pastGame.SetScore(awayTeamScore, homeTeamScore);

            // Assert
            pastGame.Score.Should().NotBeNull();
            pastGame.Score.AwayTeamScore.Should().Be(awayTeamScore);
            pastGame.Score.HomeTeamScore.Should().Be(homeTeamScore);
            pastGame.Score.AwayTeamResult.Should().Be(GameResult.Loose);
            pastGame.Score.HomeTeamResult.Should().Be(GameResult.Win);
        }

        [Fact]
        public void Game_SetFutureGameScore_FutureGameScoreCannotBeSettedRuleIsBroken()
        {
            var futureGame = CreateFutureGame();

            AssertBrokenRule<FutureGameScoreCannotBeSettedRule>(() => futureGame.SetScore(3, 2));
        }

        [Fact]
        public void Game_SetNegativeScore_ScoreCannotBeNegativeRuleIsBroken()
        {
            var pastGame = CreatePastGame();

            AssertBrokenRule<ScoreCannotBeNegativeRule>(() => pastGame.SetScore(-3, 2));
            AssertBrokenRule<ScoreCannotBeNegativeRule>(() => pastGame.SetScore(3, -2));
        }

        [Fact]
        public void Game_MakeDraw_BasketballDrawImpossileRuleIsBroken()
        {
            var pastGame = CreatePastGame();

            AssertBrokenRule<BasketballDrawImpossileRule>(() => pastGame.SetScore(100, 100));
        }

        private Game CreatePastGame()
        {
            var awayTeamId = Guid.NewGuid();
            var homeTeamId = Guid.NewGuid();
            var date = DateTime.Today.AddDays(-1);

            return new Game(awayTeamId, homeTeamId, date);
        }

        private Game CreateFutureGame()
        {
            var awayTeamId = Guid.NewGuid();
            var homeTeamId = Guid.NewGuid();
            var date = DateTime.Today.AddDays(1);

            return new Game(awayTeamId, homeTeamId, date);
        }
    }
}
