using DnDSidekick.Data.InitialData;
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
            context.Beasts.AddRange(BeastsInitialData.DataSeed);
        }
    }
}
