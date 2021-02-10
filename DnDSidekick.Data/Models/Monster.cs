using DnDSidekick.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Models
{
    public class Monster : Creature
    {
        public int WalkSpeed { get; set; }
        public int BurrowSpeed { get; set; }
        public int ClimbSpeed { get; set; }
        public int FlySpeed { get; set; }
        public int SwimSpeed { get; set; }

        public List<Sense> Senses { get; set; }
        public List<Trait> Traits { get; set; }
        public string Actions { get; set; }
        public string Tags { get; set; }
        public List<string> Environments { get; set; }


        //Monster type is the child class - one that inherits the Monster class
        public string Size { get; set; }
        public string Alignment { get; set; }
        public int ChallengeRating { get; set; }
    }
}
