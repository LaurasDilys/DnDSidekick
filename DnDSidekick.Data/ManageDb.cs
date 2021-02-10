using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data
{
    public static class ManageDb
    {
        public static void GenerateInitialData()
        {
            using (var context = new DataContext())
            {
                var first = context.Beasts.First();
            }
        }
    }
}
