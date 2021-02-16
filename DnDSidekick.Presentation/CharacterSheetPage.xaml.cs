using DnDSidekick.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for CharacterSheetPage.xaml
    /// </summary>
    public partial class CharacterSheetPage : Page
    {
        public CharacterSheetPage()
        {
            InitializeComponent();
            DataContext = Character;





            





            test.Click += Test_Click;
        }

        public Character Character { get; set; } = new Character();








        

        private void Test_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(Character.Strength.SavingThrow.Modifier.ToString());
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("^[-+]?[0-9]+$");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
