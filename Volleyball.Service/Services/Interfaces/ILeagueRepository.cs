using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volleyball.Service.Entities;

namespace Volleyball.Service.Services.Interfaces
{
    public interface ILeagueRepository
    {
        League GetLeague(int leagueId);
        void AddLeague(League league);
        IEnumerable<League> GetLeagues();
        void RemoveLeague(League league);
        bool Save();
    }
}
