using NBA.ApplicationCore.DTO;
using NBA.ApplicationCore.Interfaces;
using NBA.Domain.Entities;
using NBA.Domain.Interfaces;
using NBA.Infrastructure.Data;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.ApplicationCore.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly Func<NBADataContext, IPlayerRepository> playerRepositoryFactory;

        public PlayerService(Func<NBADataContext, IPlayerRepository> playerRepositoryFactory)
        {
            this.playerRepositoryFactory = playerRepositoryFactory;
        }

        public async Task<PlayerDto[]> GetAllAsync()
        {
            using (var dataContext = new NBADataContext())
            {
                var playerRepository = playerRepositoryFactory(dataContext);
                return (await playerRepository.GetAllAsync()).Select(p => p.ToDto()).ToArray();
            }
        }

        public async Task<PlayerDto> GetAsyns(Guid id)
        {
            using (var dataContext = new NBADataContext())
            {
                var playerRepository = playerRepositoryFactory(dataContext);
                return (await playerRepository.GetAsync(id)).ToDto();
            }
        }

        public async Task<Guid> CreateAsync(PlayerDto playerDto)
        {
            using (var dataContext = new NBADataContext())
            {
                var playerRepository = playerRepositoryFactory(dataContext);
                var player = new Player(playerDto.FirstName, playerDto.SecondName, playerDto.BirthDate);
                if (playerDto.TeamId.HasValue && playerDto.Number.HasValue)
                {
                    player.SetTeamIdentity(playerDto.TeamId.Value, playerDto.Number.Value);
                }
                var id = (await playerRepository.AddAsync(player)).Id;
                await dataContext.SaveChangesAsync();
                return id;
            }
        }

        public async Task UpdateAsync(PlayerDto playerDto)
        {
            using (var dataContext = new NBADataContext())
            {
                var playerRepository = playerRepositoryFactory(dataContext);
                var player = await playerRepository.GetAsync(playerDto.Id);
                player.SetFirstName(playerDto.FirstName);
                player.SetSecondName(playerDto.SecondName);
                player.SetBirthDate(playerDto.BirthDate);
                if (playerDto.TeamId.HasValue && playerDto.Number.HasValue)
                {
                    player.SetTeamIdentity(playerDto.TeamId.Value, playerDto.Number.Value);
                }
                else
                {
                    player.CancelTeamIdentity();
                }
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var dataContext = new NBADataContext())
            {
                var playerRepository = playerRepositoryFactory(dataContext);
                await playerRepository.DeleteAsync(id);
            }
        }
    }
}
