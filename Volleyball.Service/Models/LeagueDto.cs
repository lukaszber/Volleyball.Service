using System.ComponentModel.DataAnnotations;

namespace Volleyball.Service.Models
{
    public class LeagueDto
    {
        [Key]
        public int LeagueId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
