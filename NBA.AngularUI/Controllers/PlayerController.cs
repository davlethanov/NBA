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
    [Route("api/players")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly IPlayerService playerService;
        public PlayerController(IPlayerService teamService)
        {
            this.playerService = teamService;
        }

        [HttpGet]
        [Route("")]
        public async Task<JsonResult> GetAll()
        {
            var players = await playerService.GetAllAsync();
            return new JsonResult(players);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<JsonResult> Get(Guid id)
        {
            var team = await playerService.GetAsyns(id);
            return new JsonResult(team);
        }

        [HttpPost]
        [Route("")]
        public async Task<JsonResult> Create([FromBody] PlayerDto playerDto)
        {
            var id = await playerService.CreateAsync(playerDto);
            return new JsonResult(id);
        }

        [HttpPut]
        [Route("")]
        public async Task<JsonResult> Update([FromBody] PlayerDto playerDto)
        {
            await playerService.UpdateAsync(playerDto);
            return new JsonResult("Updated successfully");
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<JsonResult> Delete(Guid id)
        {
            await playerService.DeleteAsync(id);
            return new JsonResult("Deleted successfully");
        }
    }
}
