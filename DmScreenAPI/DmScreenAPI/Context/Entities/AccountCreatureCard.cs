using DmScreenAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Context.Entities
{
    public class AccountCreatureCard
    {
        public int AccountCreatureCardId { get; set; }
        public int AccountId { get; set; }
        public int CreatureCardId { get; set; }
        public decimal Sequence { get; set; }
        public ICollection<CreatureCard> CreatureCards { get; set; }
        public ICollection<Account> Resources { get; set; }
    }
}
