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
        public ViewCharacter()
        {
            InitializeComponent();

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
    }
}
