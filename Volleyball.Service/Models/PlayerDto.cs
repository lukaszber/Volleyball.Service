using System.ComponentModel.DataAnnotations;
using Volleyball.Service.Entities;
using Volleyball.Service.Enums;

namespace Volleyball.Service.Models
{
    public class PlayerDto
    {
        [Key]
        public int PlayerId { get; set; }
        public int Number { get; set; }
        public virtual TeamDto Team { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CountryOfOrigin { get; set; }
        public int Age { get; set; }
        public Position Position { get; set; }
        public bool IsActive { get; set; }
    }
}
