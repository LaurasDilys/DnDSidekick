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
            btnClickMe.Checked += BtnClickMe_Checked;
            btnClickMe.Unchecked += BtnClickMe_Unchecked;

            box2.Visibility = Visibility.Hidden;
            txt2.MouseEnter += Txt2_MouseEnter;
            box2.MouseLeave += Box2_MouseLeave;
        }

        private void Box2_MouseLeave(object sender, MouseEventArgs e)
        {
            box2.Visibility = Visibility.Hidden;
            txt2.Visibility = Visibility.Visible;
        }

        private void Txt2_MouseEnter(object sender, MouseEventArgs e)
        {
            box2.Visibility = Visibility.Visible;
            txt2.Visibility = Visibility.Hidden;
        }

        private void BtnClickMe_Unchecked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            button.Content = "Make changes";
            box1.Visibility = Visibility.Hidden;
            txt1.Visibility = Visibility.Visible;
        }

        private void BtnClickMe_Checked(object sender, RoutedEventArgs e)
        {
            var button = (ToggleButton)sender;
            button.Content = "Save changes";
            box1.Visibility = Visibility.Visible;
            txt1.Visibility = Visibility.Hidden;
        }
    }
}
