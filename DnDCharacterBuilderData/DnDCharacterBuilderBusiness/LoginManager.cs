using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterBuilderData;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterBuilderBusiness
{
    public class LoginManager
    {
        public User SelectedUser { get; set; }
        public LoggedIn LoggedInUser { get; set; }

        private ILoginService _service;

        //We didn't have a constructor now we have two

        //No argument constructor so that our code doesn't break
        public LoginManager()
        {
            _service = new LoginService();
        }
        public LoginManager(ILoginService service)
        {
            if (service == null)
            {
                throw new ArgumentException("Customer Service cannot be null");
            }
            _service = service;
        }
        public bool CheckNameToPassword(string userName, string password)
        {
            bool matchingNameAndPassword = false;
            User selectedUser = _service.GetUserByUserName(userName);
            if (userName == selectedUser.UserName && password == selectedUser.Password)
            { matchingNameAndPassword = true; }
            return matchingNameAndPassword;
        }
        public bool IsNameInDatabase(string userName)
        {
            bool IsNameInDatabase = false;
            foreach (User user in _service.GetUserList())
            {
                if (userName == user.UserName)
                { IsNameInDatabase = true; break; }
            }
            return IsNameInDatabase;
        }
        public void AddUserToLoggedIn(string userName)
        {
            if (_service.CanOnlyBeOneUserLoggedIn() == true)
            { _service.AddUserToLoggedIn(userName); }
        }
        public void DeleteLoggedInUser()
        {
            _service.DeleteLoggedInUser();
        }
        public string ReturnUserName()
        {
            string name = null;
            if (_service.CheckThereIsAUserLoggedIn() == true)
            { name = _service.ReturnUserName(); }
            return name;
        }
        public bool ChangeUserName(string newUserName)
        {
            SelectedUser = _service.GetUserByUserName(ReturnUserName());
            LoggedInUser = _service.GetLoggedInUserByUserName(ReturnUserName());
            if (SelectedUser == null || LoggedInUser == null)
            {
                return false;
            }
            {
                SelectedUser.UserName = newUserName;
                LoggedInUser.UserName = newUserName;

                try
                {
                    _service.SaveUserChanges();
                }
                catch (DbUpdateConcurrencyException e) // an exception will be thrown if the database had been updated since last loaded
                {
                    Debug.WriteLine($"Error updating {SelectedUser.UserName}");
                    return false;
                }
                return true;
            }
        }
        public bool ChangePassword(string newPassword)
        {
            SelectedUser = _service.GetUserByUserName(ReturnUserName());
            LoggedInUser = _service.GetLoggedInUserByUserName(ReturnUserName());
            if (SelectedUser == null || LoggedInUser == null)
            {
                return false;
            }
            {
                SelectedUser.Password = newPassword;
                LoggedInUser.Password = newPassword;

                try
                {
                    _service.SaveUserChanges();
                }
                catch (DbUpdateConcurrencyException e) // an exception will be thrown if the database had been updated since last loaded
                {
                    Debug.WriteLine($"Error updating {SelectedUser.UserName}");
                    return false;
                }
                return true;
            }
        }
    }
}
