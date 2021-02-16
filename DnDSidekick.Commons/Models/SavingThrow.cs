using System;
using System.Collections.Generic;
using System.Text;

namespace DnDSidekick.Commons.Models
{
    public class SavingThrow
    {
        public int Modifier { get; private set; }
        public bool Proficiency { get; set; }
        //public bool Prof
        //{
        //    get { if (Proficiency < 1) return false; return true; }
        //    set { if (value) Proficiency = 1; else Proficiency = 0; }
        //}
        //public int Proficiency { get; set; } // (0 – 2)
        //public int Advantage { get; set; }  // (-1 – 1)
        //public int Custom { get; set; } // can be any value set by the user
    }
}
