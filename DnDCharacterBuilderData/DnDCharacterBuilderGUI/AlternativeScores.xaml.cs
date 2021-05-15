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

namespace DnDCharacterBuilderGUI
{
    /// <summary>
    /// Interaction logic for AlternativeScores.xaml
    /// </summary>
    public partial class AlternativeScores : Window
    {
        public AlternativeScores()
        {
            InitializeComponent();
            Application.Current.MainWindow = this;
            Loaded += OnMainWindowLoaded;
        }
        private void OnMainWindowLoaded(object sender, RoutedEventArgs e)
        {
            ChangeView(new Login());
        }

        public void ChangeView(Page view)
        {
            MainFrame.NavigationService.Navigate(view);
        }
    }
}
