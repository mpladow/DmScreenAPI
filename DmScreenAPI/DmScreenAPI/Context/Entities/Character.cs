using System;

namespace DmScreenAPI.Context.Entities
{
    public class Character
    {
        public string Name { get; set; }
        public string Category { get; set; }
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

        public int PassivePerception { get; set; }
        public int PassiveInsight { get; set; }
        public int PassiveInvestigation { get; set; }

        public int AC { get; set; }

        public int StrSavingThrow { get; set; }
        public int DexSavingThrow { get; set; }
        public int ConSavingThrow { get; set; }
        public int IntSavingThrow { get; set; }
        public int WisSavingThrow { get; set; }
        public int ChaSavingThrow { get; set; }

        public string Image { get; set; }

        public int Speed { get; set; }

        public int ProficiencyBonus { get; set; }
        public int InitiativeBonus { get; set; }

        public string Notes { get; set; }
    }
}
