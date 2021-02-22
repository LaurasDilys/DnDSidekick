using DnDSidekick.Data;
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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.Hide();
            ManageDb.GenerateInitialData();
            this.Show();

            btnCombat.Click += BtnCombat_Click;
            btnCreateOrEdit.Click += BtnCreateOrEdit_Click;
        }

        private void BtnCreateOrEdit_Click(object sender, RoutedEventArgs e)
        {
            CreateWindow createWindow = new CreateWindow();
            createWindow.Show();
        }

        private void BtnCombat_Click(object sender, RoutedEventArgs e)
        {
            CombatWindow combatWindow = new CombatWindow();
            combatWindow.Show();
        }
    }
}
