using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.InitialData
{
    public static class EnvironsInitialData
    {
        public static readonly Environ[] DataSeed =
        {
            new Environ { Id = 1, Name = "Arctic" },
            new Environ { Id = 2, Name = "Coastal" },
            new Environ { Id = 3, Name = "Desert" },
            new Environ { Id = 4, Name = "Forest" },
            new Environ { Id = 5, Name = "Grassland" },
            new Environ { Id = 6, Name = "Hill" },
            new Environ { Id = 7, Name = "Mountain" },
            new Environ { Id = 8, Name = "Swamp" },
            new Environ { Id = 9, Name = "Underdark" },
            new Environ { Id = 10, Name = "Underwater" },
            new Environ { Id = 11, Name = "Urban" },
        };
    }
}
