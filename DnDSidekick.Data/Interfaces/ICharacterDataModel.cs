using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Interfaces
{
    public interface ICharacterDataModel
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


        int Strength { get; set; }
        int Dexterity { get; set; }
        int Constitution { get; set; }
        int Intelligence { get; set; }
        int Wisdom { get; set; }
        int Charisma { get; set; }


        bool StrengthSavingThrowProficiency { get; set; }
        bool AthleticsProficiency { get; set; }

        bool DexteritySavingThrowProficiency { get; set; }
        bool AcrobaticsProficiency { get; set; }
        bool SleightOfHandProficiency { get; set; }
        bool StealthProficiency { get; set; }

        bool ConstitutionSavingThrowProficiency { get; set; }

        bool IntelligenceSavingThrowProficiency { get; set; }
        bool ArcanaProficiency { get; set; }
        bool HistoryProficiency { get; set; }
        bool InvestigationProficiency { get; set; }
        bool NatureProficiency { get; set; }
        bool ReligionProficiency { get; set; }

        bool WisdomSavingThrowProficiency { get; set; }
        bool AnimalHandlingProficiency { get; set; }
        bool InsightProficiency { get; set; }
        bool MedicineProficiency { get; set; }
        bool PerceptionProficiency { get; set; }
        bool SurvivalProficiency { get; set; }

        bool CharismaSavingThrowProficiency { get; set; }
        bool DeceptionProficiency { get; set; }
        bool IntimidationProficiency { get; set; }
        bool PerformanceProficiency { get; set; }
        bool PersuasionProficiency { get; set; }
    }
}
