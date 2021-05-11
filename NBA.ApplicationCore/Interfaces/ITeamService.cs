using NBA.ApplicationCore.DTO;
using System;
using System.Threading.Tasks;

namespace NBA.ApplicationCore.Interfaces
{
    public interface ITeamService
    {
        Task<TeamDto[]> GetAllAsync();
        Task<TeamDto> GetAsync(Guid id);
        Task<Guid> CreateAsync(TeamDto teamDto);
        Task UpdateAsync(TeamDto teamDto);
        Task DeleteAsync(Guid id);
    }
}
