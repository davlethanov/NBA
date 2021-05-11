using NBA.ApplicationCore.DTO;
using System;
using System.Threading.Tasks;

namespace NBA.ApplicationCore.Interfaces
{
    public interface IPlayerService
    {
        Task<PlayerDto> GetAsyns(Guid id);
        Task<PlayerDto[]> GetAllAsync();
        Task<Guid> CreateAsync(PlayerDto playerDto);
        Task UpdateAsync(PlayerDto playerDto);
        Task DeleteAsync(Guid id);
    }
}
