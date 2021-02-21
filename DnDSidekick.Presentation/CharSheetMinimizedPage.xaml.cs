using DnDSidekick.Business.Models;
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
    /// Interaction logic for CharSheetMinimizedPage.xaml
    /// </summary>
    public partial class CharSheetMinimizedPage : Page
    {
        public event Action FullViewRequestedEvent;

        public CharSheetMinimizedPage()
        {
            InitializeComponent();
            btnFullView.Click += BtnFullView_Click;
        }

        private void BtnFullView_Click(object sender, RoutedEventArgs e)
        {
            FullViewRequestedEvent();
        }

        public Character SelectedCharacter { get; set; } = new Character();
    }
}
