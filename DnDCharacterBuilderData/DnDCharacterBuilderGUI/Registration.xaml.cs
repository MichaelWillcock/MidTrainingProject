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
            bool userCheck = _userManager.CheckUserName(UserNameInput.Text, false);
            if (UserNameInput.Text.Length < 1 || PasswordInput.Password.Length < 1)
            {
                MessageBox.Show("Error: Username and/or Password must be at least 1 character");
            }
            else
            {
                if (userCheck == false)
                {
                    if (PasswordInput.Password != ConfirmPasswordInput.Password)
                    { MessageBox.Show("Error: Passwords do not match"); }
                    else if (PasswordInput.Password.Length < 6)
                    { MessageBox.Show("Error: Password must contain at least 6 characters"); }
                    else
                    {
                        _userManager.AddUser(UserNameInput.Text, PasswordInput.Password);
                        var mainWindow = (MainWindow)Application.Current.MainWindow;
                        mainWindow?.ChangeView(new Login());
                    }
                }
                else
                {
                    MessageBox.Show("Error: Username taken, please enter a different one");
                }
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new Login());
        }
    }
}
