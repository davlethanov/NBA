using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBA.ApplicationCore.DTO;
using NBA.ApplicationCore.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NBA.Web.Controllers
{
    [Route("api/games")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService gameService;
        public GameController(IGameService teamService)
        {
            this.gameService = teamService;
        }

        [HttpGet]
        [Route("")]
        public async Task<JsonResult> GetAll()
        {
            var players = await gameService.GetAllAsync();
            return new JsonResult(players);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<JsonResult> Get(Guid id)
        {
            var team = await gameService.GetAsync(id);
            return new JsonResult(team);
        }

        [HttpPost]
        [Route("")]
        public async Task<JsonResult> Create([FromBody] GameDto gameDto)
        {
            var id = await gameService.CreateAsync(gameDto);
            return new JsonResult(id);
        }

        [HttpPut]
        [Route("")]
        public async Task<JsonResult> Update([FromBody] GameDto gameDto)
        {
            await gameService.UpdateAsync(gameDto);
            return new JsonResult("Updated successfully");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await gameService.DeleteAsync(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
