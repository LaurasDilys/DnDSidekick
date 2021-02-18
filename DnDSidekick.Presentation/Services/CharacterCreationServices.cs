using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Business.Services;
using DnDSidekick.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Presentation.Services
{
    public static class CharacterCreationServices
    {
        public static bool ChangesWereMade(this ICharacter character)
        {
            int currentId = character.Id;
            ICharacter characterBeforeAssumedChanges;
            if (currentId == 0) characterBeforeAssumedChanges = new Character();
            else characterBeforeAssumedChanges = ManageDb.GetCharacterFromDataBase(currentId);

            if (character.IsIdenticalTo(characterBeforeAssumedChanges)) return false;
            return true;
        }
    }
}
