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
    [Route("api/leagues")]
    public class LeagueController:Controller
    {

        private ILeagueRepository _leagueRepository;

        public LeagueController(ILeagueRepository leagueRepository)
        {
            _leagueRepository = leagueRepository;
        }
        [HttpPost]
        public IActionResult Post([FromBody] LeagueForCreationDto league)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (league == null)
            {
                return BadRequest();
            }

            var leagueEntity = Mapper.Map<League>(league);

            _leagueRepository.AddLeague(leagueEntity);

            if (!_leagueRepository.Save())
            {
                throw new Exception("Creating an league failed on save.");
            }

            var leagueToReturn = Mapper.Map<LeagueDto>(leagueEntity);

            return CreatedAtRoute("GetLeague",
                new { id = leagueToReturn.LeagueId },
                leagueToReturn);
        }


        [HttpGet("{id}", Name = "GetLeague")]
        public IActionResult Get(int id)
        {
            var leagueFromRepo = _leagueRepository.GetLeague(id);
            if (leagueFromRepo == null)
            {
                return NotFound();
            }

            var league = Mapper.Map<LeagueDto>(leagueFromRepo);

            return Ok(league);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var leaguesFromRepo = _leagueRepository.GetLeagues();
            if (leaguesFromRepo == null)
            {
                return NotFound();
            }

            var leagues = Mapper.Map<IEnumerable<LeagueDto>>(leaguesFromRepo);

            return Ok(leagues);
        }
    }
}
