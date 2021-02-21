using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Data.Adapters;
using DnDSidekick.Data.Interfaces;
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
    /// Interaction logic for TransformedCharacterPage.xaml
    /// </summary>
    public partial class TransformedCharacterPage : Page
    {
        public TransformedCharacterPage(IMonsterDataModel transformedDb, int currentAC)
        {
            InitializeComponent();
            transformedDb.IntoViewModel(TransformedCharacter);
            CurrentAC = currentAC;
            CurrentHP = TransformedCharacter.HitPoints;
            DataContext = this;
        }

        public IMonsterViewModel TransformedCharacter { get; set; } = new MonsterViewModel();
        public int CurrentHP { get; set; }
        public int CurrentAC { get; set; }
    }
}
