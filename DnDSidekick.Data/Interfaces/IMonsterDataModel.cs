using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Interfaces
{
    public interface IMonsterDataModel
    {
        int MonsterId { get; set; }
        string Name { get; set; }
        Size Size { get; set; }
        CreatureType Type { get; set; }
        Alignment Alignment { get; set; }
        int ArmorClass { get; set; }
        int HitPoints { get; set; }

        int WalkSpeed { get; set; }
        int BurrowSpeed { get; set; }
        int ClimbSpeed { get; set; }
        int FlySpeed { get; set; }
        int SwimSpeed { get; set; }

        int Strength { get; set; }
        int Dexterity { get; set; }
        int Constitution { get; set; }
        int Intelligence { get; set; }
        int Wisdom { get; set; }
        int Charisma { get; set; }

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

        int Blindsight { get; set; }
        int Darkvision { get; set; }
        int Tremorsense { get; set; }
        int Truesight { get; set; }

        double ChallengeRating { get; set; }
        int ProficiencyBonus { get; set; }
        ICollection<Trait> Traits { get; set; }
        ICollection<Language> Languages { get; set; }
        bool CanSpeak { get; set; }
        ICollection<Environ> Environs { get; set; }
        Tag Tag { get; set; }

        //public virtual ICollection<DamageType> DamageVulnerabilities { get; set; }
        //public virtual ICollection<DamageType> DamageResistances { get; set; }
        //public virtual ICollection<DamageType> DamageImmunities { get; set; }
        //public virtual ICollection<Condition> ConditionImmunities { get; set; }
    }
}
