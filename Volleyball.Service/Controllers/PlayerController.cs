using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Volleyball.Service.Entities;
using Volleyball.Service.Models;
using Volleyball.Service.Services.Interfaces;

namespace Volleyball.Service.Controllers
{
    [Route("api/players")]
    public class PlayerController : Controller
    {
        private IPlayerRepository _playerRepository;
        private ITeamRepository _teamRepository;

        public PlayerController(IPlayerRepository playerRepository, ITeamRepository teamRepository)
        {
            _playerRepository = playerRepository;
            _teamRepository = teamRepository;
        }
        [HttpPost]
        public IActionResult Post([FromBody] PlayerForCreationDto player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (player == null)
            {
                return BadRequest();
            }

            var playerEntity = Mapper.Map<Player>(player);

            _playerRepository.AddPlayer(playerEntity);

            if (!_playerRepository.Save())
            {
                throw new Exception("Creating an Player failed on save.");
            }

            var playerToReturn = Mapper.Map<PlayerDto>(playerEntity);

            return CreatedAtRoute("GetPlayer",
                new { id = playerToReturn.PlayerId },
                playerToReturn);
        }

        [HttpGet("{id}", Name = "GetPlayer")]
        public IActionResult Get(int id)
        {
            var playerFromRepo = _playerRepository.GetPlayer(id);
            if (playerFromRepo == null)
            {
                return NotFound();
            }

            var player = Mapper.Map<PlayerDto>(playerFromRepo);

            return Ok(player);
        }

        [HttpGet]
        public IActionResult Get()
        {
            var playersFromRepo = _playerRepository.GetPlayers();
            if (playersFromRepo == null)
            {
                return NotFound();
            }

            var players = Mapper.Map<IEnumerable<PlayerDto>>(playersFromRepo);

            return Ok(players);
        }

        [HttpGet("team/id")]
        public IActionResult GetByTeam(int id)
        {
            var team =_teamRepository.GetTeam(id);
            if (team == null)
            {
                return NotFound();
            }

            var playersFromRepo = _playerRepository.GetPlayers(team);
            if (playersFromRepo == null)
            {
                return NotFound();
            }

            var players = Mapper.Map<IEnumerable<PlayerDto>>(playersFromRepo);

            return Ok(players);
        }

    }
}
