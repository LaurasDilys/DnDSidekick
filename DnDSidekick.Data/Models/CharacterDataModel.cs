using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Models
{
    public class CharacterDataModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Class { get; set; }
        public string Race { get; set; }
        public string Background { get; set; }
        public string Alignment { get; set; }

        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
        public int ProficiencyBonus { get; set; }
        public string Inspiration { get; set; }

        public int ArmorClass { get; set; }
        public int CurrentArmorClass { get; set; }

        public int HitPoints { get; set; }
        public int TemporaryHitPoints { get; set; }
        public int CurrentHitPoints { get; set; }

        public int Initiative { get; set; }
        public int CurrentInitiative { get; set; }

        public int Speed { get; set; }
        public int CurrentSpeed { get; set; }

        public int UsedHitDice { get; set; }

        public bool DeathSaveSuccess1 { get; set; }
        public bool DeathSaveSuccess2 { get; set; }
        public bool DeathSaveSuccess3 { get; set; }
        public bool DeathSaveFailure1 { get; set; }
        public bool DeathSaveFailure2 { get; set; }
        public bool DeathSaveFailure3 { get; set; }


        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }



    }
}
