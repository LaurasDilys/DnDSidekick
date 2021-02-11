using DnDSidekick.Commons.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Models
{
    public class Beast //: Monster
    {
        public int BeastId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Environ> Environs { get; set; }
    }
}
