using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Volleyball.Service.Entities;
using Volleyball.Service.Models;
using Volleyball.Service.Services.Interfaces;

namespace Volleyball.Service.Controllers
{
    [Route("api/teams")]
    public class TeamController: Controller
    {
        private ITeamRepository _teamRepository; 
        public TeamController(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }
        [HttpGet("{id}",Name = "GetTeam")]
        public IActionResult Get(int teamId)
        {
            var teamFromRepo = _teamRepository.GetTeam(teamId);
            if (teamFromRepo == null)
            {
                return NotFound();
            }

            var team = Mapper.Map<TeamDto>(teamFromRepo);

            return Ok(team);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TeamForCreationDto team)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (team == null)
            {
                return BadRequest();
            }

            var teamEntity = Mapper.Map<Team>(team);

            _teamRepository.AddTeam(teamEntity);

            if (!_teamRepository.Save())
            {
                throw new Exception("Creating an Team failed on save.");
            }

            var teamToReturn = Mapper.Map<TeamDto>(teamEntity);

            return CreatedAtRoute("GetTeam",
                new { id = teamToReturn.TeamId },
                teamToReturn);
        }


        [HttpGet]
        public IActionResult Get()
        {
            var teamsFromRepo = _teamRepository.GetTeams();
            if (teamsFromRepo == null)
            {
                return NotFound();
            }

            var teams = Mapper.Map<IEnumerable<TeamDto>>(teamsFromRepo);

            return Ok(teams);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var teamFromRepo = _teamRepository.GetTeam(id);
            if (teamFromRepo == null)
            {
                return NotFound();
            }

            _teamRepository.RemoveTeam(teamFromRepo);

            if (!_teamRepository.Save())
            {
                throw new Exception("Deleting an team failed on save.");
            }

            return NoContent();
        }
    }
}
