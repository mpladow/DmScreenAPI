using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Context.Entities
{
    public class CreatureAction
    {
        public int CreatureActionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public CreatureCard CreatureCard { get; set; }
    }
}
