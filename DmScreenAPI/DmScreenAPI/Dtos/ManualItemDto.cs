using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Dtos
{
    public class ManualItemDto
    {
        public int ManualItemId { get; set; }
        public string Category { get; set; }
        public string Subcategory { get; set; }
        public string Html { get; set; }
    }
}
