using NBA.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace NBA.ApplicationCore.DTO
{
    public class GameDto
    {
        public Guid Id { get; set; }
        public Guid AwayTeamId { get; set; }
        public Guid HomeTeamId { get; set; }
        public DateTime Date { get; set; }

        public int? AwayTeamScore { get; set; }
        public int? HomeTeamScore { get; set; }

        public static GameDto FromEntity(Game entity)
        {
            return new GameDto()
            {
                Id = entity.Id,
                AwayTeamId = entity.AwayTeamId,
                HomeTeamId = entity.HomeTeamId,
                Date = entity.Date,

                AwayTeamScore = entity.Score?.AwayTeamScore,
                HomeTeamScore = entity.Score?.HomeTeamScore,
            };
        }
    }
}
