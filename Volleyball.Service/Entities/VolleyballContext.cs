using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Volleyball.Service.Entities
{
    public sealed class VolleyballContext : DbContext
    {
        public VolleyballContext(DbContextOptions<VolleyballContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public DbSet<League> LeagueSet { get; set; }
        public DbSet<Team> TeamSet { get; set; }
        public DbSet<Player> PlayerSet { get; set; }
        public DbSet<Match> MatcheSet { get; set; }
    }
}
