using NBA.ApplicationCore.DTO;
using NBA.ApplicationCore.Interfaces;
using NBA.Domain.Entities;
using NBA.Domain.Interfaces;
using NBA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.ApplicationCore.Services
{
    public class GameService : IGameService
    {
        private readonly Func<NBADataContext, IGameRepository> gameRepositoryFactory;

        public GameService(Func<NBADataContext, IGameRepository> gameRepositoryFactory)
        {
            this.gameRepositoryFactory = gameRepositoryFactory;
        }

        public async Task<GameDto[]> GetAllAsync()
        {
            using (var dataContext = new NBADataContext())
            {
                var gameRepository = gameRepositoryFactory(dataContext);
                return (await gameRepository.GetAllAsync()).Select(g => g.ToDto()).ToArray();
            }
        }

        public async Task<GameDto> GetAsync(Guid id)
        {
            using (var dataContext = new NBADataContext())
            {
                var gameepository = gameRepositoryFactory(dataContext);
                var game = await gameepository.GetAsync(id);
                return game != null ? game.ToDto() : null;
            }
        }

        public async Task<Guid> CreateAsync(GameDto gameDto)
        {
            using (var dataContext = new NBADataContext())
            {
                var gameRepository = gameRepositoryFactory(dataContext);
                var game = new Game(gameDto.AwayTeamId, gameDto.HomeTeamId, gameDto.Date);
                if (gameDto.AwayTeamScore.HasValue &&
                    gameDto.HomeTeamScore.HasValue)
                {
                    game.SetScore(gameDto.AwayTeamScore.Value, gameDto.HomeTeamScore.Value);
                }
                var id = (await gameRepository.AddAsync(game)).Id;
                await dataContext.SaveChangesAsync();
                return id;
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var dataContext = new NBADataContext())
            {
                var gameRepository = gameRepositoryFactory(dataContext);
                await gameRepository.DeleteAsync(id);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task SetScore(Guid id, ScoreDto scoreDto)
        {
            using (var dataContext = new NBADataContext())
            {
                var gameRepository = gameRepositoryFactory(dataContext);
                var game = await gameRepository.GetAsync(id);
                game.SetScore(scoreDto.AwayTeamScore, scoreDto.HomeTeamScore);
                gameRepository.UpdateAsync(game);
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
