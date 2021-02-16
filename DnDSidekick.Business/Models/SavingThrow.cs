using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace DnDSidekick.Business.Models
{
    public class SavingThrow : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;


        private int modifier;
        public int Modifier
        {
            get { return modifier; }
            set
            {
                modifier = value;
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
