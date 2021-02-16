using DnDSidekick.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Interfaces
{
    public interface ICreature
    {
        int Id { get; set; }
        string Name { get; set; }
        int ArmorClass { get; set; }
        int HitPoints { get; set; }
        int ProficiencyBonus { get; set; }


        //Abilities
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
