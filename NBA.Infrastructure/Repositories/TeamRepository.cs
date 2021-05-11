using Microsoft.EntityFrameworkCore;
using NBA.Domain.Interfaces;
using NBA.Domain.Entities;
using NBA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Infrastructure.Repositories
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(NBADataContext dbContext) : base(dbContext)
        { }
        public override async Task<Team> GetAsync(Guid id)
        {
            return await dbContext.Set<Team>()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<Team[]> GetAllAsync()
        {
            return await dbContext.Set<Team>().ToArrayAsync();
        }
    }
}
