using DnDSidekick.Business.Interfaces;
using DnDSidekick.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Models
{
    public class Character : ICreature
    {
        public Character() : this(0) { }

        public Character(int id)
        {
            Id = id;

            if (Id == 1)
            {
                ProficiencyBonus = 100;
            }
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public string Background { get; set; }
        public string Alignment { get; set; }
        public int Level { get; set; } = 1;
        public int ExperiencePoints { get; set; }
        public int ProficiencyBonus { get; set; } = 2;
        public int Inspiration { get; set; }


        public int ArmorClass { get; set; }
        public int TemporaryArmorClass { get; set; }


        public int HitPoints { get; set; } = 1;
        public int TemporaryHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }


        public int Initiative { get; set; }
        public int CurrentInitiative { get; set; }


        public int Speed { get; set; }
        public int CurrentSpeed { get; set; }


        public int UsedHitDice { get; set; }


        public bool DeathSaveSuccess1 { get; set; } = false;
        public bool DeathSaveSuccess2 { get; set; } = false;
        public bool DeathSaveSuccess3 { get; set; } = false;
        public bool DeathSaveFailure1 { get; set; } = false;
        public bool DeathSaveFailure2 { get; set; } = false;
        public bool DeathSaveFailure3 { get; set; } = false;



        //Abilities
        public Ability Strength { get; set; } = new Ability();
        public Ability Dexterity { get; set; } = new Ability();
        public Ability Constitution { get; set; } = new Ability();
        public Ability Intelligence { get; set; } = new Ability();
        public Ability Wisdom { get; set; } = new Ability();
        public Ability Charisma { get; set; } = new Ability();


        //Skills
        //Strength based
        public Skill Athletics { get; set; } = new Skill();

        //Dexterity based skills
        public Skill Acrobatics { get; set; } = new Skill();
        public Skill SleightOfHand { get; set; } = new Skill();
        public Skill Stealth { get; set; } = new Skill();

        //Intelligence based skills
        public Skill Arcana { get; set; } = new Skill();
        public Skill History { get; set; } = new Skill();
        public Skill Investigation { get; set; } = new Skill();
        public Skill Nature { get; set; } = new Skill();
        public Skill Religion { get; set; } = new Skill();

        //Wisdom based skills
        public Skill AnimalHandling { get; set; } = new Skill();
        public Skill Insight { get; set; } = new Skill();
        public Skill Medicine { get; set; } = new Skill();
        public Skill Perception { get; set; } = new Skill();
        public Skill Survival { get; set; } = new Skill();

        //Charisma based skills
        public Skill Deception { get; set; } = new Skill();
        public Skill Intimidation { get; set; } = new Skill();
        public Skill Performance { get; set; } = new Skill();
        public Skill Persuasion { get; set; } = new Skill();
    }
}
