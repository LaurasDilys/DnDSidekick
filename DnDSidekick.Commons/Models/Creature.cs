using System;
using System.Collections.Generic;
using System.Text;

namespace DnDSidekick.Commons.Models
{
    public abstract class Creature
    {
        public string Name { get; set; }
        public int ProficiencyBonus { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }



        //Ability Scores
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }


        //Skills
        //Strength based skills
        public int StrengthSavingThrow { get; set; }
        public int Athletics { get; set; }

        //Dexterity based skills
        public int DexteritySavingThrow { get; set; }
        public int Acrobatics { get; set; }
        public int SleightOfHand { get; set; }
        public int Stealth { get; set; }

        //Constitution based skills
        public int ConstitutionSavingThrow { get; set; }

        //Intelligence based skills
        public int IntelligenceSavingThrow { get; set; }
        public int Arcana { get; set; }
        public int History { get; set; }
        public int Investigation { get; set; }
        public int Nature { get; set; }
        public int Religion { get; set; }

        //Wisdom based skills
        public int WisdomSavingThrow { get; set; }
        public int AnimalHandling { get; set; }
        public int Insight { get; set; }
        public int Medicine { get; set; }
        public int Perception { get; set; }
        public int Survival { get; set; }

        //Charisma based skills
        public int CharismaSavingThrow { get; set; }
        public int Deception { get; set; }
        public int Intimidation { get; set; }
        public int Performance { get; set; }
        public int Persuasion { get; set; }
    }
}
