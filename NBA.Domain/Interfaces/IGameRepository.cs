using NBA.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace NBA.Domain.Interfaces
{
    public interface IGameRepository : IRepositoryBase<Game>
    {
        Task<Game[]> GetAllAsync();
        Task DeleteByTeamAsync(Guid teamId);
    }
}
