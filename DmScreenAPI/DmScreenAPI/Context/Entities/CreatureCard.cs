using System;
using System.Collections.Generic;

namespace DmScreenAPI.Context.Entities
{
    public class CreatureCard
    {
        public int CreatureCardId { get; set; }
        public bool isHostile { get; set; }
        public int AccountId { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int? Initiative { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Constitution { get; set; }
        public int? Wisdom { get; set; }
        public int? Charisma { get; set; }
        public string Notes { get; set; }
        public bool RedIndicatorOn { get; set; }
        public bool GreenIndicatorOn { get; set; }
        public bool BlueIndicatorOn { get; set; }

        public ICollection<Action> Actions { get; set; }

    }
}
