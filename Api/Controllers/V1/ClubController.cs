using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectApi.Controllers.V1
{
    [ApiController]
    [Route("v1/[controller]")]   
    public class ClubController : ControllerBase
    {
        private readonly IClubService _clubService;

        public ClubController(IClubService clubService) =>
            _clubService = clubService;

        [HttpGet("RecoverAll")]
        [Route("RecoverAll")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> RecoverAll()
        {
            var clubs = await _clubService.RecoverAllClubs();

            return Ok(clubs);
        }

        [HttpPost("Register")]
        [Route("Register")]
        [Produces("application/json")]
        [Consumes("application/json")]
        public async Task<IActionResult> Register(Club club)
        {
            var id = await _clubService.RegisterAClub(club);

            return Ok(id);
        }
    }
}
