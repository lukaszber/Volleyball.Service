using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volleyball.Service.Entities;
using Volleyball.Service.Services.Interfaces;

namespace Volleyball.Service.Services.Repositories
{
    public class MatchRepository : IMatchRepository
    {
        private readonly VolleyballContext _volleyballContext;
        public MatchRepository(VolleyballContext volleyballContext)
        {
            _volleyballContext = volleyballContext;
        }
        public void NewMatch(Match match)
        {
            _volleyballContext.MatcheSet.Add(match);
        }
        public bool Save()
        {
            return (_volleyballContext.SaveChanges() >= 0);
        }
    }
}
