using System;
using System.Collections.Generic;
using System.Text;

namespace DnDSidekick.Commons.Models
{
    public abstract class Creature
    {
        public Creature(int id)
        {
            Id = id;

            Strength.Skills.Add(Athletics);

            Dexterity.Skills.Add(Acrobatics);
            Dexterity.Skills.Add(SleightOfHand);
            Dexterity.Skills.Add(Stealth);

            Intelligence.Skills.Add(Arcana);
            Intelligence.Skills.Add(History);
            Intelligence.Skills.Add(Investigation);
            Intelligence.Skills.Add(Nature);
            Intelligence.Skills.Add(Religion);

            Wisdom.Skills.Add(AnimalHandling);
            Wisdom.Skills.Add(Insight);
            Wisdom.Skills.Add(Medicine);
            Wisdom.Skills.Add(Perception);
            Wisdom.Skills.Add(Survival);

            Charisma.Skills.Add(Deception);
            Charisma.Skills.Add(Intimidation);
            Charisma.Skills.Add(Performance);
            Charisma.Skills.Add(Persuasion);
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; } = 1;
        public int ProficiencyBonus { get; set; } = 2;


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
