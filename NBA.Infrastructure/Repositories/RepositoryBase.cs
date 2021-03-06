using Microsoft.EntityFrameworkCore;
using NBA.Domain.Interfaces;
using NBA.Domain.Base;
using NBA.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Infrastructure.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : Entity
    {
        protected readonly NBADataContext dbContext;

        public RepositoryBase(NBADataContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await GetAsync(id);

            if (entity != null)
            {
                dbContext.Set<T>().Remove(entity);
            }
        }

        public abstract Task<T> GetAsync(Guid id);

        public void UpdateAsync(T entity)
        {
            dbContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
