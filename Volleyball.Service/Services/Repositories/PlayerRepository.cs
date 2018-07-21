using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volleyball.Service.Entities;
using Volleyball.Service.Services.Interfaces;

namespace Volleyball.Service.Services.Repositories
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly VolleyballContext _volleyballContext;
        public PlayerRepository(VolleyballContext volleyballContext)
        {
            _volleyballContext = volleyballContext;
        }
        public Player GetPlayer(int id)
        {
            return _volleyballContext.PlayerSet.Find(id);
        }

        public IEnumerable<Player> GetPlayers()
        {
            return _volleyballContext.PlayerSet.Include(t => t.Team).Include(t => t.Team.League).ToList();
        }

        public IEnumerable<Player> GetPlayers(Team team)
        {
            team = _volleyballContext.TeamSet.Find(team.TeamId);

            return _volleyballContext.PlayerSet.Where(c => c.Team.Equals(team)).ToList();
        }

        public void AddPlayer(Player player)
        {
            player.Team.League = _volleyballContext.LeagueSet.Find(player.Team.League.LeagueId);
            player.Team = _volleyballContext.TeamSet.Find(player.Team.TeamId);
            _volleyballContext.PlayerSet.Add(player);
        }

        public void DisablePlayer(Player player)
        {
            if (!player.IsActive) return;
            player.IsActive = false;
            _volleyballContext.PlayerSet.Attach(player);
            _volleyballContext.Entry(player).Property(x => x.IsActive).IsModified = true;
        }

        public void ActivatePlayer(Player player)
        {
            if (player.IsActive) return;
            player.IsActive = true;
            _volleyballContext.PlayerSet.Attach(player);
            _volleyballContext.Entry(player).Property(x => x.IsActive).IsModified = false;
        }

        public void RemovePlayer(Player player)
        {
             _volleyballContext.PlayerSet.Remove(player);

        }

        public bool Save()
        {
            return (_volleyballContext.SaveChanges() >= 0);
        }
    }
}
