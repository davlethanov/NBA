﻿using Microsoft.EntityFrameworkCore;
using NBA.ApplicationCore.Models;
using NBA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Infrastructure.Repositories
{
    public class GameRepository : RepositoryBase<Game>, IGameRepository
    {
        public GameRepository(NBADataContext dbContext) : base(dbContext)
        { }

        public override async Task<Game> GetAcync(Guid id)
        {
            return await dbContext.Set<Game>()
                .Include(g => g.AwayTeam)
                .Include(g => g.HomeTeam)
                .FirstOrDefaultAsync(g => g.Id == id);
        }
    }
}