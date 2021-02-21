using DnDSidekick.Business.Interfaces;
using DnDSidekick.Commons;
using DnDSidekick.Commons.Models;
using DnDSidekick.Commons.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Models
{
    public class Character : ICharacter, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Character()
        {
            BuildListsOfSkills();
            BuildListOfAbilities();
            SetInitialAbilityScoreValues();

            Id = 0;
            Name = "";
            Level = 1;
            HitPoints = 1;
            CurrentHitPoints = 1;
        }

        public int Id { get; set; }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged();
            }
        }

        public string Class { get; set; } = "";
        public string Race { get; set; } = "";
        public string Background { get; set; } = "";
        public string Alignment { get; set; } = "";


        private int level;
        public int Level
        {
            get { return level; }
            set
            {
                level = value.Between(StaticValues.MinLevel, StaticValues.MaxLevel);
                ProficiencyBonus = StaticValues.ProfBonusFromLvl[level];
                int xp = StaticValues.XPfromLvl[level];
                if (ExperiencePoints < xp || (level != 20 && ExperiencePoints >= StaticValues.XPfromLvl[level + 1]))
                    ExperiencePoints = xp;
                OnPropertyChanged();
            }
        }

        private int experiencePoints;
        public int ExperiencePoints
        {
            get { return experiencePoints; }
            set
            {
                if (value < 0) { experiencePoints = 0; }
                else { experiencePoints = value; }
                int lvl = experiencePoints.ConvertToLvl();
                if (Level != lvl) Level = lvl;
                OnPropertyChanged();
            }
        }

        private int proficiencyBonus;
        public int ProficiencyBonus
        {
            get { return proficiencyBonus; }
            set
            {
                proficiencyBonus = value;
                SendNewProficiencyBonusToSkillsAndSavingThrows();
                OnPropertyChanged();
            }
        }
        public string Inspiration { get; set; } = "";


        private int armorClass;
        public int ArmorClass
        {
            get { return armorClass; }
            set
            {
                if (value < 0) { armorClass = 0; }
                else { armorClass = value; }
                OnPropertyChanged();
            }
        }

        private int currentArmorClass;
        public int CurrentArmorClass
        {
            get { return currentArmorClass; }
            set
            {
                if (value < 0) { currentArmorClass = 0; }
                else { currentArmorClass = value; }
                OnPropertyChanged();
            }
        }


        private int hitPoints;
        public int HitPoints
        {
            get { return hitPoints; }
            set
            {
                if (value < 0) { hitPoints = 0; }
                else { hitPoints = value; }
                OnPropertyChanged();
            }
        }

        private int temporaryHitPoints;
        public int TemporaryHitPoints
        {
            get { return temporaryHitPoints; }
            set
            {
                if (value < 0) { temporaryHitPoints = 0; }
                else { temporaryHitPoints = value; }
                OnPropertyChanged();
            }
        }

        private int currentHitPoints;
        public int CurrentHitPoints
        {
            get { return currentHitPoints; }
            set
            {
                currentHitPoints = value;
                OnPropertyChanged();
            }
        }


        public int Initiative { get; set; }

        private int currentInitiative;
        public int CurrentInitiative
        {
            get { return currentInitiative; }
            set
            {
                currentInitiative = value;
                OnPropertyChanged();
            }
        }


        public int Speed { get; set; }
        public int CurrentSpeed { get; set; }


        public int UsedHitDice { get; set; }


        public bool DeathSaveSuccess1 { get; set; }
        public bool DeathSaveSuccess2 { get; set; }
        public bool DeathSaveSuccess3 { get; set; }
        public bool DeathSaveFailure1 { get; set; }
        public bool DeathSaveFailure2 { get; set; }
        public bool DeathSaveFailure3 { get; set; }


        public string Traits { get; set; }
        public string Notes { get; set; }


        //Abilities
        public List<Ability> Abilities { get; set; } = new List<Ability>();
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


        private void BuildListsOfSkills()
        {
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

        private void BuildListOfAbilities()
        {
            Abilities.Add(Strength);
            Abilities.Add(Dexterity);
            Abilities.Add(Constitution);
            Abilities.Add(Intelligence);
            Abilities.Add(Wisdom);
            Abilities.Add(Charisma);
        }

        private void SendNewProficiencyBonusToSkillsAndSavingThrows()
        {
            foreach (Ability ability in Abilities)
            {
                ability.SavingThrow.ProficiencyBonus = ProficiencyBonus;
                foreach (Skill skill in ability.Skills)
                {
                    skill.ProficiencyBonus = ProficiencyBonus;
                }
            }
        }

        private void SetInitialAbilityScoreValues()
        {
            foreach (Ability ability in Abilities)
            {
                ability.Score = StaticValues.InitialAbilityScoreValue;
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
