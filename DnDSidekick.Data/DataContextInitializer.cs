using DnDSidekick.Commons.Models;
using DnDSidekick.Data.InitialData;
using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data
{
    public class DataContextInitializer : DropCreateDatabaseAlways<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Monsters.AddRange(MonstersInitialData.DataSeed.ToMonsters());
            context.SaveChanges();
        }

        //private void AddEnvironsAndBeastEnvirons(string[] environsAsStrings)
        //{
        //    List<string[]> splitStrings = new List<string[]>();
        //    List<string> onlyEnvirons = new List<string>();
        //    foreach (string line in environsAsStrings)
        //    {
        //        string[] substrings = line.Split(',');
        //        splitStrings.Add(substrings);
        //        foreach (string sub in substrings)
        //        {
        //            if (!Int32.TryParse(sub, out _)) onlyEnvirons.Add(sub);
        //        }
        //    }

        //    //Actual EnvironsInitialData
        //    List<Environ> environsInitialData = new List<Environ>();
        //    foreach (string environ in onlyEnvirons.Distinct())
        //    {
        //        environsInitialData.Add(new Environ() { Name = environ } );
        //    }
        //    using (var context = new DataContext())
        //    {
        //        context.Environs.AddRange(environsInitialData);
        //        context.SaveChanges();
        //    }

        //    //Actual BeastEnvironsInitialData
        //    using (var context = new DataContext())
        //    {
        //        var beasts = context.Beasts;
        //        var environs = context.Environs;
        //        foreach (string[] substrings in splitStrings)
        //        {
        //            int beastId = Convert.ToInt32(substrings[0]);
        //            for (int i = 1; i < substrings.Length; i++)
        //            {
        //                string environ = substrings[i];
        //                beasts.Find(beastId).Environs.Add(environs.Single(e => e.Name == environ));
        //            }
        //        }
        //        context.SaveChanges();
        //    }
        //}
    }
}
