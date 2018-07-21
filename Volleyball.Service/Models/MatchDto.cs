using System;
using System.ComponentModel.DataAnnotations;
using Volleyball.Service.Entities;

namespace Volleyball.Service.Models
{
    public class MatchDto
    {
        [Key]
        public int MatchId { get; set; }
        public DateTime DateOfMatch { get; set; }
        public TeamDto HostTeam { get; set; }
        public TeamDto GuestTeam { get; set; }
    }
}
