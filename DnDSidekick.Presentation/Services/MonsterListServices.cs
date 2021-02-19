//using DnDSidekick.Business.Interfaces;
//using DnDSidekick.Business.Models;
//using DnDSidekick.Data;
//using DnDSidekick.Data.Adapters;
//using DnDSidekick.Data.Interfaces;
//using DnDSidekick.Data.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DnDSidekick.Presentation.Services
//{
//    public static class MonsterListServices
//    {
//        public static List<MonsterViewModel> GetAllMonstersForList()
//        {
//            List<MonsterDataModel> monstersDb = ManageDb.GetAllMonstersExcludingCollections();
//            List<MonsterViewModel> monstersList = new List<MonsterViewModel>();
//            foreach (MonsterDataModel monsterDb in monstersDb)
//            {
//                monstersList.Add(new MonsterViewModel());
//                monsterDb.TransformIntoListModel(monstersList.Last());
//            }
//            return monstersList;
//        }
//    }
//}
