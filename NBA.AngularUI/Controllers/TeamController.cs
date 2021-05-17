using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBA.ApplicationCore.DTO;
using NBA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.AngularUI.Controllers
{
    [Route("api/teams")]
    [ApiController]
    public class TeamController : ControllerBase
    {
        private readonly ITeamService teamService;
        public TeamController(ITeamService teamService)
        {
            this.teamService = teamService;
        }

        [HttpGet]
        [Route("")]
        public async Task<JsonResult> GetAll()
        {
            var teams = await teamService.GetAllAsync();
            return new JsonResult(teams);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<JsonResult> Get(Guid id)
        {
            var team = await teamService.GetAsync(id);
            return new JsonResult(team);
        }

        [HttpPost]
        [Route("")]
        public async Task<JsonResult> Create([FromBody] TeamDto teamDto)
        {
            var id = await teamService.CreateAsync(teamDto);
            return new JsonResult(id);
        }

        [HttpPut]
        [Route("")]
        public async Task Update([FromBody] TeamDto teamDto)
        {
            await teamService.UpdateAsync(teamDto);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task Delete(Guid id)
        {
            await teamService.DeleteAsync(id);
        }
    }
}
