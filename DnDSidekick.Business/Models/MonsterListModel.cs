using DnDSidekick.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Models
{
    public class MonsterListModel : IMonsterListModel
    {
        public double ChallengeRating { get; set; }
        public int MonsterId { get; set; }
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

        public string Senses { get; set; }
        public string Tag { get; set; }


        public int StrengthSavingThrow { get; set; }
        public int Athletics { get; set; }

        public int DexteritySavingThrow { get; set; }
        public int Acrobatics { get; set; }
        public int SleightOfHand { get; set; }
        public int Stealth { get; set; }
        
        public int ConstitutionSavingThrow { get; set; }

        public int IntelligenceSavingThrow { get; set; }
        public int Arcana { get; set; }
        public int History { get; set; }
        public int Investigation { get; set; }
        public int Nature { get; set; }
        public int Religion { get; set; }

        public int WisdomSavingThrow { get; set; }
        public int AnimalHandling { get; set; }
        public int Insight { get; set; }
        public int Medicine { get; set; }
        public int Perception { get; set; }
        public int Survival { get; set; }

        public int CharismaSavingThrow { get; set; }
        public int Deception { get; set; }
        public int Intimidation { get; set; }
        public int Performance { get; set; }
        public int Persuasion { get; set; }

        public int ProficiencyBonus { get; set; }

    }
}
