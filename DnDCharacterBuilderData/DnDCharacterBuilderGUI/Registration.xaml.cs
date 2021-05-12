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
    /// Interaction logic for Registration.xaml
    /// </summary>
    public partial class Registration : Page
    {
        private UserManager _userManager = new UserManager();
        public Registration()
        {
            InitializeComponent();
        }
        private void AddUser_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordInput.Password != ConfirmPasswordInput.Password)
            {
                MessageBox.Show("Error - Passwords do not match");
            }
            else
            {
                _userManager.AddUser(UserNameInput.Text, PasswordInput.Password);
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new Login());
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Login());
        }
    }
}
