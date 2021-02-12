using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Models
{
    public class Environ
    {
        public int EnvironId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<MonsterDataModel> Monsters { get; set; }
    }
}
