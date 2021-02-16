using DnDSidekick.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Models
{
    public class Character : Creature
    {
        public Character() : base(0) { }

        public Character(int id) : base(id)
        {
        }

        public string Class { get; set; }
        public string Race { get; set; }
        public string MyProperty { get; set; }
        public string Background { get; set; }
        public int Level { get; set; } = 1;
        public int ExperiencePoints { get; set; }
        public int Inspiration { get; set; }



    }
}
