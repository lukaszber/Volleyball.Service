using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volleyball.Service.Entities;

namespace Volleyball.Service.Services.Interfaces
{
    public interface ITeamRepository
    {
        Team GetTeam(int teamId);
        void AddTeam(Team team);
        IEnumerable<Team> GetTeams();
        void RemoveTeam(Team team);
        IEnumerable<Team> GetTeamsByLeague(League league);
        bool Save();
    }
}
