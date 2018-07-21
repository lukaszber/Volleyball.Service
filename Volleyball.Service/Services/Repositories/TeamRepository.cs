using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volleyball.Service.Entities;
using Volleyball.Service.Services.Interfaces;

namespace Volleyball.Service.Services.Repositories
{
    public class TeamRepository : ITeamRepository
    {
        private VolleyballContext _volleyballContext;
        public TeamRepository(VolleyballContext volleyballContext)
        {
            _volleyballContext = volleyballContext;
        }


        public Team GetTeam(int teamId)
        {
            return _volleyballContext.TeamSet.Include(c => c.League).ToList().Find(t => t.TeamId == teamId);
        }
        public void AddTeam(Team team)
        {
            team.League = _volleyballContext.LeagueSet.Find(team.League.LeagueId);
            _volleyballContext.TeamSet.Add(team);

        }
        public IEnumerable<Team> GetTeams()
        {
            return _volleyballContext.TeamSet.Include(c => c.League).ToList();
        }
        public void RemoveTeam(Team team)
        {
            _volleyballContext.Remove(team);
        }
        public IEnumerable<Team> GetTeamsByLeague(League league)
        {
            return _volleyballContext.TeamSet.Where(e => e.League.Equals(league)).ToList();
        }
        public bool Save()
        {
            return (_volleyballContext.SaveChanges() >= 0);
        }
    }
}
