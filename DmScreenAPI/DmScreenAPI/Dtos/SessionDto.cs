using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Dtos
{
    public class SessionDto
    {
        public int AccountId { get; set; }
        public string Token { get; set; }
        public List<ResourceDto> Resources { get; set; }
        public List<CreatureCardDto> CreatureCards { get; set; }
    }
}
