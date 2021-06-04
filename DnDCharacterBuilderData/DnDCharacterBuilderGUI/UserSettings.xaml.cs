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
    /// Interaction logic for UserSettings.xaml
    /// </summary>
    public partial class UserSettings : Page
    {
        private LoginManager _loginManager = new LoginManager();
        private UserManager _userManager = new UserManager();
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
            bool userCheck = _userManager.CheckUserName(UserNameInput.Text);
            if(userCheck == true)
            {
                if(UserNameInput.Text.Length < 1)
                {
                    MessageBox.Show("Error: Username must contain at least one character");
                }
                else
                {
                    _loginManager.ChangeUserName(UserNameInput.Text);
                }
            }
            else
            {
                MessageBox.Show("Error - That username is unavailable, please enter a different one");
            }
        }
        private void ChangePassword_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordInput.Password != ConfirmPasswordInput.Password)
            {
                MessageBox.Show("Error - Passwords do not match");
            }
            else
            {
                if (PasswordInput.Password.Length < 1)
                {
                    MessageBox.Show("Error: Username must contain at least one character");
                }
                else
                {
                    _loginManager.ChangePassword(PasswordInput.Password);
                }
            }
        }
    }
}
