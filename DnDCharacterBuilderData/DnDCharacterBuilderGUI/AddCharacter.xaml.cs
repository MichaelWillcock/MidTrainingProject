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
using DnDCharacterBuilderBusiness;
using DnDCharacterBuilderData;

namespace DnDCharacterBuilderGUI
{
    /// <summary>
    /// Interaction logic for AddedCharacter.xaml
    /// </summary>
    public partial class AddCharacter
    {
        private CharacterManager _characterManager = new CharacterManager();
        private StatlineManager _statlineManager = new StatlineManager();
        public AddCharacter()
        {
            InitializeComponent();
            FillClassListBox();
            FillRaceListBox();
            _characterManager.AddCharacterToActiveCharacters(_characterManager.ReturnLatestCreatedCharacter());
        }
        private void FillClassListBox()
        {
            ClassComboBox.ItemsSource = _characterManager.RetrieveAllClasses();
        }
        private void FillRaceListBox()
        {
            RaceComboBox.ItemsSource = _characterManager.RetrieveAllRaces();
        }

        private void AddCharacter_Click(object sender, RoutedEventArgs e)
        {
            if (RaceComboBox.Text.Contains("Varient") || RaceComboBox.Text.Contains("Half elf"))
            {
                
            }
            else
            {
                _characterManager.UdateCharacterDetails(CharacerNameInput.Text, ClassComboBox.Text, RaceComboBox.Text);
                _statlineManager.AddedRacialModifieresToStatLine(_characterManager.ReturnActiveCharId(), RaceComboBox.Text);
                _characterManager.DeleteActiveCharacter();
                this.Close();
            }
        }

        private void ExitCharacterCreation_Click(object sender, RoutedEventArgs e)
        {
            _characterManager.RemoveCharacter(_characterManager.ReturnLatestCreatedCharacter());
            _characterManager.DeleteActiveCharacter();
            if (MessageBox
                    .Show("Are you sure you wish to exit? Your changes will not be saved.",
                    "Exit Message", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }

        private void StatGenerator_Click(object sender, RoutedEventArgs e)
        {
            StatGenerator statGenerator = new StatGenerator();
            statGenerator.Show();
        }
    }
}
