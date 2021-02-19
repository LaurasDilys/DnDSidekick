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
    public class DataContextInitializer : CreateDatabaseIfNotExists<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            context.Monsters.AddRange(MonstersInitialData.DataSeed);

            context.Sizes.AddRange(SizesInitialData.DataSeed);
            context.Types.AddRange(TypesInitialData.DataSeed);
            context.Alignments.AddRange(AlignmentsInitialData.DataSeed);
            context.Traits.AddRange(TraitsInitialData.DataSeed);
            context.Languages.AddRange(LanguagesInitialData.DataSeed);
            context.Environs.AddRange(EnvironsInitialData.DataSeed);
            context.Tags.AddRange(TagsInitialData.DataSeed);
            context.SaveChanges();

            AddMonsterSizes();
            AddMonsterTypes();
            AddMonsterAlignments();
            AddMonsterTraits();
            AddMonsterLanguages();
            AddMonsterEnvirons();
            AddMonsterTags();
        }

        private void AddMonsterSizes()
        {
            using (var context = new DataContext())
            {
                var monsters = context.Monsters;
                var sizes = context.Sizes;
                foreach (string[] substrings in SplitStrings(MonsterSizesInitialData.DataSeed))
                {
                    int monsterId = Convert.ToInt32(substrings[0]);
                    string size = substrings[1];
                    monsters.Find(monsterId).Size = sizes.Single(x => x.Name == size);
                }
                context.SaveChanges();
            }
        }

        private void AddMonsterTypes()
        {
            using (var context = new DataContext())
            {
                var monsters = context.Monsters;
                var types = context.Types;
                foreach (string[] substrings in SplitStrings(MonsterTypesInitialData.DataSeed))
                {
                    int monsterId = Convert.ToInt32(substrings[0]);
                    string type = substrings[1];
                    monsters.Find(monsterId).Type = types.Single(x => x.Name == type);
                }
                context.SaveChanges();
            }
        }

        private void AddMonsterAlignments()
        {
            using (var context = new DataContext())
            {
                var monsters = context.Monsters;
                var alignments = context.Alignments;
                foreach (string[] substrings in SplitStrings(MonsterAlignmentsInitialData.DataSeed))
                {
                    int monsterId = Convert.ToInt32(substrings[0]);
                    string alignment = substrings[1];
                    monsters.Find(monsterId).Alignment = alignments.Single(x => x.Name == alignment);
                }
                context.SaveChanges();
            }
        }

        private void AddMonsterTraits()
        {
            using (var context = new DataContext())
            {
                var monsters = context.Monsters;
                var traits = context.Traits;
                foreach (string[] substrings in SplitStrings(MonsterTraitsInitialData.DataSeed))
                {
                    int monsterId = Convert.ToInt32(substrings[0]);
                    for (int i = 1; i < substrings.Length; i++)
                    {
                        string trait = substrings[i];
                        monsters.Find(monsterId).Traits.Add(traits.Single(x => x.Name == trait));
                    }
                }
                context.SaveChanges();
            }
        }

        private void AddMonsterLanguages()
        {
            using (var context = new DataContext())
            {
                var monsters = context.Monsters;
                var languages = context.Languages;
                foreach (string[] substrings in SplitStrings(MonsterLanguagesInitialData.DataSeed))
                {
                    int monsterId = Convert.ToInt32(substrings[0]);
                    for (int i = 1; i < substrings.Length; i++)
                    {
                        string language = substrings[i];
                        monsters.Find(monsterId).Languages.Add(languages.Single(x => x.Name == language));
                    }
                }
                context.SaveChanges();
            }
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
                        monsters.Find(monsterId).Environs.Add(environs.Single(x => x.Name == environ));
                    }
                }
                context.SaveChanges();
            }
        }

        private void AddMonsterTags()
        {
            using (var context = new DataContext())
            {
                var monsters = context.Monsters;
                var tags = context.Tags;
                foreach (string[] substrings in SplitStrings(MonsterTagsInitialData.DataSeed))
                {
                    int monsterId = Convert.ToInt32(substrings[0]);
                    string tag = substrings[1];
                    monsters.Find(monsterId).Tag = tags.Single(x => x.Name == tag);
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
