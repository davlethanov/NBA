using NBA.ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NBA.Infrastructure.Repositories
{
    public interface IRepositoryBase<T>
        where T : Entity
    {
        Task<T> GetAcync(Guid id);
        Task DeleteAsync(Guid id);
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
    }
}
