using NBA.Domain.Entities;

namespace NBA.ApplicationCore.DTO
{
    public static class DtoExtensions
    {
        public static TeamDto ToDto(this Team entity)
        {
            return TeamDto.FromEntity(entity);
        }

        public static PlayerDto ToDto(this Player entity)
        {
            return PlayerDto.FromEntity(entity);
        }

        public static GameDto ToDto(this Game entity)
        {
            return GameDto.FromEntity(entity);
        }
    }
}
