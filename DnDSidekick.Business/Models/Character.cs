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
        public Character(int id, string name) : base(id, name)
        {
        }
    }
}
