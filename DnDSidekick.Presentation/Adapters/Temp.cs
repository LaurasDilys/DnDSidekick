//using DnDSidekick.Business.Interfaces;
//using DnDSidekick.Business.Models;
//using DnDSidekick.Data;
//using DnDSidekick.Data.Interfaces;
//using DnDSidekick.Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DnDSidekick.Presentation.Adapters
//{
//    public static class Temp
//    {
//        public static int FuncTest()
//        {

//            ICharacter character = new Character();
//            ICharacterDataModel characterDb = new CharacterDataModel();

//            List<bool> characterDbProficiencies = new List<bool>()
//            {
//                characterDb.StrengthSavingThrowProficiency,
//                characterDb.AthleticsProficiency,

//                characterDb.DexteritySavingThrowProficiency,
//                characterDb.AcrobaticsProficiency,
//                characterDb.SleightOfHandProficiency,
//                characterDb.StealthProficiency,

//                characterDb.ConstitutionSavingThrowProficiency,

//                characterDb.IntelligenceSavingThrowProficiency,
//                characterDb.ArcanaProficiency,
//                characterDb.HistoryProficiency,
//                characterDb.InvestigationProficiency,
//                characterDb.NatureProficiency,
//                characterDb.ReligionProficiency,

//                characterDb.WisdomSavingThrowProficiency,
//                characterDb.AnimalHandlingProficiency,
//                characterDb.InsightProficiency,
//                characterDb.MedicineProficiency,
//                characterDb.PerceptionProficiency,
//                characterDb.SurvivalProficiency,

//                characterDb.CharismaSavingThrowProficiency,
//                characterDb.DeceptionProficiency,
//                characterDb.IntimidationProficiency,
//                characterDb.PerformanceProficiency,
//                characterDb.PersuasionProficiency,
//            };



//            List<bool> characterProficiencies = new List<bool>();
//            int i = 0;

//            characterDb.StrengthSavingThrowProficiency = characterProficiencies[i++];
//            characterDb.AthleticsProficiency = characterProficiencies[i++];

//            characterDb.DexteritySavingThrowProficiency = characterProficiencies[i++];
//            characterDb.AcrobaticsProficiency = characterProficiencies[i++];
//            characterDb.SleightOfHandProficiency = characterProficiencies[i++];
//            characterDb.StealthProficiency = characterProficiencies[i++];

//            characterDb.ConstitutionSavingThrowProficiency = characterProficiencies[i++];

//            characterDb.IntelligenceSavingThrowProficiency = characterProficiencies[i++];
//            characterDb.ArcanaProficiency = characterProficiencies[i++];
//            characterDb.HistoryProficiency = characterProficiencies[i++];
//            characterDb.InvestigationProficiency = characterProficiencies[i++];
//            characterDb.NatureProficiency = characterProficiencies[i++];
//            characterDb.ReligionProficiency = characterProficiencies[i++];

//            characterDb.WisdomSavingThrowProficiency = characterProficiencies[i++];
//            characterDb.AnimalHandlingProficiency = characterProficiencies[i++];
//            characterDb.InsightProficiency = characterProficiencies[i++];
//            characterDb.MedicineProficiency = characterProficiencies[i++];
//            characterDb.PerceptionProficiency = characterProficiencies[i++];
//            characterDb.SurvivalProficiency = characterProficiencies[i++];

//            characterDb.CharismaSavingThrowProficiency = characterProficiencies[i++];
//            characterDb.DeceptionProficiency = characterProficiencies[i++];
//            characterDb.IntimidationProficiency = characterProficiencies[i++];
//            characterDb.PerformanceProficiency = characterProficiencies[i++];
//            characterDb.PersuasionProficiency = characterProficiencies[i++];

//            return 0;








//            ICharacter characterA = new Character();
//            ICharacterDataModel characterB = new CharacterDataModel();

//            characterA.Id = characterB.Id;
//            characterA.Name = characterB.Name;
//            characterA.Class = characterB.Class;
//            characterA.Race = characterB.Race;
//            characterA.Background = characterB.Background;
//            characterA.Alignment = characterB.Alignment;


//            characterA.Level = characterB.Level;
//            characterA.ExperiencePoints = characterB.ExperiencePoints;
//            characterA.ProficiencyBonus = characterB.ProficiencyBonus;
//            characterA.Inspiration = characterB.Inspiration;


//            characterA.ArmorClass = characterB.ArmorClass;
//            characterA.CurrentArmorClass = characterB.CurrentArmorClass;


//            characterA.HitPoints = characterB.HitPoints;
//            characterA.TemporaryHitPoints = characterB.TemporaryHitPoints;
//            characterA.CurrentHitPoints = characterB.CurrentHitPoints;


//            characterA.Initiative = characterB.Initiative;
//            characterA.CurrentInitiative = characterB.CurrentInitiative;


//            characterA.Speed = characterB.Speed;
//            characterA.CurrentSpeed = characterB.CurrentSpeed;


//            characterA.UsedHitDice = characterB.UsedHitDice;


//            characterA.DeathSaveSuccess1 = characterB.DeathSaveSuccess1;
//            characterA.DeathSaveSuccess2 = characterB.DeathSaveSuccess2;
//            characterA.DeathSaveSuccess3 = characterB.DeathSaveSuccess3;
//            characterA.DeathSaveFailure1 = characterB.DeathSaveFailure1;
//            characterA.DeathSaveFailure2 = characterB.DeathSaveFailure2;
//            characterA.DeathSaveFailure3 = characterB.DeathSaveFailure3;

//        }
//    }
//}
