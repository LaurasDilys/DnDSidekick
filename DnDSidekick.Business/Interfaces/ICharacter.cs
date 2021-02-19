using DnDSidekick.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Interfaces
{
    public interface ICharacter
    {
        int Id { get; set; }
        string Name { get; set; }
        string Class { get; set; }
        string Race { get; set; }
        string Background { get; set; }
        string Alignment { get; set; }


        int Level { get; set; }
        int ExperiencePoints { get; set; }
        int ProficiencyBonus { get; set; }
        string Inspiration { get; set; }


        int ArmorClass { get; set; }
        int CurrentArmorClass { get; set; }


        int HitPoints { get; set; }
        int TemporaryHitPoints { get; set; }
        int CurrentHitPoints { get; set; }


        int Initiative { get; set; }
        int CurrentInitiative { get; set; }


        int Speed { get; set; }
        int CurrentSpeed { get; set; }


        int UsedHitDice { get; set; }


        bool DeathSaveSuccess1 { get; set; }
        bool DeathSaveSuccess2 { get; set; }
        bool DeathSaveSuccess3 { get; set; }
        bool DeathSaveFailure1 { get; set; }
        bool DeathSaveFailure2 { get; set; }
        bool DeathSaveFailure3 { get; set; }

        string Traits { get; set; }
        string Notes { get; set; }


        //Abilities
        List<Ability> Abilities { get; set; }
        Ability Strength { get; set; }
        Ability Dexterity { get; set; }
        Ability Constitution { get; set; }
        Ability Intelligence { get; set; }
        Ability Wisdom { get; set; }
        Ability Charisma { get; set; }


        //Skills
        //Strength based
        Skill Athletics { get; set; }

        //Dexterity based skills
        Skill Acrobatics { get; set; }
        Skill SleightOfHand { get; set; }
        Skill Stealth { get; set; }

        //Intelligence based skills
        Skill Arcana { get; set; }
        Skill History { get; set; }
        Skill Investigation { get; set; }
        Skill Nature { get; set; }
        Skill Religion { get; set; }

        //Wisdom based skills
        Skill AnimalHandling { get; set; }
        Skill Insight { get; set; }
        Skill Medicine { get; set; }
        Skill Perception { get; set; }
        Skill Survival { get; set; }

        //Charisma based skills
        Skill Deception { get; set; }
        Skill Intimidation { get; set; }
        Skill Performance { get; set; }
        Skill Persuasion { get; set; }
    }
}
