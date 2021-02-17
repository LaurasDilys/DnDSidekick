using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Adapters
{
    public static class CharacterAdapters
    {
        public static void TransformIntoDataModel(this ICharacter character, ICharacterDataModel characterDb)
        {
            List<bool> characterProficiencies = new List<bool>();
            foreach (Ability ability in character.Abilities)
            {
                characterProficiencies.Add(ability.SavingThrow.Proficiency);
                foreach (Skill skill in ability.Skills)
                {
                    characterProficiencies.Add(skill.Proficiency);
                }
            }

            int i = 0;

            characterDb.StrengthSavingThrowProficiency = characterProficiencies[i++];
            characterDb.AthleticsProficiency = characterProficiencies[i++];

            characterDb.DexteritySavingThrowProficiency = characterProficiencies[i++];
            characterDb.AcrobaticsProficiency = characterProficiencies[i++];
            characterDb.SleightOfHandProficiency = characterProficiencies[i++];
            characterDb.StealthProficiency = characterProficiencies[i++];

            characterDb.ConstitutionSavingThrowProficiency = characterProficiencies[i++];

            characterDb.IntelligenceSavingThrowProficiency = characterProficiencies[i++];
            characterDb.ArcanaProficiency = characterProficiencies[i++];
            characterDb.HistoryProficiency = characterProficiencies[i++];
            characterDb.InvestigationProficiency = characterProficiencies[i++];
            characterDb.NatureProficiency = characterProficiencies[i++];
            characterDb.ReligionProficiency = characterProficiencies[i++];

            characterDb.WisdomSavingThrowProficiency = characterProficiencies[i++];
            characterDb.AnimalHandlingProficiency = characterProficiencies[i++];
            characterDb.InsightProficiency = characterProficiencies[i++];
            characterDb.MedicineProficiency = characterProficiencies[i++];
            characterDb.PerceptionProficiency = characterProficiencies[i++];
            characterDb.SurvivalProficiency = characterProficiencies[i++];

            characterDb.CharismaSavingThrowProficiency = characterProficiencies[i++];
            characterDb.DeceptionProficiency = characterProficiencies[i++];
            characterDb.IntimidationProficiency = characterProficiencies[i++];
            characterDb.PerformanceProficiency = characterProficiencies[i++];
            characterDb.PersuasionProficiency = characterProficiencies[i++];
        }

        public static void TransformIntoFullCharacter(this ICharacterDataModel characterDb, ICharacter character)
        {
            List<bool> characterDbProficiencies = new List<bool>()
            {
                characterDb.StrengthSavingThrowProficiency,
                characterDb.AthleticsProficiency,

                characterDb.DexteritySavingThrowProficiency,
                characterDb.AcrobaticsProficiency,
                characterDb.SleightOfHandProficiency,
                characterDb.StealthProficiency,

                characterDb.ConstitutionSavingThrowProficiency,

                characterDb.IntelligenceSavingThrowProficiency,
                characterDb.ArcanaProficiency,
                characterDb.HistoryProficiency,
                characterDb.InvestigationProficiency,
                characterDb.NatureProficiency,
                characterDb.ReligionProficiency,

                characterDb.WisdomSavingThrowProficiency,
                characterDb.AnimalHandlingProficiency,
                characterDb.InsightProficiency,
                characterDb.MedicineProficiency,
                characterDb.PerceptionProficiency,
                characterDb.SurvivalProficiency,

                characterDb.CharismaSavingThrowProficiency,
                characterDb.DeceptionProficiency,
                characterDb.IntimidationProficiency,
                characterDb.PerformanceProficiency,
                characterDb.PersuasionProficiency,
            };

            int i = 0;

            foreach (Ability ability in character.Abilities)
            {
                ability.SavingThrow.Proficiency = characterDbProficiencies[i++];
                foreach (Skill skill in ability.Skills)
                {
                    skill.Proficiency = characterDbProficiencies[i++];
                }
            }
        }
    }
}
