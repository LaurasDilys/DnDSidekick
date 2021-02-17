using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Services
{
    public static class CharacterServices
    {
        public static bool IsIdenticalTo(this ICharacter characterA, ICharacter characterB)
        {
            Type objectType;
            objectType = characterA.GetType();

            foreach (PropertyInfo propertyInfo in objectType.GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .Where(p => p.CanRead && (p.PropertyType == typeof(int) || p.PropertyType == typeof(string) || p.PropertyType == typeof(bool))))
            {
                var valueA = propertyInfo.GetValue(characterA);
                var valueB = propertyInfo.GetValue(characterB);
                if (!object.Equals(valueA, valueB)) return false;
            }

            List<int> characterAabilityScores = characterA.GetAbilityScoresForComparison();
            List<int> characterBabilityScores = characterB.GetAbilityScoresForComparison();
            for (int i = 0; i < characterAabilityScores.Count; i++)
            {
                int valueA = characterAabilityScores[i];
                int valueB = characterBabilityScores[i];
                if (!object.Equals(valueA, valueB)) return false;
            }

            List<bool> characterAproficiencies = characterA.GetProficienciesForComparison();
            List<bool> characterBproficiencies = characterB.GetProficienciesForComparison();
            for (int i = 0; i < characterAproficiencies.Count; i++)
            {
                bool valueA = characterAproficiencies[i];
                bool valueB = characterBproficiencies[i];
                if (!object.Equals(valueA, valueB)) return false;
            }

            return true;
        }

        public static List<int> GetAbilityScoresForComparison(this ICharacter character)
        {
            List<int> abilityScores = new List<int>();

            foreach (Ability ability in character.Abilities) abilityScores.Add(ability.Score);

            return abilityScores;
        }

        public static List<bool> GetProficienciesForComparison(this ICharacter character)
        {
            List<bool> proficiencies = new List<bool>();

            foreach (Ability ability in character.Abilities)
            {
                proficiencies.Add(ability.SavingThrow.Proficiency);
                foreach (Skill skill in ability.Skills) proficiencies.Add(skill.Proficiency);
            }

            return proficiencies;
        }
    }
}
