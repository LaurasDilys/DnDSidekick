using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.InitialData
{
    public static class LanguagesInitialData
    {
        public static readonly Language[] DataSeed =
        {
            new Language { Id = 1, Name = "Abyssal" },
            new Language { Id = 2, Name = "Aquan" },
            new Language { Id = 3, Name = "Auran" },
            new Language { Id = 4, Name = "Celestial" },
            new Language { Id = 5, Name = "Common" },
            new Language { Id = 6, Name = "Deep Speech" },
            new Language { Id = 7, Name = "Draconic" },
            new Language { Id = 8, Name = "Druidic" },
            new Language { Id = 9, Name = "Dwarvish" },
            new Language { Id = 10, Name = "Elvish" },
            new Language { Id = 11, Name = "Giant" },
            new Language { Id = 12, Name = "Gnomish" },
            new Language { Id = 13, Name = "Goblin" },
            new Language { Id = 14, Name = "Gnoll" },
            new Language { Id = 15, Name = "Halfling" },
            new Language { Id = 16, Name = "Ignan" },
            new Language { Id = 17, Name = "Infernal" },
            new Language { Id = 18, Name = "Orc" },
            new Language { Id = 19, Name = "Primordial" },
            new Language { Id = 20, Name = "Sylvan" },
            new Language { Id = 21, Name = "Terran" },
            new Language { Id = 22, Name = "Undercommon" }
        };
    }
}
