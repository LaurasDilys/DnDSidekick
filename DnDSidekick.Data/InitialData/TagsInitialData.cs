using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.InitialData
{
    public static class TagsInitialData
    {
        public static readonly Tag[] DataSeed =
        {
            new Tag { Id = 1, Name = "Misc Creature" },
            new Tag { Id = 2, Name = "Dinosaur" },
            new Tag { Id = 3, Name = "Elemental" }
        };
    }
}
