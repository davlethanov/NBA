using NBA.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace NBA.Domain.Interfaces
{
    public interface IPlayerRepository : IRepositoryBase<Player>
    {
        Task<Player[]> GetAllAsync();
        Task CancelTeamAsync(Guid teamId);
    }
}
