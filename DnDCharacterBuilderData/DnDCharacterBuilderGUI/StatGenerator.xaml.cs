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
using System.Windows.Shapes;
using DnDCharacterBuilderBusiness;
using DnDCharacterBuilderData;

namespace DnDCharacterBuilderGUI
{
    /// <summary>
    /// Interaction logic for StatGenerator.xaml
    /// </summary>
    public partial class StatGenerator : Window
    {
        private CharacterManager _characterManager = new CharacterManager();
        private StatlineManager _statlineManager = new StatlineManager();
        private List<int> _rolledStats { get; set; }
        private List<int> _confirmedStats { get; set; }
        public StatGenerator()
        {
            InitializeComponent();
        }
        private void FillStatListBox()
        {
            _rolledStats = _characterManager.RollStats();
            RolledStatsListBox.ItemsSource = _rolledStats;
            _confirmedStats = _rolledStats;
        }
        private void FillScoreComboBox()
        {
            StrengthScoreListBox.ItemsSource = _confirmedStats;
            DexterityScoreListBox.ItemsSource = _confirmedStats;
            ConstitutionScoreListBox.ItemsSource = _confirmedStats;
            IntelligenceScoreListBox.ItemsSource = _confirmedStats;
            WisdomScoreListBox.ItemsSource = _confirmedStats;
            CharismaScoreListBox.ItemsSource = _confirmedStats;
        }
        private void RollStats_Click(object sender, RoutedEventArgs e)
        {
            FillStatListBox();
            FillScoreComboBox();
        }
        private void SwitchToAverageStats_Click(object sender, RoutedEventArgs e)
        {
            List<int> averageStats = new List<int> { 15, 14, 13, 12, 10, 8 };
            _confirmedStats = averageStats;
            FillScoreComboBox();
        }
        private void AssignStatsToCharacter_Click(object sender, RoutedEventArgs e)
        {
            int Strength = Int32.Parse(StrengthScoreListBox.Text);
            int Dexterity = Int32.Parse(DexterityScoreListBox.Text);
            int Constitution = Int32.Parse(ConstitutionScoreListBox.Text);
            int Intelligence = Int32.Parse(IntelligenceScoreListBox.Text);
            int Wisdom = Int32.Parse(WisdomScoreListBox.Text);
            int Charisma = Int32.Parse(CharismaScoreListBox.Text);
            if (StrengthScoreListBox.SelectedIndex == DexterityScoreListBox.SelectedIndex || StrengthScoreListBox.SelectedIndex == ConstitutionScoreListBox.SelectedIndex || StrengthScoreListBox.SelectedIndex == IntelligenceScoreListBox.SelectedIndex || StrengthScoreListBox.SelectedIndex == WisdomScoreListBox.SelectedIndex || StrengthScoreListBox.SelectedIndex == CharismaScoreListBox.SelectedIndex)
            { MessageBox.Show("Error: Cannot input duplicate stats, please alter selection"); }
            else if (DexterityScoreListBox.SelectedIndex == ConstitutionScoreListBox.SelectedIndex || DexterityScoreListBox.SelectedIndex == IntelligenceScoreListBox.SelectedIndex || DexterityScoreListBox.SelectedIndex == WisdomScoreListBox.SelectedIndex || DexterityScoreListBox.SelectedIndex == CharismaScoreListBox.SelectedIndex)
            { MessageBox.Show("Error: Cannot input duplicate stats, please alter selection"); }
            else if (ConstitutionScoreListBox.SelectedIndex == IntelligenceScoreListBox.SelectedIndex || ConstitutionScoreListBox.SelectedIndex == WisdomScoreListBox.SelectedIndex || ConstitutionScoreListBox.SelectedIndex == CharismaScoreListBox.SelectedIndex)
            { MessageBox.Show("Error: Cannot input duplicate stats, please alter selection"); }
            else if (IntelligenceScoreListBox.SelectedIndex == WisdomScoreListBox.SelectedIndex || IntelligenceScoreListBox.SelectedIndex == CharismaScoreListBox.SelectedIndex)
            { MessageBox.Show("Error: Cannot input duplicate stats, please alter selection"); }
            else if (WisdomScoreListBox.SelectedIndex == CharismaScoreListBox.SelectedIndex)
            { MessageBox.Show("Error: Cannot input duplicate stats, please alter selection"); }
            else
            {
                _statlineManager.AddStatlineToCharacter(_characterManager.ReturnActiveCharId(),
                Strength, Dexterity, Constitution, Intelligence, Wisdom, Charisma);
                this.Close();
            }
        }
        private void DisgardScores_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox
                    .Show("Are you sure you wish to exit? Your changes will not be saved.",
                    "Exit Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
