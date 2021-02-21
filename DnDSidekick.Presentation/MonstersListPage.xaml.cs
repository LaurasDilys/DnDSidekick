using DnDSidekick.Business.Models;
using DnDSidekick.Data;
using DnDSidekick.Data.Adapters;
using DnDSidekick.Data.Interfaces;
using DnDSidekick.Data.Models;
using DnDSidekick.Presentation.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DnDSidekick.Presentation
{
    /// <summary>
    /// Interaction logic for MonstersListPage.xaml
    /// </summary>
    public partial class MonstersListPage : Page
    {
        public event Action<int> TransformationRequestedEvent;

        public MonstersListPage(Character selectedCharacter)
        {
            InitializeComponent();
            SelectedCharacter = selectedCharacter;
            WildShapeOptions = PolymorphOptions.IntoWildShapeOptionsFor(SelectedCharacter);
            DataContext = this;

            btnTransform.IsEnabled = false;
            monstersList.SelectionChanged += MonstersList_SelectionChanged;
            btnTransform.Click += BtnTransform_Click;
        }

        private void BtnTransform_Click(object sender, RoutedEventArgs e)
        {
            int selectedItemIndex = monstersList.SelectedIndex;
            if (selectedItemIndex != -1)
            {
                MonsterDataModel selectedMonster = (MonsterDataModel)monstersList.SelectedItem;
                int selectedMonsterId = selectedMonster.MonsterId;
                TransformationRequestedEvent(selectedMonsterId);
            }
        }

        private void MonstersList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedItemIndex = monstersList.SelectedIndex;
            if (selectedItemIndex != -1)
            {
                MonsterDataModel selectedMonster = (MonsterDataModel)monstersList.SelectedItem;
                string transformationType;
                if (monstersList.ItemsSource == PolymorphOptions) transformationType = "Polymorph";
                else transformationType = "Wild Shape";
                btnTransform.Content = $"{transformationType} into {selectedMonster.Name}";
                if (!btnTransform.IsEnabled) btnTransform.IsEnabled = true;
            }
        }

        public Character SelectedCharacter { get; set; }
        private List<MonsterDataModel> PolymorphOptions { get; set; } = ManageDb.GetAllMonstersValueTypes();
        private List<IMonsterDataModel> WildShapeOptions { get; set; }

        private void OrderByDescending(string propertyName, DataGrid list)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(list.ItemsSource);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription(propertyName, ListSortDirection.Descending));
            dataView.Refresh();
        }

        public void ShowMonsterList(string transformationType)
        {
            if (transformationType == "Polymorph") monstersList.ItemsSource = PolymorphOptions;
            else if (transformationType == "WildShape") monstersList.ItemsSource = WildShapeOptions;
            OrderByDescending("ChallengeRating", monstersList);
            btnTransform.Content = "Choose a creature";
        }
    }
}
