using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Dtos
{
    public class AccountResourceDto
    {
        public int AccountResourceId { get; set; }
        public int AccountId { get; set; }
        public List<ResourceDto> Resources { get; set; }
        public decimal Sequence { get; set; }
    }
}
