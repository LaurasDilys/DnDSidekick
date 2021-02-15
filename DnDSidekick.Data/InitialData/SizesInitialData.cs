using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.InitialData
{
    public static class SizesInitialData
    {
        public static readonly Size[] DataSeed =
        {
            new Size { Id = 1, Name = "Tiny" },
            new Size { Id = 2, Name = "Small" },
            new Size { Id = 3, Name = "Medium" },
            new Size { Id = 4, Name = "Large" },
            new Size { Id = 5, Name = "Huge" },
            new Size { Id = 6, Name = "Gargantuan" }
        };
    }
}
