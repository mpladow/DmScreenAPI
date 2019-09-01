using System;

namespace DmScreenAPI.Context.Entities
{
    public class Creature
    {
        public int CreatureId { get; set; }
        public string Name { get; set; }
        public Nullable<int> Level { get; set; }
        public Nullable<int> CR { get; set; }

        public string Race { get; set; }
        public string Class { get; set; }

        public int Initiative { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public int PPerception { get; set; }
        public int PInsight { get; set; }
        public int PInvestigation { get; set; }

        public int AC { get; set; }

        public int? InitiativeBonus { get; set; }
        public int? StrengthBonus { get; set; }
        public int? DexterityBonus { get; set; }
        public int? ConstitutionBonus { get; set; }
        public int? WisdomBonus { get; set; }
        public int? CharismaBonus { get; set; }

        public string Image { get; set; }

        public int Speed { get; set; }

        public int? ProficiencyBonus { get; set; }
        public string Notes { get; set; }
        public bool isHostile { get; set; }
    }
}
