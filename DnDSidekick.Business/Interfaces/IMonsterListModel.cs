using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Interfaces
{
    public interface IMonsterListModel
    {
        double ChallengeRating { get; set; }
        int MonsterId { get; set; }
        string Name { get; set; }
        string SizeTypeAndAlignment { get; set; }
        int ArmorClass { get; set; }
        int HitPoints { get; set; }

        string Speed { get; set; }

        int Strength { get; set; }
        int Dexterity { get; set; }
        int Constitution { get; set; }
        int Intelligence { get; set; }
        int Wisdom { get; set; }
        int Charisma { get; set; }

        string Senses { get; set; }
        string Tag { get; set; }

        int StrengthSavingThrow { get; set; }
        int Athletics { get; set; }

        int DexteritySavingThrow { get; set; }
        int Acrobatics { get; set; }
        int SleightOfHand { get; set; }
        int Stealth { get; set; }

        int ConstitutionSavingThrow { get; set; }

        int IntelligenceSavingThrow { get; set; }
        int Arcana { get; set; }
        int History { get; set; }
        int Investigation { get; set; }
        int Nature { get; set; }
        int Religion { get; set; }

        int WisdomSavingThrow { get; set; }
        int AnimalHandling { get; set; }
        int Insight { get; set; }
        int Medicine { get; set; }
        int Perception { get; set; }
        int Survival { get; set; }

        int CharismaSavingThrow { get; set; }
        int Deception { get; set; }
        int Intimidation { get; set; }
        int Performance { get; set; }
        int Persuasion { get; set; }

        int ProficiencyBonus { get; set; }
    }
}
