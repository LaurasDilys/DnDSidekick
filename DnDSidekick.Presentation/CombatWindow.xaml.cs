using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Data;
using DnDSidekick.Data.Adapters;
using DnDSidekick.Data.Interfaces;
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
                NoCharacters.Visibility = Visibility.Collapsed;
                CharacterSheet.Content = characterSheetPage;
                characterSheetPage.TweakForCombat();
                int lastSavedCharacterId = ManageDb.GetIdOfLastSavedCharacter();
                characterSheetPage.OpenCharacter(lastSavedCharacterId);
                monstersListPage = new MonstersListPage(characterSheetPage.Character);
                InitializeInformationInAllPages();

                CharSheetMinimized.Content = charSheetMinimizedPage;
                charSheetMinimizedPage.Visibility = Visibility.Collapsed;
                MonsterList.Content = monstersListPage;
                monstersListPage.Visibility = Visibility.Collapsed;
                TransformedCharacter.Content = transformationPage;
                transformationPage.Visibility = Visibility.Collapsed;
            }
            else
            {
                DisableCombatWindowControls();
            }

            comboBoxCharactersList.SelectionChanged += ComboBoxCharactersList_SelectedIndexChanged;
            btnCreateCharacter.Click += BtnCreateCharacter_Click;
            btnPolymorph.Click += BtnPolymorph_Click;
            btnWildShape.Click += BtnWildShape_Click;

            charSheetMinimizedPage.FullViewRequestedEvent += ShowFullCharacterSheet;
            monstersListPage.TransformationRequestedEvent += TransformCharacter;
            transformationPage.CancelTransformationEvent += CancelTransformation;


            transformationPage.CurrentArmorClassChangedEvent += CurrentArmorClassChanged;
        }
        private void CurrentArmorClassChanged(int newArmorClass)
        {
            characterSheetPage.Character.CurrentArmorClass = newArmorClass;
        }

        private void CancelTransformation(int excessDamage)
        {
            EnableCombatWindowControls();
            charSheetMinimizedPage.btnFullView.IsEnabled = true;
            transformationPage.Visibility = Visibility.Collapsed;
            monstersListPage.Visibility = Visibility.Visible;

            if (excessDamage >= 0)
            {
                characterSheetPage.DicreaseHitPoints(excessDamage);
                ShowFullCharacterSheet();
            }
        }

        private void DisableCombatWindowControls()
        {
            comboBoxCharactersList.IsEnabled = false;
            btnPolymorph.IsEnabled = false;
            btnWildShape.IsEnabled = false;
        }

        private void EnableCombatWindowControls()
        {
            comboBoxCharactersList.IsEnabled = true;
            btnPolymorph.IsEnabled = true;
            btnWildShape.IsEnabled = true;
        }

        private void PrepareScreenForTransformation()
        {
            monstersListPage.Visibility = Visibility.Collapsed;
            DisableCombatWindowControls();
            charSheetMinimizedPage.btnFullView.IsEnabled = false;
        }

        private void TransformCharacter(int monsterId)
        {
            PrepareScreenForTransformation();

            ICharacter character = characterSheetPage.Character;
            IMonsterDataModel selectedMonster = ManageDb.GetMonsterFromDataBase(monsterId);

            if (btnPolymorph.IsChecked == true) transformationPage.LoadContent(selectedMonster, character.CurrentArmorClass);
            else transformationPage.LoadContent(character.WildShapedInto(selectedMonster), character.CurrentArmorClass);

            transformationPage.Visibility = Visibility.Visible;
        }

        private CharacterSheetPage characterSheetPage { get; set; } = new CharacterSheetPage();
        private CharSheetMinimizedPage charSheetMinimizedPage { get; set; } = new CharSheetMinimizedPage();
        private MonstersListPage monstersListPage { get; set; }
        private TransformedCharacterPage transformationPage { get; set; } = new TransformedCharacterPage();
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
            if (btnPolymorph.IsChecked == true)
            {
                btnWildShape.IsChecked = false;
                ShowCharSheetMinimized();
                ShowMonsterList("Polymorph");
            }
            else btnPolymorph.IsChecked = true;
        }

        private void BtnWildShape_Click(object sender, RoutedEventArgs e)
        {
            if (btnWildShape.IsChecked == true)
            {
                btnPolymorph.IsChecked = false;
                ShowCharSheetMinimized();
                ShowMonsterList("WildShape");
            }
            else btnWildShape.IsChecked = true;
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

        private void ShowFullCharacterSheet()
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

        private void GenerateCharacterList()
        {
            AllCharacters = ManageDb.GetAllCharactersReversed();
            comboBoxCharactersList.ItemsSource = AllCharacters;
        }

        private void InitializeInformationInAllPages()
        {
            charSheetMinimizedPage.SelectedCharacter = characterSheetPage.Character;
            charSheetMinimizedPage.DataContext = charSheetMinimizedPage.SelectedCharacter;
            monstersListPage.InitializeInformation(characterSheetPage.Character);
        }

        private void UpdateCharactersInAllPages()
        {
            charSheetMinimizedPage.SelectedCharacter = characterSheetPage.Character;
            charSheetMinimizedPage.DataContext = charSheetMinimizedPage.SelectedCharacter;
            monstersListPage.InitializeInformation(characterSheetPage.Character);
            if (btnPolymorph.IsChecked == true) monstersListPage.ShowMonsterList("Polymorph");
            else if (btnWildShape.IsChecked == true) monstersListPage.ShowMonsterList("WildShape");
        }
    }
}
