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
            context.Monsters.AddRange(MonstersInitialData.DataSeed);

            //
            context.Environs.AddRange(EnvironsInitialData.DataSeed);
            context.SaveChanges();

            //
            AddMonsterEnvirons();
        }

        private void AddMonsterEnvirons()
        {
            using (var context = new DataContext())
            {
                var monsters = context.Monsters;
                var environs = context.Environs;
                foreach (string[] substrings in SplitStrings(MonsterEnvironsInitialData.DataSeed))
                {
                    int monsterId = Convert.ToInt32(substrings[0]);
                    for (int i = 1; i < substrings.Length; i++)
                    {
                        string environ = substrings[i];
                        monsters.Find(monsterId).Environs.Add(environs.Single(e => e.Name == environ));
                    }
                }
                context.SaveChanges();
            }
        }

        private static List<string[]> SplitStrings(string[] initialDataAsStrings)
        {
            List<string[]> splitStrings = new List<string[]>();
            foreach (string line in initialDataAsStrings)
            {
                string[] substrings = line.Split(',');
                splitStrings.Add(substrings);
            }
            return splitStrings;
        }

        //private void AddEnvironsAndMonsterEnvirons(string[] initialDataAsStrings)
        //{
        //    List<string[]> splitStrings = new List<string[]>();
        //    List<string> onlyEnvirons = new List<string>();
        //    foreach (string line in initialDataAsStrings)
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
        //        environsInitialData.Add(new Environ() { Name = environ });
        //    }
        //    using (var context = new DataContext())
        //    {
        //        context.Environs.AddRange(environsInitialData);
        //        context.SaveChanges();
        //    }

        //    //Actual MonsterEnvironsInitialData
        //    using (var context = new DataContext())
        //    {
        //        var beasts = context.Monsters;
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
