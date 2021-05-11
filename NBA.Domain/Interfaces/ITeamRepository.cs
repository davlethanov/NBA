using NBA.Domain.Entities;
using System.Threading.Tasks;

namespace NBA.Domain.Interfaces
{
    public interface ITeamRepository : IRepositoryBase<Team>
    {
        Task<Team[]> GetAllAsync();
    }
}
