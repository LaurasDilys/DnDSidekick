using System;
using System.Collections.Generic;
using System.Text;

namespace DnDSidekick.Commons.Models
{
    public class Ability
    {
        public int Score { get; set; }
        public int Modifier { get; private set; }
        public SavingThrow SavingThrow { get; set; }
        public List<Skill> Skills { get; set; }
        public int Advantage { get; set; } // (-1 – 1)
        public int Custom { get; set; } // can be any value set by the user
    }
}
