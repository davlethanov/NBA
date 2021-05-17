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
        public string AwayTeamName { get; set; }
        public Guid HomeTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public DateTime Date { get; set; }

        public int? AwayTeamScore { get; set; }
        public int? HomeTeamScore { get; set; }

        public static GameDto FromEntity(Game entity)
        {
            return new GameDto()
            {
                Id = entity.Id,
                AwayTeamId = entity.AwayTeamId,
                AwayTeamName = entity.AwayTeam.Name,
                HomeTeamId = entity.HomeTeamId,
                HomeTeamName = entity.HomeTeam.Name,
                Date = entity.Date,

                AwayTeamScore = entity.Score?.AwayTeamScore,
                HomeTeamScore = entity.Score?.HomeTeamScore,
            };
        }
    }
}
