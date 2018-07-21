using System.ComponentModel.DataAnnotations;
using Volleyball.Service.Entities;
using Volleyball.Service.Enums;

namespace Volleyball.Service.Models
{
    public class TeamDto
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public virtual League League { get; set; }
    }
}
