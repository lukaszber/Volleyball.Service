using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volleyball.Service.Entities;
using Volleyball.Service.Services.Interfaces;

namespace Volleyball.Service.Services.Repositories
{
    public class LeagueRepository : ILeagueRepository
    {
        private readonly VolleyballContext _volleyballContext;
        public LeagueRepository(VolleyballContext volleyballContext)
        {
            _volleyballContext = volleyballContext;
        }
        public League GetLeague(int leagueId)
        {
            return _volleyballContext.LeagueSet.Find(leagueId);
        }

        public void AddLeague(League league)
        {
            _volleyballContext.LeagueSet.Add(league);

        }

        public IEnumerable<League> GetLeagues()
        {
            return _volleyballContext.LeagueSet.ToList();
        }

        public void RemoveLeague(League league)
        {
            _volleyballContext.LeagueSet.Remove(league);
        }
        public bool Save()
        {
            return (_volleyballContext.SaveChanges() >= 0);
        }
    }
}
