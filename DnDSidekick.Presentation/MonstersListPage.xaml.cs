using DnDSidekick.Business.Models;
using DnDSidekick.Data;
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
        public MonstersListPage()
        {
            InitializeComponent();
            monstersList.ItemsSource = Monsters;
            OrderByDescending("ChallengeRating", monstersList);
            DataContext = this;
        }

        //public List<MonsterListModel> Monsters { get; set; } = MonsterListServices.GetAllMonstersForList();

        private List<MonsterDataModel> Monsters { get; set; } = ManageDb.GetAllMonstersValueTypes();

        private void OrderByDescending(string propertyName, DataGrid list)
        {
            ICollectionView dataView = CollectionViewSource.GetDefaultView(list.ItemsSource);
            dataView.SortDescriptions.Clear();
            dataView.SortDescriptions.Add(new SortDescription(propertyName, ListSortDirection.Descending));
            dataView.Refresh();
        }

        public void ShowMonsterList(string transformationType)
        {
            if (transformationType == "WildShape")
            {
                //
            }
        }
    }
}
