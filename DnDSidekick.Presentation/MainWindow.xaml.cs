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

            //Character sheet / Creature sheet
            //Changes can be made on the spot
            //For each change made, numbers between brackets are highlighted in yellow (see "Example ::: " bellow)
            //At the top / corner / somewhere of the screen all changes made can be seen
            //
            //Each line of change made can be removed by pressing an [x]
            //A button can be pressed to discard all changes
            //A button can be pressed to make changes permanent (a MessageBox appears asking "Are you sure?")
            //(Maybe a history of permanent changes can still be accessed somewhere)
            //
            //Hover on skill: Label is hidden, ComboBox is shown, user can choose:
            //Example :::  +4  (skill score is seen next to ComboBox and is updated dinamically)
            //Example ::: [+1] (Dexterity modifier)
            //Example ::: Profficiency (+2) / Expertise (+4)
            //Example ::: Disadvantage (-5 on passive checks)
            //Example ::: Bonus (+1) / Penalty (-1)
            //
            //profficiency (0 – 2): //Can also be changed (0/1) simply by clicking the box before the name
            //BOX None
            //BOX Profficient (dark green)
            //BOX Expert (green)
            //
            //advantage (-1 – 1): //" (Adv)" or " (Dis)" is added to the skill name
            //BOX None
            //BOX Advantage (green)
            //BOX Disadvantage (red)
            //
            //custom bonus
            //[-][0][+]

        }
    }
}
