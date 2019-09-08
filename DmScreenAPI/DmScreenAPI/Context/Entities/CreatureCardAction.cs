using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Context.Entities
{
    public class CreatureCardAction
    {
        public int CreatureCardActionId { get; set; }
        public int CreatureCardId { get; set; }
        public int ActionId { get; set; }
    }
}
