using DnDSidekick.Business.Models;
using DnDSidekick.Data;
using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DnDSidekick.Presentation
{
    /// <summary>
    /// Interaction logic for CreateWindow.xaml
    /// </summary>
    public partial class CreateWindow : Window
    {
        public CreateWindow()
        {
            InitializeComponent();
            CharacterSheet.Content = characterSheetPage;
            comboBoxCharactersList.ItemsSource = allCharacters;

            btnSave.Click += BtnSave_Click;
            btnEditSelected.Click += BtnEditSelected_Click;
            btnNewCharacter.Click += BtnNewCharacter_Click;
        }

        private CharacterSheetPage characterSheetPage { get; set; } = new CharacterSheetPage();
        public List<CharacterDataModel> allCharacters { get; set; } = ManageDb.GetAllCharacters();

        private void BtnEditSelected_Click(object sender, RoutedEventArgs e)
        {
            int selectedItemIndex = comboBoxCharactersList.SelectedIndex;
            if (selectedItemIndex != -1)
            {
                int selectedCharacterId = allCharacters[selectedItemIndex].Id;
                characterSheetPage.EditSelected(selectedCharacterId);
            }
            allCharacters = ManageDb.GetAllCharacters();
            comboBoxCharactersList.ItemsSource = allCharacters;
        }

        private void BtnNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            characterSheetPage.NewCharacter();
            allCharacters = ManageDb.GetAllCharacters();
            comboBoxCharactersList.ItemsSource = allCharacters;
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            characterSheetPage.SaveCharacter();
            allCharacters = ManageDb.GetAllCharacters();
            comboBoxCharactersList.ItemsSource = allCharacters;
        }
    }
}
