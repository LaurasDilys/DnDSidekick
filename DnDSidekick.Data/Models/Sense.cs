using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Models
{
    public class Sense
    {
        public int SenseId { get; set; }
        public string Type { get; set; }
        public int Distance { get; set; }

        public List<Beast> Beasts { get; set; }
    }
}
