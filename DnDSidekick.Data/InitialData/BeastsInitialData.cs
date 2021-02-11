using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.InitialData
{
    public static class BeastsInitialData
    {
        public static readonly Beast[] DataSeed =
        {
            new Beast { BeastId = 1, Name = "Baboon" },
            //
            new Beast { BeastId = 2, Name = "Badger" },
            //
            new Beast { BeastId = 3, Name = "Bat" },
            //
            new Beast { BeastId = 4, Name = "Cat" }
        };
    }
}
