using Microsoft.EntityFrameworkCore;
using NBA.Domain.Interfaces;
using NBA.Domain.Entities;
using NBA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace NBA.Infrastructure.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(NBADataContext dbContext) : base(dbContext)
        { }

        public override async Task<Game> GetAsync(Guid id)
        {
            return await dbContext.Set<Game>()
                .Include(g => g.AwayTeam)
                .Include(g => g.HomeTeam)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        public async Task<Game[]> GetAllAsync()
        {
            return await dbContext.Set<Game>()
                    .Include(g => g.AwayTeam)
                    .Include(g => g.HomeTeam)
                    .OrderBy(g => g.Date)
                    .ToArrayAsync();
        }

        public async Task DeleteByTeamAsync(Guid teamId)
        {
            var games = await dbContext.Set<Game>().Where(g => g.AwayTeamId == teamId || g.HomeTeamId == teamId).ToArrayAsync();
            dbContext.Set<Game>().RemoveRange(games);
        }
    }
}
