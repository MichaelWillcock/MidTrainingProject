﻿using System;
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
    /// Interaction logic for Homepage.xaml
    /// </summary>
    public partial class Homepage : Page
    {
        private LoginManager _loginManager = new LoginManager();
        private CharacterManager _characterManager = new CharacterManager();
        public Homepage()
        {
            InitializeComponent();
            Welcome.Text = $"Welcome...  {_loginManager.ReturnUserName()}!!";
            FillListBox();
        }
        private void FillListBox()
        {
            CharacterListBox.ItemsSource = _characterManager.RetrieveAllUsersCharacters();
        }
        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox
                    .Show("Are you sure you wish to logout?",
                    "Logout", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                _loginManager.DeleteLoggedInUser();
                var mainWindow = (MainWindow)Application.Current.MainWindow;
                mainWindow?.ChangeView(new Login());
            }
        }
        private void UserSettings_Click(object sender, RoutedEventArgs e)
        {
            var mainWindow = (MainWindow)Application.Current.MainWindow;
            mainWindow?.ChangeView(new UserSettings());
        }
        private void AddCharacter_Click(object sender, RoutedEventArgs e)
        {
            _characterManager.AddCharacter("Name", "Class", "Race");
            AddCharacter addCharacter = new AddCharacter();
            addCharacter.Show();
        }
        private void RemoveSelectedCharacter_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox
                    .Show("Are you sure you wish to delete this character?",
                    "Delete Character", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var selectedCharacter = CharacterListBox.SelectedItem;
                string[] characterIdString = selectedCharacter.ToString().Split("-");
                int characterId = Int32.Parse(characterIdString[0]);
                _characterManager.RemoveCharacter(characterId);
                FillListBox();
            }
        }

        private void Refresh_Click(object sender, RoutedEventArgs e)
        {
            FillListBox();
        }
    }
}
