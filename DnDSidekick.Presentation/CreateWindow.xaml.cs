using DnDSidekick.Business.Models;
using DnDSidekick.Data;
using DnDSidekick.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
            GenerateCharacterList();
            CharacterSheet.Content = characterSheetPage;
            int lastSavedCharacterId = ManageDb.GetIdOfLastSavedCharacter();
            if (lastSavedCharacterId != 0) characterSheetPage.OpenCharacter(lastSavedCharacterId);

            comboBoxCharactersList.SelectionChanged += ComboBoxCharactersList_SelectedIndexChanged;
            btnNewCharacter.Click += BtnNewCharacter_Click;
            btnSave.Click += BtnSave_Click;
        }

        private CharacterSheetPage characterSheetPage { get; set; } = new CharacterSheetPage();

        public List<CharacterDataModel> AllCharacters { get; set; }

        private void ComboBoxCharactersList_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedItemIndex = comboBoxCharactersList.SelectedIndex;
            if (selectedItemIndex != -1)
            {
                CharacterDataModel selectedCharacter = (CharacterDataModel)comboBoxCharactersList.SelectedItem;
                int selectedCharacterId = selectedCharacter.Id;
                if (selectedCharacterId != characterSheetPage.Character.Id)
                {
                    characterSheetPage.OpenCharacter(selectedCharacterId);
                    GenerateCharacterList();
                }
            }
        }

        private void BtnNewCharacter_Click(object sender, RoutedEventArgs e)
        {
            characterSheetPage.NewCharacter();
            GenerateCharacterList();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            characterSheetPage.SaveCharacter();
            GenerateCharacterList();
        }

        private void GenerateCharacterList()
        {
            AllCharacters = ManageDb.GetAllCharactersReversed();
            comboBoxCharactersList.ItemsSource = AllCharacters;
        }
    }
}
