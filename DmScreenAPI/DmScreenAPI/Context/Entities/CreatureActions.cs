using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Context.Entities
{
    public class CreatureActions
    {
        public int CreatureActionId { get; set; }
        public string ActionDescription { get; set; }
        public int CreatureCardId { get; set; }
    }
}
