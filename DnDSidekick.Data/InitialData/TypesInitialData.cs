using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.InitialData
{
    public static class TypesInitialData
    {
        public static readonly CreatureType[] DataSeed =
        {
            new CreatureType { Id = 1, Name = "Aberration" },
            new CreatureType { Id = 2, Name = "Beast" },
            new CreatureType { Id = 3, Name = "Celestial" },
            new CreatureType { Id = 4, Name = "Construct" },
            new CreatureType { Id = 5, Name = "Dragon" },
            new CreatureType { Id = 6, Name = "Elemental" },
            new CreatureType { Id = 7, Name = "Fey" },
            new CreatureType { Id = 8, Name = "Fiend" },
            new CreatureType { Id = 9, Name = "Giant" },
            new CreatureType { Id = 10, Name = "Humanoid" },
            new CreatureType { Id = 11, Name = "Monstrosity" },
            new CreatureType { Id = 12, Name = "Ooze" },
            new CreatureType { Id = 13, Name = "Plant" },
            new CreatureType { Id = 14, Name = "Undead" }
        };
    }
}
