using Microsoft.EntityFrameworkCore;
using NBA.ApplicationCore.Models;
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

        public override async Task<Player> GetAcync(Guid id)
        {
            return await dbContext.Set<Player>()
                .Include(p => p.TeamIdentity.Team)
                .FirstOrDefaultAsync(p => p.Id == id);
        }
    }
}
