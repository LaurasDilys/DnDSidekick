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
            InitializeComponent();
            GenerateCharacterList();
            CharacterSheet.Content = characterSheetPage;
            CharSheetMinimized.Content = charSheetMinimizedPage;
            MonsterList.Content = monstersListPage;
            //CharacterTransformed.Content = 
            //if (allCharacters.Count > 0) characterSheetPage.EditSelected(ManageDb.LastOpenedCharacter());
        }

        private CharacterSheetPage characterSheetPage { get; set; } = new CharacterSheetPage();
        private CharSheetMinimizedPage charSheetMinimizedPage { get; set; } = new CharSheetMinimizedPage();
        private MonstersListPage monstersListPage { get; set; } = new MonstersListPage();

        public List<CharacterDataModel> AllCharacters { get; set; }

        private void GenerateCharacterList()
        {
            AllCharacters = ManageDb.GetAllCharactersReversed();
            comboBoxCharactersList.ItemsSource = AllCharacters;
        }
    }
}
