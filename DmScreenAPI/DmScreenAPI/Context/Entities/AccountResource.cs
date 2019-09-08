using DmScreenAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Context.Entities
{
    public class AccountResource
    {
        public int AccountResourceId { get; set; }
        public int AccountId { get; set; }
        public int ResourceId { get; set; }
        public decimal Sequence { get; set; }
        public ICollection<Account> Accounts { get; set; }
        public ICollection<Resource> Resources { get; set; }
    }
}
