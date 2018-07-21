using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volleyball.Service.Entities
{
    public class Match
    {
        [Key]
        public int MatchId { get; set; }
        public DateTime DateOfMatch { get; set; }
        public Team HostTeam { get; set; }
        public Team GuestTeam { get; set; }
    }
}
