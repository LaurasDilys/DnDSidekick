using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Business.Services;
using DnDSidekick.Data;
using DnDSidekick.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnDSidekick.Presentation
{
    /// <summary>
    /// Interaction logic for CharacterSheetPage.xaml
    /// </summary>
    public partial class CharacterSheetPage : Page
    {
        public CharacterSheetPage()
        {
            InitializeComponent();
            DataContext = Character;

            btnFullHealth.Click += BtnFullHealth_Click;
            btnTakeDamage.Click += BtnTakeDamage_Click;
        }

        public Character Character { get; set; } = new Character();

        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("^[-+]?[0-9]+$");
            //e.Handled = regex.IsMatch(e.Text);
        }

        private void BtnFullHealth_Click(object sender, RoutedEventArgs e)
        {
            Character.CurrentHitPoints = Character.HitPoints;
        }

        private void BtnTakeDamage_Click(object sender, RoutedEventArgs e)
        {
            string text = txtDamageAmount.Text;
            double damageAmount = 0;
            if (!text.Contains(',') && double.TryParse(text, out damageAmount) && damageAmount > 0 && (damageAmount % 1 == 0))
            {
                DicreaseHitPoints((int)damageAmount);
                txtDamageAmount.Text = "";
            }
            else MessageBox.Show("Please enter a positive integer as damage amount.");
        }

        public void DicreaseHitPoints(int damageAmount)
        {
            if (Character.TemporaryHitPoints > damageAmount) Character.TemporaryHitPoints -= damageAmount;
            else
            {
                damageAmount -= Character.TemporaryHitPoints;
                Character.TemporaryHitPoints = 0;
                Character.CurrentHitPoints -= damageAmount;
            }
        }

        public void OpenCharacter(int id)
        {
            if (Character.ChangesWereMade())
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes to this character?", "", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    if (Character.Name == "")
                    {
                        MessageBox.Show("Please assign a name to this character.");
                        return;
                    }
                    else Character.Id = Character.ToDataBase();
                }
                else if (result == MessageBoxResult.Cancel) return;
            }
            Character = ManageDb.GetCharacterFromDataBase(id);
            DataContext = Character;
        }

        public void NewCharacter()
        {
            if (Character.ChangesWereMade())
            {
                MessageBoxResult result = MessageBox.Show("Do you want to save changes to this character?", "", MessageBoxButton.YesNoCancel);
                if (result == MessageBoxResult.Yes)
                {
                    if (Character.Name == "")
                    {
                        MessageBox.Show("Please assign a name to this character.");
                        return;
                    }
                    else Character.Id = Character.ToDataBase();
                }
                else if (result == MessageBoxResult.Cancel) return;
            }
            Character = new Character();
            DataContext = Character;
        }

        public void SaveCharacter()
        {
            if (Character.Name == "")
            {
                MessageBox.Show("Please assign a name to this character.");
                return;
            }

            if (!Character.ChangesWereMade()) { MessageBox.Show("No changes have been made to this character."); }
            else
            {
                int currentId = Character.Id;
                if (currentId == 0) MessageBox.Show("Character has been saved.");
                else MessageBox.Show("Changes have been saved.");
                Character.Id = Character.ToDataBase();
            }
        }

        public void TweakForCombat()
        {
            txtName.IsReadOnly = true;
            txtClass.IsReadOnly = true;
            txtRace.IsReadOnly = true;
            txtBackground.IsReadOnly = true;
            txtAlignment.IsReadOnly = true;
            txtMaxHitPoints.IsReadOnly = true;
            txtArmorClass.IsReadOnly = true;
            txtInitiativeBonus.IsReadOnly = true;
            txtSpeed.IsReadOnly = true;
        }
    }
}
