using DnDSidekick.Business.Models;
using DnDSidekick.Presentation.Services;
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
            MonstersList.ItemsSource = Monsters;
            DataContext = this;
        }

        public List<MonsterListModel> Monsters { get; set; } = MonsterListServices.GetAllMonstersForList();
    }
}
