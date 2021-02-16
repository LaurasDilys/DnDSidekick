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

        public int Inspiration { get; set; }
    }
}
