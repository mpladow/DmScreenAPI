using DmScreenAPI.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DmScreenAPI.Context.Entities
{
    public class AccountCreatureCard
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int AccountCreatureCardId { get; set; }
        public int AccountId { get; set; }
        public int CreatureCardId { get; set; }
        public decimal Sequence { get; set; }
        public CreatureCard CreatureCard { get; set; }
        public Account Account { get; set; }
    }
}
