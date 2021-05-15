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
    /// Interaction logic for AddCharacter.xaml
    /// </summary>
    public partial class AddCharacter : Window
    {
        private CharacterManager _characterManager = new CharacterManager();
        public AddCharacter()
        {
            InitializeComponent();
            FillClassListBox();
            FillRaceListBox();
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
            _characterManager.AddCharacter(CharacerNameInput.Text, ClassComboBox.SelectedItem.ToString(), RaceComboBox.SelectedItem.ToString());
            this.Close();
        }

        private void ExitCharacterCreation_Click(object sender, RoutedEventArgs e)
        {
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
