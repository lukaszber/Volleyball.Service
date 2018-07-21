using System.ComponentModel.DataAnnotations;

namespace Volleyball.Service.Models
{
    public class TeamForCreationDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public virtual LeagueDto League { get; set; }
    }
}
