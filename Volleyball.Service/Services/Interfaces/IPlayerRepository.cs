using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volleyball.Service.Entities;

namespace Volleyball.Service.Services.Interfaces
{
    public interface IPlayerRepository
    {
        Player GetPlayer(int id);
        IEnumerable<Player> GetPlayers();
        IEnumerable<Player> GetPlayers(Team team);
        void AddPlayer(Player player);
        void DisablePlayer(Player player);
        void ActivatePlayer(Player player);
        void RemovePlayer(Player player);
        bool Save();
    }
}
