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
using DnDCharacterBuilderData;
using DnDCharacterBuilderBusiness;

namespace DnDCharacterBuilderGUI
{
    public partial class ViewCharacter : Window
    {
        private CharacterManager _characterManager = new CharacterManager();
        private StatlineManager _statlineManager = new StatlineManager();
        public ViewCharacter()
        {
            InitializeComponent();
            FillAbilityScoreBoxes();
        }
        private void ExitCharacterCreation_Click(object sender, RoutedEventArgs e)
        {
            _characterManager.DeleteActiveCharacter();
            if (MessageBox
                    .Show("Are you sure you wish to exit?",
                    "Exit Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
        private void FillAbilityScoreBoxes()
        {
            List<string> Strength = new List<string> (_statlineManager.ReturnStrengthAndModifier(_characterManager.ReturnActiveCharId()));
            List<string> Dexterity = new List<string>(_statlineManager.ReturnDexterityScoreAndModifier(_characterManager.ReturnActiveCharId()));
            List<string> Constitution = new List<string>(_statlineManager.ReturnConsitutionScoreAndModifier(_characterManager.ReturnActiveCharId()));
            List<string> Intelligence = new List<string>(_statlineManager.ReturnIntelligenceScoreAndModifier(_characterManager.ReturnActiveCharId()));
            List<string> Wisdom = new List<string>(_statlineManager.ReturnWisdomScoreAndModifier(_characterManager.ReturnActiveCharId()));
            List<string> Charisma = new List<string>(_statlineManager.ReturnCharismaScoreAndModifier(_characterManager.ReturnActiveCharId()));
            StrengthScore.Text = Strength[0]; StrengthMod.Text = Strength[1];
            DexScore.Text = Dexterity[0]; DexMod.Text = Dexterity[1];
            ConScore.Text = Constitution[0]; ConMod.Text = Constitution[1];
            IntScore.Text = Intelligence[0]; IntMod.Text = Intelligence[1];
            WisScore.Text = Wisdom[0]; WisMod.Text = Wisdom[1];
            ChaScore.Text = Charisma[0]; ChaMod.Text = Charisma[1];
        }
    }
}
