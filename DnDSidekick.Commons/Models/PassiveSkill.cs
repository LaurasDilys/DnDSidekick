using System;
using System.Collections.Generic;
using System.Text;

namespace DnDSidekick.Commons.Models
{
    public class PassiveSkill
    {
        public int Modifier { get; private set; }
        public int Advantage { get; set; } // (-1 – 1)
    }
}
