using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.InitialData
{
    public static class AlignmentsInitialData
    {
        public static readonly Alignment[] DataSeed =
        {
            new Alignment { Id = 1, Name = "Lawful good" },
            new Alignment { Id = 2, Name = "Neutral good" },
            new Alignment { Id = 3, Name = "Chaotic good" },
            new Alignment { Id = 4, Name = "Lawful neutral" },
            new Alignment { Id = 5, Name = "Neutral" },
            new Alignment { Id = 6, Name = "Chaotic neutral" },
            new Alignment { Id = 7, Name = "Lawful evil" },
            new Alignment { Id = 8, Name = "Neutral evil" },
            new Alignment { Id = 9, Name = "Chaotic evil" },
            new Alignment { Id = 10, Name = "Unaligned" }
        };
    }
}
