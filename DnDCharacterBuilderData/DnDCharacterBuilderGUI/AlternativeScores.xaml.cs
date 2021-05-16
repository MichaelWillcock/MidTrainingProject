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
        public AlternativeScores()
        {
            InitializeComponent();
        }
        public void Submit_Click(object sender, RoutedEventArgs e)
        {
            _statlineManager.HalfElfOrVariantASI(PrimaryASI.Text, SecondaryASI.Text);
            _characterManager.DeleteActiveCharacter();
            this.Close();
        }
    }
}
