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

namespace DnDCharacterBuilderGUI
{
    /// <summary>
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : Page
    {
        public UserSettings()
        {
            InitializeComponent();
        }

        private void ReturnToHomePage_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Homepage());
        }
        private void ChangeUsername_Click(object sender, RoutedEventArgs e)
        {

        }
        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
