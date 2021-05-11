using Microsoft.EntityFrameworkCore;
using NBA.Domain.Interfaces;
using NBA.Domain.Entities;
using NBA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Infrastructure.Repositories
{
    public class PlayerRepository : RepositoryBase<Player>, IPlayerRepository
    {
        public PlayerRepository(NBADataContext dbContext) : base(dbContext)
        { }

        public override async Task<Player> GetAsync(Guid id)
        {
            return await dbContext.Set<Player>()
                .Include(p => p.TeamIdentity.Team)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Player[]> GetAllAsync()
        {
            return await dbContext.Set<Player>().ToArrayAsync();
        }
    }
}
