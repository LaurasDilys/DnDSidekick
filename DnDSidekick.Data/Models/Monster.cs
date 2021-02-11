using DnDSidekick.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Models
{
    public class Monster
    {
        public int MonsterId { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public string Type { get; set; }
        public string Alignment { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }

        public int WalkSpeed { get; set; } = 0;
        public int BurrowSpeed { get; set; } = 0;
        public int ClimbSpeed { get; set; } = 0;
        public int FlySpeed { get; set; } = 0;
        public int SwimSpeed { get; set; } = 0;

        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Constitution { get; set; }
        public int Intelligence { get; set; }
        public int Wisdom { get; set; }
        public int Charisma { get; set; }



        //public List<Sense> Senses { get; set; }
        //public List<Trait> Traits { get; set; }
        //public string Actions { get; set; }
        //public string Tags { get; set; }
        public virtual List<Environ> Environs { get; set; }
        //public int ChallengeRating { get; set; }
    }
}
