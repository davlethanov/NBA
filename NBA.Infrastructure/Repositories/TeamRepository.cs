using Microsoft.EntityFrameworkCore;
using NBA.ApplicationCore.Models;
using NBA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Infrastructure.Repositories
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(NBADataContext dbContext) : base(dbContext)
        { }
        public override async Task<Team> GetAcync(Guid id)
        {
            return await dbContext.Set<Team>()
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
