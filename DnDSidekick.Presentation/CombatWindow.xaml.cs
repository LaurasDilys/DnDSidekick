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
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DnDSidekick.Presentation
{
    /// <summary>
    /// Interaction logic for CombatWindow.xaml
    /// </summary>
    public partial class CombatWindow : Window
    {
        public CombatWindow()
        {
            InitializeComponent();
            GenerateCharacterList();
            CharacterSheet.Content = characterSheetPage;
            CharSheetMinimized.Content = charSheetMinimizedPage;
            MonsterList.Content = monstersListPage;
            //CharacterTransformed.Content = 
            charSheetMinimizedPage.Visibility = Visibility.Collapsed;
            monstersListPage.Visibility = Visibility.Collapsed;
            //if (allCharacters.Count > 0) characterSheetPage.EditSelected(ManageDb.LastOpenedCharacter());

            btnChooseCharacter.Click += BtnChooseCharacter_Click;
        }

        private int selectedCharacterId { get; set; } = 0;
        private CharacterSheetPage characterSheetPage { get; set; } = new CharacterSheetPage();
        private CharSheetMinimizedPage charSheetMinimizedPage { get; set; } = new CharSheetMinimizedPage();
        private MonstersListPage monstersListPage { get; set; } = new MonstersListPage();

        public List<CharacterDataModel> AllCharacters { get; set; }

        private void BtnChooseCharacter_Click(object sender, RoutedEventArgs e)
        {
            int selectedItemIndex = comboBoxCharactersList.SelectedIndex;
            if (selectedItemIndex != -1)
            {
                CharacterDataModel selectedCharacters = (CharacterDataModel)comboBoxCharactersList.SelectedItem;
                selectedCharacterId = selectedCharacters.Id;
                characterSheetPage.OpenCharacter(selectedCharacterId);
            }
            GenerateCharacterList();
        }

        private void GenerateCharacterList()
        {
            AllCharacters = ManageDb.GetAllCharactersReversed();
            comboBoxCharactersList.ItemsSource = AllCharacters;
        }
    }
}
