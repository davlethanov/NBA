using NBA.Domain.Base;
using System;
using System.Threading.Tasks;

namespace NBA.Domain.Interfaces
{
    public interface IRepositoryBase<T>
        where T : Entity
    {
        Task<T> GetAsync(Guid id);
        Task DeleteAsync(Guid id);
        Task<T> AddAsync(T entity);
        void UpdateAsync(T entity);
    }
}
