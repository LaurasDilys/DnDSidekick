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

        public static void IntoViewModel(this IMonsterDataModel monsterDb, IMonsterViewModel monsterVm)
        {
            monsterVm.ChallengeRating = monsterDb.ChallengeRating;

            monsterVm.MonsterId = monsterDb.MonsterId;
            monsterVm.Name = monsterDb.Name;
            monsterVm.SizeTypeAndAlignment = $"{monsterDb.Size.Name} {monsterDb.Type.Name.ToLower()}, {monsterDb.Alignment.Name.ToLower()}";
            monsterVm.ArmorClass = monsterDb.ArmorClass;
            monsterVm.HitPoints = monsterDb.HitPoints;

            StringBuilder speed = new StringBuilder();
            speed.Append($"{monsterDb.WalkSpeed} ft.");
            if (monsterDb.BurrowSpeed > 0) speed.Append($", burrow {monsterDb.BurrowSpeed} ft.");
            if (monsterDb.ClimbSpeed > 0) speed.Append($", climb {monsterDb.ClimbSpeed} ft.");
            if (monsterDb.FlySpeed > 0) speed.Append($", fly {monsterDb.FlySpeed} ft.");
            if (monsterDb.SwimSpeed > 0) speed.Append($", swim {monsterDb.SwimSpeed} ft.");
            monsterVm.Speed = speed.ToString();

            monsterVm.StrengthScore = monsterDb.Strength;
            monsterVm.DexterityScore = monsterDb.Dexterity;
            monsterVm.ConstitutionScore = monsterDb.Constitution;
            monsterVm.IntelligenceScore = monsterDb.Intelligence;
            monsterVm.WisdomScore = monsterDb.Wisdom;
            monsterVm.CharismaScore = monsterDb.Charisma;

            monsterVm.GetSkillValuesFrom(monsterDb);


            StringBuilder senses = new StringBuilder();
            if (monsterDb.Blindsight > 0) senses.Append($"Blindsight {monsterDb.Blindsight} ft., ");
            if (monsterDb.Darkvision > 0) senses.Append($"Darkvision {monsterDb.Darkvision} ft., ");
            if (monsterDb.Tremorsense > 0) senses.Append($"Tremorsense {monsterDb.Tremorsense} ft., ");
            if (monsterDb.Truesight > 0) senses.Append($"Truesight {monsterDb.Truesight} ft., ");
            senses.Append($"Passive Perception {monsterDb.Perception + 10}");
            monsterVm.Senses = senses.ToString();


            StringBuilder traits = new StringBuilder();
            List<Trait> traitsList = monsterDb.Traits.ToList();
            if (traitsList.Count == 0) traits.Append("--");
            else if (traitsList.Count == 1) traits.Append(traitsList.First().Name);
            else for (int t = 0; t < traitsList.Count; t++) traits.Append(string.Format("{0}{1}",
                traitsList[t].Name, t == traitsList.Count - 1 ? "" : ", "));
            monsterVm.Traits = traits.ToString();


            StringBuilder languages = new StringBuilder();
            List<Language> languagesList = monsterDb.Languages.ToList();
            if (languagesList.Count == 0) languages.Append("--");
            else
            {
                if (monsterDb.CanSpeak) for (int i = 0; i < languagesList.Count; i++) languages.Append(string.Format("{0}{1}",
                languagesList[i].Name, i == languagesList.Count - 1 ? "" : ", "));
                else
                {
                    languages.Append($"The {monsterDb.Name} understands ");
                    for (int i = 0; i < languagesList.Count; i++)
                    {
                        languages.Append(languagesList[i].Name);
                             if (i == languagesList.Count - 3) languages.Append(", ");
                        else if (i == languagesList.Count - 2) languages.Append(" and ");
                        else if (i == languagesList.Count - 1) languages.Append(" ");
                    }
                    languages.Append(string.Format("but can't speak {0}", languagesList.Count == 1 ? "it" : "them"));
                }
            }
            monsterVm.Languages = languages.ToString();


            if (monsterDb.Tag != null) monsterVm.Tag = monsterDb.Tag.Name;
            else monsterVm.Tag = "";
        }

        private static void GetSkillValuesFrom(this IMonsterViewModel monster, IMonsterDataModel monsterDb)
        {
            List<int> monsterDbSkillModifiers = monsterDb.GetSkillModifiersValues();

            int i = 0;
            foreach (SkillViewModel skill in monster.StrengthSkills) skill.Modifier = monsterDbSkillModifiers[i++];
            foreach (SkillViewModel skill in monster.DexteritySkills) skill.Modifier = monsterDbSkillModifiers[i++];
            foreach (SkillViewModel skill in monster.ConstitutionSkills) skill.Modifier = monsterDbSkillModifiers[i++];
            foreach (SkillViewModel skill in monster.IntelligenceSkills) skill.Modifier = monsterDbSkillModifiers[i++];
            foreach (SkillViewModel skill in monster.WisdomSkills) skill.Modifier = monsterDbSkillModifiers[i++];
            foreach (SkillViewModel skill in monster.CharismaSkills) skill.Modifier = monsterDbSkillModifiers[i++];
        }

        private static List<int> GetSkillModifiersValues(this IMonsterDataModel monsterDb)
        {
            List<int> monsterSkillModifiers = new List<int>()
            {
                monsterDb.StrengthSavingThrow,
                monsterDb.Athletics,

                monsterDb.DexteritySavingThrow,
                monsterDb.Acrobatics,
                monsterDb.SleightOfHand,
                monsterDb.Stealth,

                monsterDb.ConstitutionSavingThrow,

                monsterDb.IntelligenceSavingThrow,
                monsterDb.Arcana,
                monsterDb.History,
                monsterDb.Investigation,
                monsterDb.Nature,
                monsterDb.Religion,

                monsterDb.WisdomSavingThrow,
                monsterDb.AnimalHandling,
                monsterDb.Insight,
                monsterDb.Medicine,
                monsterDb.Perception,
                monsterDb.Survival,

                monsterDb.CharismaSavingThrow,
                monsterDb.Deception,
                monsterDb.Intimidation,
                monsterDb.Performance,
                monsterDb.Persuasion
            };

            return monsterSkillModifiers;
        }
    }
}
