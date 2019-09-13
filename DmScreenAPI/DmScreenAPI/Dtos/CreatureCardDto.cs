using DmScreenAPI.Context.Entities;
using System.Collections.Generic;

namespace DmScreenAPI.Dtos
{
    public class CreatureCardDto
    {
        public int CreatureCardId { get; set; }
        public string Name { get; set; }
        public int AC { get; set; }
        public int Initiative { get; set; }
        public bool isHostile { get; set; }
        public int CurrentHP { get; set; }
        public int MaxHP { get; set; }
        public int PPerception { get; set; }
        public int PInvestigation { get; set; }
        public int PInsight { get; set; }
        public int? Strength { get; set; }
        public int? Dexterity { get; set; }
        public int? Constitution { get; set; }
        public int? Intelligence { get; set; }
        public int? Wisdom { get; set; }
        public int? Charisma { get; set; }
        public string Notes { get; set; }
        public bool RedIndicatorOn { get; set; }
        public bool GreenIndicatorOn { get; set; }
        public bool BlueIndicatorOn { get; set; }

        public List<CreatureAction> Actions { get; set; }
    }
}