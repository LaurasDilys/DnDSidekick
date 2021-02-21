using DnDSidekick.Business.Interfaces;
using DnDSidekick.Business.Models;
using DnDSidekick.Data.Adapters;
using DnDSidekick.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
        public event Action<int> CancelTransformationEvent;

        public event Action<int> CurrentArmorClassChangedEvent;

        public TransformedCharacterPage()
        {
            InitializeComponent();
            btnCancel.Click += BtnCancel_Click;
            btnHeal.Click += BtnHeal_Click;
            btnTakeDamage.Click += BtnTakeDamage_Click;
        }

        public void LoadContent(IMonsterDataModel transformedDb, int currentAC)
        {
            transformedDb.IntoViewModel(TransformedCharacter);
            CurrentAC = currentAC;
            CurrentHP = TransformedCharacter.HitPoints;
            DataContext = null;
            DataContext = this;
        }

        private int GetHitPointAmount()
        {
            string text = txtHitPointAmount.Text;
            double hitPointAmount = 0;
            if (!text.Contains(',') && double.TryParse(text, out hitPointAmount) && hitPointAmount > 0 && (hitPointAmount % 1 == 0))
            {
                txtHitPointAmount.Text = "";
                return (int)hitPointAmount;
            }
            MessageBox.Show("Please enter a positive integer as damage amount.");
            return -1;
        }

        private void BtnHeal_Click(object sender, RoutedEventArgs e)
        {
            int hitPointAmount = GetHitPointAmount();
            if (hitPointAmount > 0)
            {
                CurrentHP += hitPointAmount;
                if (CurrentHP > TransformedCharacter.HitPoints) CurrentHP = TransformedCharacter.HitPoints;
                DataContext = null;
                DataContext = this;
            }
        }

        private void BtnTakeDamage_Click(object sender, RoutedEventArgs e)
        {
            int hitPointAmount = GetHitPointAmount();
            if (hitPointAmount > 0)
            {
                CurrentHP -= hitPointAmount;
                if (CurrentHP <= 0)
                {
                    string excessDamage = "";
                    if (CurrentHP < 0) excessDamage = $" The excess damage ({-CurrentHP}) was carried over to your normal form.";
                    MessageBox.Show($"The {TransformedCharacter.Name} has droped to 0 hit points.{excessDamage}");
                    CancelTransformationEvent(-CurrentHP);
                }
                DataContext = null;
                DataContext = this;
            }
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            CancelTransformationEvent(-1);
            txtHitPointAmount.Text = "";
        }

        public IMonsterViewModel TransformedCharacter { get; set; } = new MonsterViewModel();

        public int CurrentHP { get; set; }
        
        private int currentAC;
        public int CurrentAC
        {
            get { return currentAC; }
            set
            {
                currentAC = value;
                CurrentArmorClassChangedEvent(currentAC);
            }
        }
    }
}
