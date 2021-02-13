using DnDSidekick.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Models
{
    public class DamageType : IShared
    {
        public int Id { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ICollection<MonsterDataModel> Monsters { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
