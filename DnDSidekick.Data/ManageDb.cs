using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Data.Adapters;
using DnDSidekick.Data.Interfaces;
using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                var first = context.Monsters.First();
            }
        }

        public static Character GetCharacterFromDataBase(int id)
        {
            using (var context = new DataContext())
            {
                Character character = new Character();
                ICharacterDataModel characterDb = context.Characters.Find(id);

                characterDb.TransformIntoFullCharacter(character);

                return character;
            }
        }

        public static int ToDataBase(this ICharacter character)
        {
            using (var context = new DataContext())
            {
                ICharacterDataModel characterDb;
                int id = character.Id;
                if (id == 0) characterDb = new CharacterDataModel();
                else characterDb = context.Characters.Find(id);

                character.TransformIntoDataModel(characterDb);

                if (id == 0)
                {
                    id = context.Characters.Count() + 1;
                    context.Characters.Add((CharacterDataModel)characterDb);
                }

                context.SaveChanges();
                return id;
            }
        }

        public static List<CharacterDataModel> GetAllCharactersReversed() //this List<CharacterDataModel> characters
        {
            using (var context = new DataContext())
            {
                List<CharacterDataModel> newCharacters = context.Characters.ToList();
                newCharacters.Reverse();
                return newCharacters;
            }
        }
    }
}
