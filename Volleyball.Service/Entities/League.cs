using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Volleyball.Service.Entities
{
    public class League
    {

        public int LeagueId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

    }
}
