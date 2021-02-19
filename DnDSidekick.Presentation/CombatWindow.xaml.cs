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
            if (AllCharacters.Count > 0)
            {
                NoCharacters.Visibility = Visibility.Hidden;
                CharacterSheet.Content = characterSheetPage;
                characterSheetPage.TweakForCombat();
                int lastSavedCharacterId = ManageDb.GetIdOfLastSavedCharacter();
                characterSheetPage.OpenCharacter(lastSavedCharacterId);
                monstersListPage = new MonstersListPage(characterSheetPage.Character);
                UpdateCharactersInAllPages();

                CharSheetMinimized.Content = charSheetMinimizedPage;
                charSheetMinimizedPage.Visibility = Visibility.Collapsed;
                MonsterList.Content = monstersListPage;
                monstersListPage.Visibility = Visibility.Collapsed;
                //CharacterTransformed.Content = 
                //
            }
            else
            {
                comboBoxCharactersList.IsEnabled = false;
                btnChooseCharacter.IsEnabled = false;
                btnPolymorph.IsEnabled = false;
                btnWildShape.IsEnabled = false;
            }

            comboBoxCharactersList.SelectionChanged += ComboBoxCharactersList_SelectedIndexChanged;
            btnCreateCharacter.Click += BtnCreateCharacter_Click;
            //btnChooseCharacter.Click += BtnChooseCharacter_Click;
            btnChooseCharacter.IsEnabled = false;
            //
            btnPolymorph.Click += BtnPolymorph_Click;
            btnWildShape.Click += BtnWildShape_Click;
            charSheetMinimizedPage.FullViewRequestedEvent += ShowFullCharacterSheet;
        }

        private CharacterSheetPage characterSheetPage { get; set; } = new CharacterSheetPage();
        private CharSheetMinimizedPage charSheetMinimizedPage { get; set; } = new CharSheetMinimizedPage();
        private MonstersListPage monstersListPage { get; set; }
        private List<CharacterDataModel> AllCharacters { get; set; }

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
                    UpdateCharactersInAllPages();
                }
            }
        }

        private void BtnPolymorph_Click(object sender, RoutedEventArgs e)
        {
            btnWildShape.IsChecked = false;
            ShowCharSheetMinimized();
            ShowMonsterList("Polymorph");
            monstersListPage.btnTransform.Content = "Choose a creature";
            monstersListPage.btnTransform.IsEnabled = false;
        }

        private void BtnWildShape_Click(object sender, RoutedEventArgs e)
        {
            btnPolymorph.IsChecked = false;
            ShowCharSheetMinimized();
            ShowMonsterList("WildShape");
            monstersListPage.btnTransform.IsEnabled = false;
        }

        private void ShowMonsterList(string transformationType)
        {
            monstersListPage.Visibility = Visibility.Visible;
            monstersListPage.ShowMonsterList(transformationType);
        }

        private void ShowCharSheetMinimized()
        {
            characterSheetPage.Visibility = Visibility.Collapsed;
            charSheetMinimizedPage.Visibility = Visibility.Visible;
        }

        private void ShowFullCharacterSheet(object sender, RoutedEventArgs e)
        {
            monstersListPage.Visibility = Visibility.Collapsed;
            charSheetMinimizedPage.Visibility = Visibility.Collapsed;
            characterSheetPage.Visibility = Visibility.Visible;
            btnPolymorph.IsChecked = false;
            btnWildShape.IsChecked = false;
        }

        private void BtnCreateCharacter_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            CreateWindow createWindow = new CreateWindow();
            createWindow.Show();
        }

        //private void BtnChooseCharacter_Click(object sender, RoutedEventArgs e)
        //{
        //    int selectedItemIndex = comboBoxCharactersList.SelectedIndex;
        //    if (selectedItemIndex != -1)
        //    {
        //        CharacterDataModel selectedCharacter = (CharacterDataModel)comboBoxCharactersList.SelectedItem;
        //        int selectedCharacterId = selectedCharacter.Id;
        //        characterSheetPage.OpenCharacter(selectedCharacterId);
        //    }
        //    GenerateCharacterList();
        //    UpdateCharactersInAllPages();
        //}

        private void GenerateCharacterList()
        {
            AllCharacters = ManageDb.GetAllCharactersReversed();
            comboBoxCharactersList.ItemsSource = AllCharacters;
        }

        private void UpdateCharactersInAllPages()
        {
            charSheetMinimizedPage.SelectedCharacter = characterSheetPage.Character;
            charSheetMinimizedPage.DataContext = charSheetMinimizedPage.SelectedCharacter;
            //
            monstersListPage.SelectedCharacter = characterSheetPage.Character;
            //
        }
    }
}
