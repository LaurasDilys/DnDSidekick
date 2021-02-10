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
            //new Beast { Name = "Baboon", Environs = new List<Environ> {
            //    new Environ { Name = "Forest" },
            //    new Environ { Name = "Hill" },} },

            //new Beast { Name = "Badger", Environs = new List<Environ> {
            //    new Environ { Name = "Forest" },} },

            //new Beast { Name = "Bat" },

            //new Beast { Name = "Cat", Environs = new List<Environ> {
            //    new Environ { Name = "Desert" },
            //    new Environ { Name = "Forest" },
            //    new Environ { Name = "Grassland" },
            //    new Environ { Name = "Urban" },} },

            new Beast { BeastId = 1, Name = "Baboon", Environs = new List<Environ> {
                new Environ { Name = "Forest" },
                new Environ { Name = "Hill" },} },

            new Beast { BeastId = 2, Name = "Badger", Environs = new List<Environ> {
                new Environ { Name = "Forest" },} },

            new Beast { BeastId = 3, Name = "Bat" },

            new Beast { BeastId = 4, Name = "Cat", Environs = new List<Environ> {
                new Environ { Name = "Desert" },
                new Environ { Name = "Forest" },
                new Environ { Name = "Grassland" },
                new Environ { Name = "Urban" },} },
        };
    }
}
