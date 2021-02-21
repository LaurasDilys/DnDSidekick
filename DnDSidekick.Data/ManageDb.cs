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
                UpdateCharacterSaveHistory(id);
                return id;
            }
        }

        private static void UpdateCharacterSaveHistory(int id)
        {
            using (var context = new DataContext())
            {
                context.CharacterSaveHistory.Add(new CharacterSave { CharacterId = id });
                context.SaveChanges();
            }
        }

        public static int GetIdOfLastSavedCharacter()
        {
            using (var context = new DataContext())
            {
                List<CharacterSave> characterSaveHistory = context.CharacterSaveHistory.ToList();
                if (characterSaveHistory.Count == 0) return 0;
                else return characterSaveHistory.Last().CharacterId;
            }
        }

        public static List<CharacterDataModel> GetAllCharactersReversed()
        {
            using (var context = new DataContext())
            {
                List<CharacterDataModel> newCharacters = context.Characters.ToList();
                newCharacters.Reverse();
                return newCharacters;
            }
        }

        public static MonsterDataModel GetMonsterFromDataBase(int id)
        {
            using (var context = new DataContext())
            {
                MonsterDataModel requestedMonster = context.Monsters
                    .Include(s => s.Size).Include(t => t.Type).Include(a => a.Alignment)
                    .Include(tr => tr.Traits).Include(l => l.Languages).Include(e => e.Environs).Include(tg => tg.Tag)
                    .Where(m => m.MonsterId == id).FirstOrDefault<MonsterDataModel>();
                return requestedMonster;
            }
        }

        public static List<MonsterDataModel> GetAllMonstersExcludingCollections()
        {
            using (var context = new DataContext())
            {
                List<MonsterDataModel> monsters = context.Monsters
                    .Include(s => s.Size).Include(t => t.Type).Include(a => a.Alignment).Include(tg => tg.Tag).ToList();
                return monsters;
            }
        }

        public static List<MonsterDataModel> GetAllMonstersValueTypes()
        {
            using (var context = new DataContext())
            {
                List<MonsterDataModel> monsters = context.Monsters.ToList();
                return monsters;
            }
        }
    }
}
