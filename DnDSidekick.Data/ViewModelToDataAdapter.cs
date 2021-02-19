//using DnDSidekick.Commons.Models;
//using DnDSidekick.Data.Models;
//using DnDSidekick.Commons.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DnDSidekick.Data
//{
//    public static class ViewModelToDataAdapter
//    {
//        public static List<Monster> ToMonsters(this CreatureViewModel[] dataSeed)
//        {
//            List<Monster> monsters = new List<Monster>();
//            foreach (var monster in dataSeed)
//            {
//                string[] sizeTypeAndAlignment = GetSizeTypeAndAlignmentFrom(monster);
//                Dictionary<string, int> skills = GetSkillsFrom(monster);

//                monsters.Add(new Monster
//                {
//                    Name = monster.Name,
//                    Size = sizeTypeAndAlignment[0],
//                    Type = sizeTypeAndAlignment[1],
//                    Alignment = sizeTypeAndAlignment[2],
//                    ArmorClass = monster.ArmorClass,
//                    HitPoints = monster.HitPoints,

//                    WalkSpeed = monster.WalkSpeed,
//                    BurrowSpeed = monster.BurrowSpeed,
//                    ClimbSpeed = monster.ClimbSpeed,
//                    FlySpeed = monster.FlySpeed,
//                    SwimSpeed = monster.SwimSpeed,

//                    Strength = monster.Strength,
//                    Dexterity = monster.Dexterity,
//                    Constitution = monster.Constitution,
//                    Intelligence = monster.Intelligence,
//                    Wisdom = monster.Wisdom,
//                    Charisma = monster.Charisma,



//                });
//            }
//            return monsters;
//        }

//        private static Dictionary<string, int> GetSkillsFrom(CreatureViewModel monster)
//        {
//            Dictionary<string, int> skills = new Dictionary<string, int>();
//            foreach (string skillWithModifier in monster.Skills.Split(','))
//            {
//                string NoSpaces = new string(skillWithModifier.Replace(" ", "").ToArray());
//                string skillName = new String(NoSpaces.Where(Char.IsLetter).ToArray());
//                int skillModifier = Convert.ToInt32(NoSpaces.Substring(NoSpaces.Length));
//                skills.Add(skillName, skillModifier);
//            }
//            return skills;
//        }

//        private static string[] GetSizeTypeAndAlignmentFrom(CreatureViewModel monster)
//        {
//            string[] substrings = monster.SizeTypeAndAlignment.Split(',');
//            if (substrings.Length != 2)
//            {
//                throw new FormatException();
//            }
//            string[] sizeAndType = substrings[0].Split(' ');
//            if (sizeAndType.Length != 2)
//            {
//                throw new FormatException();
//            }
//            string size = sizeAndType[0];
//            string type = sizeAndType[1];
//            string alignment = substrings[1].Substring(1);

//            return new string[] { size, type, alignment };
//        }

//        private static int[] GetSpeedsFrom(CreatureViewModel monster)
//        {
//            string[] substrings = monster.Speed.Split(' ');
//            int walkSpeed = ExtensionMethods.NumberFrom(substrings[0]);

//            string[] otherSpeeds = { "burrow", "climb", "fly", "swim" };

//            return new int[] { walkSpeed };
//        }
//    }
//}
