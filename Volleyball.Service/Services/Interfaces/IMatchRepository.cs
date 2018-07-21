using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volleyball.Service.Entities;

namespace Volleyball.Service.Services.Interfaces
{
    public interface IMatchRepository
    {
        void NewMatch(Match match);
        bool Save();
    }
}
