using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Interfaces
{
    public interface IShared
    {
        int Id { get; set; }
        string Name { get; set; }

        ICollection<MonsterDataModel> Monsters { get; set; }
    }
}
