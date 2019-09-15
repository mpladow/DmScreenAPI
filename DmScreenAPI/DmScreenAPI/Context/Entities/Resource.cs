using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Context.Entities
{
    public class Resource
    {
        public int ResourceId { get; set; }
        public string Category { get; set; }
        public string Html { get; set; }
    }
}
