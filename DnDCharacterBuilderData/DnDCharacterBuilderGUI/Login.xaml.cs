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
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        private LoginManager _loginManager = new LoginManager();
        public Login()
        {
            InitializeComponent();
            _loginManager.DeleteLoggedInUser();
        }
        private void Registration_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Registration());
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            bool userNameCheck = _loginManager.IsNameInDatabase(UserNameInput.Text);
            bool passwordMatch = _loginManager.CheckNameToPassword(UserNameInput.Text, PasswordInput.Password);
            if (userNameCheck == false)
            {
                if (MessageBox
                    .Show("Error - User name not recognised. Do you need to register?",
                    "Registration Check", MessageBoxButton.YesNo)==MessageBoxResult.Yes)
                {
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new Registration());
                }
            }
            else
            {
                if (passwordMatch == true)
                {
                    _loginManager.AddUserToLoggedIn(UserNameInput.Text);
                    var mainWindow = (MainWindow)Application.Current.MainWindow;
                    mainWindow?.ChangeView(new Homepage());
                }
                else
                {
                    MessageBox.Show("Error - incorrect user name or password entered");
                }
            }
        }
    }
}
