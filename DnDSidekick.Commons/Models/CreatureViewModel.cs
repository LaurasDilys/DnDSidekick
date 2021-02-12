using System;
using System.Collections.Generic;
using System.Text;

namespace DnDSidekick.Commons.Models
{
    public class CreatureViewModel
    {
        public string Name { get; set; }
        public string SizeTypeAndAlignment { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }

        public string Speed { get; set; }

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }

        public string Skills { get; set; }
        public string Senses { get; set; }
        public string Languages { get; set; }
        public int ChallengeRating { get; set; }
        public int ProficiencyBonus { get; set; }
        public string Traits { get; set; }
        public string Tag { get; set; }
        public string Environments { get; set; }
    }
}
