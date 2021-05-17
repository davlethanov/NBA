using NBA.ApplicationCore.DTO;
using NBA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NBA.ApplicationCore.Interfaces
{
    public interface IGameService
    {
        Task<GameDto> GetAsync(Guid id);
        Task<GameDto[]> GetAllAsync();
        Task<Guid> CreateAsync(GameDto gameDto);
        Task DeleteAsync(Guid id);
        Task SetScore(Guid Id, ScoreDto scoreDto);
    }
}
