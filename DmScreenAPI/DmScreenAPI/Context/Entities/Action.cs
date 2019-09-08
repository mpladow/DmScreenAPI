using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Context.Entities
{
    public class Action
    {
        public int ActionId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
