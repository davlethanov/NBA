using NBA.Domain.Entities;
using System;

namespace NBA.ApplicationCore.DTO
{
    public class TeamDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }

        public static TeamDto FromEntity (Team entity)
        {
            return new TeamDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                City = entity.City,
            };
        }
    }
}
