using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DnDSidekick.Business.Models
{
    public class Skill : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private int modifier;
        public int Modifier
        {
            get { return modifier; }
            set
            {
                modifier = value;
                Passive = Modifier + 10; // Taip skaičiuojasi Passive Skill
                OnPropertyChanged();
            }
        }


        private int proficiencyBonus;
        public int ProficiencyBonus
        {
            get { return proficiencyBonus; }
            set
            {
                proficiencyBonus = value;
                UpdateModifier();
            }
        }


        private int correspondingAbilityModifier;
        public int CorrespondingAbilityModifier
        {
            get { return correspondingAbilityModifier; }
            set
            {
                correspondingAbilityModifier = value;
                UpdateModifier();
            }
        }


        private bool proficiency;
        public bool Proficiency
        {
            get { return proficiency; }
            set
            {
                proficiency = value;
                UpdateModifier();
            }
        }


        private int passive;
        public int Passive
        {
            get { return passive; }
            set
            {
                passive = value;
                OnPropertyChanged();
            }
        }


        private void UpdateModifier()
        {
            int prof = Proficiency ? 1 : 0;
            Modifier = CorrespondingAbilityModifier + prof * ProficiencyBonus;
        }

        public void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
