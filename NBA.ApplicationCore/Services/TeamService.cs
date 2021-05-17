using NBA.ApplicationCore.Interfaces;
using System;
using System.Threading.Tasks;
using NBA.ApplicationCore.DTO;
using System.Linq;
using NBA.Domain.Entities;
using NBA.Domain.Interfaces;
using NBA.Infrastructure.Data;

namespace NBA.ApplicationCore.Services
{
    public class TeamService : ITeamService
    {
        private readonly Func<NBADataContext, ITeamRepository> teamRepositoryFactory;
        private readonly Func<NBADataContext, IPlayerRepository> playerRepositoryFactory;
        private readonly Func<NBADataContext, IGameRepository> gameRepositoryFactory;

        public TeamService(Func<NBADataContext, ITeamRepository> teamRepositoryFactory,
                            Func<NBADataContext, IPlayerRepository> playerRepositoryFactory,
                            Func<NBADataContext, IGameRepository> gameRepositoryFactory)
        {
            this.teamRepositoryFactory = teamRepositoryFactory;
            this.playerRepositoryFactory = playerRepositoryFactory;
            this.gameRepositoryFactory = gameRepositoryFactory;
        }

        public async Task<TeamDto[]> GetAllAsync()
        {
            using (var dataContext = new NBADataContext())
            {
                var teamRepository = teamRepositoryFactory(dataContext);
                return (await teamRepository.GetAllAsync()).Select(t => t.ToDto()).ToArray();
            }
        }

        public async Task<TeamDto> GetAsync(Guid id)
        {
            using (var dataContext = new NBADataContext())
            {
                var teamRepository = teamRepositoryFactory(dataContext);
                var team = await teamRepository.GetAsync(id);
                return team != null ? team.ToDto() : null;
            }
        }

        public async Task<Guid> CreateAsync(TeamDto teamDto)
        {
            using (var dataContext = new NBADataContext())
            {
                var teamRepository = teamRepositoryFactory(dataContext);
                var id = (await teamRepository.AddAsync(new Team(teamDto.Name, teamDto.City))).Id;
                await dataContext.SaveChangesAsync();
                return id;
            }
        }

        public async Task UpdateAsync(TeamDto teamDto)
        {
            using (var dataContext = new NBADataContext())
            {
                var teamRepository = teamRepositoryFactory(dataContext);
                var team = await teamRepository.GetAsync(teamDto.Id);
                team.SetName(teamDto.Name);
                team.SetCity(teamDto.City);
                teamRepository.UpdateAsync(team);
                await dataContext.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            using (var dataContext = new NBADataContext())
            {
                var teamRepository = teamRepositoryFactory(dataContext);
                var playerRepository = playerRepositoryFactory(dataContext);
                var gameRepository = gameRepositoryFactory(dataContext);

                await playerRepository.CancelTeamAsync(id);
                await gameRepository.DeleteByTeamAsync(id);
                await teamRepository.DeleteAsync(id);
                await dataContext.SaveChangesAsync();
            }
        }
    }
}
