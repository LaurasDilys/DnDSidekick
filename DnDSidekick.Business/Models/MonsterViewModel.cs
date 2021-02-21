using DnDSidekick.Business.Interfaces;
using DnDSidekick.Commons.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DnDSidekick.Business.Models
{
    public class MonsterViewModel : IMonsterViewModel
    {
        public MonsterViewModel()
        {
            GenerateSkillsList();
        }

        public double ChallengeRating { get; set; }
        public int MonsterId { get; set; }
        public string Name { get; set; }
        public string SizeTypeAndAlignment { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }

        public string Speed { get; set; }


        private int strengthScore;
        public int StrengthScore
        {
            get { return strengthScore; }
            set
            {
                strengthScore = value;
                StrengthModifier = strengthScore.ModifierText();
            }
        }
        public string StrengthModifier { get; set; }

        private int dexterityScore;
        public int DexterityScore
        {
            get { return dexterityScore; }
            set
            {
                dexterityScore = value;
                DexterityModifier = dexterityScore.ModifierText();
            }
        }
        public string DexterityModifier { get; set; }

        private int constitutionScore;
        public int ConstitutionScore
        {
            get { return constitutionScore; }
            set
            {
                constitutionScore = value;
                ConstitutionModifier = constitutionScore.ModifierText();
            }
        }
        public string ConstitutionModifier { get; set; }

        private int intelligenceScore;
        public int IntelligenceScore
        {
            get { return intelligenceScore; }
            set
            {
                intelligenceScore = value;
                IntelligenceModifier = intelligenceScore.ModifierText();
            }
        }
        public string IntelligenceModifier { get; set; }

        private int wisdomScore;
        public int WisdomScore
        {
            get { return wisdomScore; }
            set
            {
                wisdomScore = value;
                WisdomModifier = wisdomScore.ModifierText();
            }
        }
        public string WisdomModifier { get; set; }

        private int charismaScore;
        public int CharismaScore
        {
            get { return charismaScore; }
            set
            {
                charismaScore = value;
                CharismaModifier = charismaScore.ModifierText();
            }
        }
        public string CharismaModifier { get; set; }


        public string Senses { get; set; }
        public string Traits { get; set; }
        public string Languages { get; set; }
        public string Tag { get; set; }


        //public int StrengthSavingThrow { get; set; }
        //public int Athletics { get; set; }

        //public int DexteritySavingThrow { get; set; }
        //public int Acrobatics { get; set; }
        //public int SleightOfHand { get; set; }
        //public int Stealth { get; set; }

        //public int ConstitutionSavingThrow { get; set; }

        //public int IntelligenceSavingThrow { get; set; }
        //public int Arcana { get; set; }
        //public int History { get; set; }
        //public int Investigation { get; set; }
        //public int Nature { get; set; }
        //public int Religion { get; set; }

        //public int WisdomSavingThrow { get; set; }
        //public int AnimalHandling { get; set; }
        //public int Insight { get; set; }
        //public int Medicine { get; set; }
        //public int Perception { get; set; }
        //public int Survival { get; set; }

        //public int CharismaSavingThrow { get; set; }
        //public int Deception { get; set; }
        //public int Intimidation { get; set; }
        //public int Performance { get; set; }
        //public int Persuasion { get; set; }


        //public int ProficiencyBonus { get; set; }


        public List<SkillViewModel> StrengthSkills { get; set; } = new List<SkillViewModel>();
        public List<SkillViewModel> DexteritySkills { get; set; } = new List<SkillViewModel>();
        public List<SkillViewModel> ConstitutionSkills { get; set; } = new List<SkillViewModel>();
        public List<SkillViewModel> IntelligenceSkills { get; set; } = new List<SkillViewModel>();
        public List<SkillViewModel> WisdomSkills { get; set; } = new List<SkillViewModel>();
        public List<SkillViewModel> CharismaSkills { get; set; } = new List<SkillViewModel>();


        private void GenerateSkillsList()
        {
            StrengthSkills.Add(new SkillViewModel("Saving Throw"));
            StrengthSkills.Add(new SkillViewModel("Athletics"));

            DexteritySkills.Add(new SkillViewModel("Saving Throw"));
            DexteritySkills.Add(new SkillViewModel("Acrobatics"));
            DexteritySkills.Add(new SkillViewModel("Sleight of Hand"));
            DexteritySkills.Add(new SkillViewModel("Stealth"));

            ConstitutionSkills.Add(new SkillViewModel("Saving Throw"));

            IntelligenceSkills.Add(new SkillViewModel("Saving Throw"));
            IntelligenceSkills.Add(new SkillViewModel("Arcana"));
            IntelligenceSkills.Add(new SkillViewModel("History"));
            IntelligenceSkills.Add(new SkillViewModel("Investigation"));
            IntelligenceSkills.Add(new SkillViewModel("Nature"));
            IntelligenceSkills.Add(new SkillViewModel("Religion"));

            WisdomSkills.Add(new SkillViewModel("Saving Throw"));
            WisdomSkills.Add(new SkillViewModel("Animal Handling"));
            WisdomSkills.Add(new SkillViewModel("Insight"));
            WisdomSkills.Add(new SkillViewModel("Medicine"));
            WisdomSkills.Add(new SkillViewModel("Perception"));
            WisdomSkills.Add(new SkillViewModel("Survival"));

            CharismaSkills.Add(new SkillViewModel("Saving Throw"));
            CharismaSkills.Add(new SkillViewModel("Deception"));
            CharismaSkills.Add(new SkillViewModel("Intimidation"));
            CharismaSkills.Add(new SkillViewModel("Performance"));
            CharismaSkills.Add(new SkillViewModel("Persuasion"));
        }
    }
}
