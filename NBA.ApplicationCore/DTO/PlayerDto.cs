using NBA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.DTO
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime BirthDate { get; set; }
        public Guid? TeamId { get; set; }
        public string TeamName { get; set; }
        public int? TeamNumber { get; set; }

        public static PlayerDto FromEntity(Player entity)
        {
            return new PlayerDto()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                SecondName = entity.SecondName,
                BirthDate = entity.BirthDate,
                TeamId = entity.TeamIdentity?.TeamId,
                TeamName = entity.TeamIdentity?.Team?.Name,
                TeamNumber = entity.TeamIdentity?.Number,
            };
        }
    }
}
