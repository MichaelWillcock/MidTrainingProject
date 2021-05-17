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
    /// Interaction logic for AlternativeScores.xaml
    /// </summary>
    public partial class AlternativeScores : Window
    {
        private CharacterManager _characterManager = new CharacterManager();
        private StatlineManager _statlineManager = new StatlineManager();
        private DetailManager _detailManager = new DetailManager();
        public AlternativeScores()
        {
            InitializeComponent();
        }
        public void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (_characterManager.ReturnCharacterRace() == "Half Elf" && (PrimaryASI.Text == "Charisma" || SecondaryASI.Text == "Charmisma"))
            {
                MessageBox.Show("Error: Additional bonuses cannot be applied to Charisma, please select another option");
            }
            else
            {
                _statlineManager.HalfElfOrVariantASI(PrimaryASI.Text, SecondaryASI.Text);
                _detailManager.AssignFirstLevelAndHitPoints();
                _characterManager.DeleteActiveCharacter();
                this.Close();
            }
        }
    }
}
