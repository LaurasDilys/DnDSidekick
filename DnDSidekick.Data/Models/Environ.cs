using DnDSidekick.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Models
{
    public class Environ : IShared
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MonsterDataModel> Monsters { get; set; }
    }
}
