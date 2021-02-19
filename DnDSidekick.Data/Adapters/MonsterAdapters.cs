using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Data.Interfaces;
using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Adapters
{
    public static class MonsterAdapters
    {
        public static List<IMonsterDataModel> IntoWildShapeOptionsFor(this List<MonsterDataModel> monsters, ICharacter character)
        {
            List<IMonsterDataModel> wildShapeOptions = new List<IMonsterDataModel>();

            foreach (IMonsterDataModel monster in monsters)
            {
                IMonsterDataModel wildShape = new MonsterDataModel();
                wildShape = character.WildShapedInto(monster);
                wildShapeOptions.Add(wildShape);
            }

            return wildShapeOptions;
        }

        public static List<int> GetSkillModifiersValues(this IMonsterDataModel monster)
        {
            List<int> monsterSkillModifiers = new List<int>()
            {
                monster.StrengthSavingThrow,
                monster.Athletics,

                monster.DexteritySavingThrow,
                monster.Acrobatics,
                monster.SleightOfHand,
                monster.Stealth,

                monster.ConstitutionSavingThrow,

                monster.IntelligenceSavingThrow,
                monster.Arcana,
                monster.History,
                monster.Investigation,
                monster.Nature,
                monster.Religion,

                monster.WisdomSavingThrow,
                monster.AnimalHandling,
                monster.Insight,
                monster.Medicine,
                monster.Perception,
                monster.Survival,

                monster.CharismaSavingThrow,
                monster.Deception,
                monster.Intimidation,
                monster.Performance,
                monster.Persuasion
            };

            return monsterSkillModifiers;
        }

        public static IMonsterDataModel WildShapedInto(this ICharacter character, IMonsterDataModel monster)
        {
            ///
            /// <explanation of Wild Shape rules>
            /// Your game Statistics are replaced by the Statistics of the beast,
            /// but you retain your Intelligence, Wisdom, and Charisma scores...
            ///

            IMonsterDataModel wildShapedCharacter = ManageDb.GetMonsterFromDataBase(monster.MonsterId);

            wildShapedCharacter.Intelligence = character.Intelligence.Score;
            wildShapedCharacter.Wisdom = character.Wisdom.Score;
            wildShapedCharacter.Charisma = character.Charisma.Score;

            List<int> monsterSkillModifiers = monster.GetSkillModifiersValues();

            List<int> applicableSkillModifiers = new List<int>();

            /// 
            /// You also retain all of your skill and saving throw Proficiencies,
            /// in addition to gaining those of the creature.
            /// If the creature has the same proficiency as you
            /// and the bonus in its stat block is higher than yours,
            /// use the creature's bonus instead of yours.
            ///
            /// Meaning, you get the higher skill modifier.
            /// Either you gain the monsters, or you keep yours –
            /// whichever one is HIGHER...
            ///

            int i = 0;
            foreach (Ability ability in character.Abilities)
            {
                int characterSavingThrowModifier = ability.SavingThrow.Modifier;
                applicableSkillModifiers
                        .Add(Math.Max(characterSavingThrowModifier, monsterSkillModifiers[i++]));
                foreach (Skill skill in ability.Skills)
                {
                    int characterSkillModifier = skill.Modifier;
                    applicableSkillModifiers
                        .Add(Math.Max(characterSkillModifier, monsterSkillModifiers[i++]));
                }
            }

            i = 0;

            wildShapedCharacter.StrengthSavingThrow = applicableSkillModifiers[i++];
            wildShapedCharacter.Athletics = applicableSkillModifiers[i++];

            wildShapedCharacter.DexteritySavingThrow = applicableSkillModifiers[i++];
            wildShapedCharacter.Acrobatics = applicableSkillModifiers[i++];
            wildShapedCharacter.SleightOfHand = applicableSkillModifiers[i++];
            wildShapedCharacter.Stealth = applicableSkillModifiers[i++];

            wildShapedCharacter.ConstitutionSavingThrow = applicableSkillModifiers[i++];

            wildShapedCharacter.IntelligenceSavingThrow = applicableSkillModifiers[i++];
            wildShapedCharacter.Arcana = applicableSkillModifiers[i++];
            wildShapedCharacter.History = applicableSkillModifiers[i++];
            wildShapedCharacter.Investigation = applicableSkillModifiers[i++];
            wildShapedCharacter.Nature = applicableSkillModifiers[i++];
            wildShapedCharacter.Religion = applicableSkillModifiers[i++];

            wildShapedCharacter.WisdomSavingThrow = applicableSkillModifiers[i++];
            wildShapedCharacter.AnimalHandling = applicableSkillModifiers[i++];
            wildShapedCharacter.Insight = applicableSkillModifiers[i++];
            wildShapedCharacter.Medicine = applicableSkillModifiers[i++];
            wildShapedCharacter.Perception = applicableSkillModifiers[i++];
            wildShapedCharacter.Survival = applicableSkillModifiers[i++];

            wildShapedCharacter.CharismaSavingThrow = applicableSkillModifiers[i++];
            wildShapedCharacter.Deception = applicableSkillModifiers[i++];
            wildShapedCharacter.Intimidation = applicableSkillModifiers[i++];
            wildShapedCharacter.Performance = applicableSkillModifiers[i++];
            wildShapedCharacter.Persuasion = applicableSkillModifiers[i];

            return wildShapedCharacter;
        }

        public static void TransformIntoListModel(this IMonsterDataModel monsterDb, IMonsterListModel monster)
        {
            monster.ChallengeRating = monsterDb.ChallengeRating;

            monster.MonsterId = monsterDb.MonsterId;
            monster.Name = monsterDb.Name;
            monster.SizeTypeAndAlignment = $"{monsterDb.Size.Name} {monsterDb.Type.Name.ToLower()}, {monsterDb.Alignment.Name.ToLower()}";
            monster.ArmorClass = monsterDb.ArmorClass;
            monster.HitPoints = monsterDb.HitPoints;

            StringBuilder speed = new StringBuilder();
            speed.Append($"{monsterDb.WalkSpeed} ft.");
            if (monsterDb.BurrowSpeed > 0) speed.Append($", burrow {monsterDb.BurrowSpeed} ft.");
            if (monsterDb.ClimbSpeed > 0) speed.Append($", climb {monsterDb.ClimbSpeed} ft.");
            if (monsterDb.FlySpeed > 0) speed.Append($", fly {monsterDb.FlySpeed} ft.");
            if (monsterDb.SwimSpeed > 0) speed.Append($", swim {monsterDb.SwimSpeed} ft.");
            monster.Speed = speed.ToString();


            monster.Strength = monsterDb.Strength;
            monster.Dexterity = monsterDb.Dexterity;
            monster.Constitution = monsterDb.Constitution;
            monster.Intelligence = monsterDb.Intelligence;
            monster.Wisdom = monsterDb.Wisdom;
            monster.Charisma = monsterDb.Charisma;


            monster.StrengthSavingThrow = monsterDb.StrengthSavingThrow;
            monster.Athletics = monsterDb.Athletics;

            monster.DexteritySavingThrow = monsterDb.DexteritySavingThrow;
            monster.Acrobatics = monsterDb.Acrobatics;
            monster.SleightOfHand = monsterDb.SleightOfHand;
            monster.Stealth = monsterDb.Stealth;

            monster.ConstitutionSavingThrow = monsterDb.ConstitutionSavingThrow;

            monster.IntelligenceSavingThrow = monsterDb.IntelligenceSavingThrow;
            monster.Arcana = monsterDb.Arcana;
            monster.History = monsterDb.History;
            monster.Investigation = monsterDb.Investigation;
            monster.Nature = monsterDb.Nature;
            monster.Religion = monsterDb.Religion;

            monster.WisdomSavingThrow = monsterDb.WisdomSavingThrow;
            monster.AnimalHandling = monsterDb.AnimalHandling;
            monster.Insight = monsterDb.Insight;
            monster.Medicine = monsterDb.Medicine;
            monster.Perception = monsterDb.Perception;
            monster.Survival = monsterDb.Survival;

            monster.CharismaSavingThrow = monsterDb.CharismaSavingThrow;
            monster.Deception = monsterDb.Deception;
            monster.Intimidation = monsterDb.Intimidation;
            monster.Performance = monsterDb.Performance;
            monster.Persuasion = monsterDb.Persuasion;


            int i = 0;
            StringBuilder senses = new StringBuilder(); 
            if (monsterDb.Blindsight > 0) senses.Append(string.Format("{1}Blindsight {0} ft.", monsterDb.Blindsight, i++ > 0 ? ", " : ""));
            if (monsterDb.Darkvision > 0) senses.Append(string.Format("{1}Darkvision {0} ft.", monsterDb.Darkvision, i++ > 0 ? ", " : ""));
            if (monsterDb.Tremorsense > 0) senses.Append(string.Format("{1}Tremorsense {0} ft.", monsterDb.Tremorsense, i++ > 0 ? ", " : ""));
            if (monsterDb.Truesight > 0) senses.Append(string.Format("{1}Truesight {0} ft.", monsterDb.Truesight, i > 0 ? ", " : ""));
            monster.Senses = senses.ToString();

            if (monsterDb.Tag != null) monster.Tag = monsterDb.Tag.Name;
            else monster.Tag = "";

            //monster.ProficiencyBonus = monsterDb.ProficiencyBonus;
        }

        //public static void Test()
        //{
        //    MonsterDataModel monsterDb = new MonsterDataModel();
        //    MonsterDataModel monster = new MonsterDataModel();

        //    monster.StrengthSavingThrow = monsterDb.StrengthSavingThrow;
        //    monster.Athletics = monsterDb.Athletics;

        //    monster.DexteritySavingThrow = monsterDb.DexteritySavingThrow;
        //    monster.Acrobatics = monsterDb.Acrobatics;
        //    monster.SleightOfHand = monsterDb.SleightOfHand;
        //    monster.Stealth = monsterDb.Stealth;

        //    monster.ConstitutionSavingThrow = monsterDb.ConstitutionSavingThrow;

        //    monster.IntelligenceSavingThrow = monsterDb.IntelligenceSavingThrow;
        //    monster.Arcana = monsterDb.Arcana;
        //    monster.History = monsterDb.History;
        //    monster.Investigation = monsterDb.Investigation;
        //    monster.Nature = monsterDb.Nature;
        //    monster.Religion = monsterDb.Religion;

        //    monster.WisdomSavingThrow = monsterDb.WisdomSavingThrow;
        //    monster.AnimalHandling = monsterDb.AnimalHandling;
        //    monster.Insight = monsterDb.Insight;
        //    monster.Medicine = monsterDb.Medicine;
        //    monster.Perception = monsterDb.Perception;
        //    monster.Survival = monsterDb.Survival;

        //    monster.CharismaSavingThrow = monsterDb.CharismaSavingThrow;
        //    monster.Deception = monsterDb.Deception;
        //    monster.Intimidation = monsterDb.Intimidation;
        //    monster.Performance = monsterDb.Performance;
        //    monster.Persuasion = monsterDb.Persuasion;





        //        monster.StrengthSavingThrow
        //        monster.Athletics

        //        monster.DexteritySavingThrow
        //        monster.Acrobatics
        //        monster.SleightOfHand
        //        monster.Stealth

        //        monster.ConstitutionSavingThrow

        //        monster.IntelligenceSavingThrow
        //        monster.Arcana
        //        monster.History
        //        monster.Investigation
        //        monster.Nature
        //        monster.Religion

        //        monster.WisdomSavingThrow
        //        monster.AnimalHandling
        //        monster.Insight
        //        monster.Medicine
        //        monster.Perception
        //        monster.Survival

        //        monster.CharismaSavingThrow
        //        monster.Deception
        //        monster.Intimidation
        //        monster.Performance
        //        monster.Persuasion
        //}
    }
}
