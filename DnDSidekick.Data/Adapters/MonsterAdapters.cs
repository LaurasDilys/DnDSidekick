using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Data.Interfaces;
using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Data.Adapters
{
    public static class MonsterAdapters
    {
        public static void TransformIntoListModel(this IMonsterDataModel monsterDb, IMonsterListModel monster)
        {
            monster.ChallengeRating = monsterDb.ChallengeRating;

            monster.MonsterId = monsterDb.MonsterId;
            monster.Name = monsterDb.Name;
            monster.SizeTypeAndAlignment = $"{monsterDb.Size.Name} {monsterDb.Type.Name.ToLower()}, {monsterDb.Alignment.Name.ToLower()}";
            monster.ArmorClass = monsterDb.ArmorClass;
            monster.HitPoints = monsterDb.HitPoints;

            StringBuilder speed = new StringBuilder();
            speed.Append($"{monsterDb.WalkSpeed} ft.");
            if (monsterDb.BurrowSpeed > 0) speed.Append($", burrow {monsterDb.BurrowSpeed} ft.");
            if (monsterDb.ClimbSpeed > 0) speed.Append($", climb {monsterDb.ClimbSpeed} ft.");
            if (monsterDb.FlySpeed > 0) speed.Append($", fly {monsterDb.FlySpeed} ft.");
            if (monsterDb.SwimSpeed > 0) speed.Append($", swim {monsterDb.SwimSpeed} ft.");
            monster.Speed = speed.ToString();

            monster.Strength = monsterDb.Strength;
            monster.Dexterity = monsterDb.Dexterity;
            monster.Constitution = monsterDb.Constitution;
            monster.Intelligence = monsterDb.Intelligence;
            monster.Wisdom = monsterDb.Wisdom;
            monster.Charisma = monsterDb.Charisma;

            int i = 0;
            StringBuilder senses = new StringBuilder(); 
            if (monsterDb.Blindsight > 0) senses.Append(string.Format("{1}Blindsight {0} ft.", monsterDb.Blindsight, i++ > 0 ? ", " : ""));
            if (monsterDb.Darkvision > 0) senses.Append(string.Format("{1}Darkvision {0} ft.", monsterDb.Darkvision, i++ > 0 ? ", " : ""));
            if (monsterDb.Tremorsense > 0) senses.Append(string.Format("{1}Tremorsense {0} ft.", monsterDb.Tremorsense, i++ > 0 ? ", " : ""));
            if (monsterDb.Truesight > 0) senses.Append(string.Format("{1}Truesight {0} ft.", monsterDb.Truesight, i > 0 ? ", " : ""));
            monster.Senses = senses.ToString();

            if (monsterDb.Tag != null) monster.Tag = monsterDb.Tag.Name;
            else monster.Tag = "";

            //monster.ProficiencyBonus = monsterDb.ProficiencyBonus;
        }
    }
}
