using DnDSidekick.Business.Models;
using DnDSidekick.Business.Services;
using DnDSidekick.Data;
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



        }

        public Character Character { get; set; } = new Character();


        public void SaveCharacter()
        {
            if (Character.Name == "") { MessageBox.Show("Please assign a name to this character."); }
            else if (!Character.ChangesHaveBeenMade()) { MessageBox.Show("No changes have been made to this character."); }
            else Character.ToDataBase();
        }


        private void NumberValidation(object sender, TextCompositionEventArgs e)
        {
            //Regex regex = new Regex("^[-+]?[0-9]+$");
            //e.Handled = regex.IsMatch(e.Text);
        }
    }
}
