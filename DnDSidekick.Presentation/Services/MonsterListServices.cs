using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Data;
using DnDSidekick.Data.Adapters;
using DnDSidekick.Data.Interfaces;
using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Presentation.Services
{
    public static class MonsterListServices
    {
        public static List<MonsterListModel> GetAllMonstersForList()
        {
            List<MonsterDataModel> monstersDb = ManageDb.GetAllMonstersExcludingCollections();
            List<MonsterListModel> monstersList = new List<MonsterListModel>();
            foreach (MonsterDataModel monsterDb in monstersDb)
            {
                monstersList.Add(new MonsterListModel());
                monsterDb.TransformIntoListModel(monstersList.Last());
            }
            return monstersList;
        }
    }
}
