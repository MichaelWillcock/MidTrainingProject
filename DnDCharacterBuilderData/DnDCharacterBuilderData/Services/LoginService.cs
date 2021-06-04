using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilderData
{
    public class LoginService : ILoginService
    {
        private readonly DnDCharacterBuilderDataContext _context;
        public LoginService()
        {
            _context = new DnDCharacterBuilderDataContext();
        }
        public LoginService(DnDCharacterBuilderDataContext context)
        {
            _context = context;
        }
        public User GetUserByUserName(string userName)
        {
            User selectedUser = new User();
            foreach (User user in _context.Users)
            {
                if (user.UserName == userName)
                { selectedUser = user; break; }
            }
            return selectedUser;
        }
        public LoggedIn GetLoggedInUserByUserName(string UserName)
        {
            LoggedIn LoggedInUser = new LoggedIn();
            if (CheckThereIsAUserLoggedIn() == true)
            {
                foreach (LoggedIn user in _context.loggedIns)
                { LoggedInUser = user; }
            }
            return LoggedInUser;
        }
        public List<User> GetUserList()
        {
            return _context.Users.ToList();
        }
        public void AddUserToLoggedIn(string userName)
        {
            User selectedUser = GetUserByUserName(userName);
            LoggedIn activeUser = new LoggedIn() { LoggedInId = 1, UserId = selectedUser.UserId, UserName = selectedUser.UserName, Password = selectedUser.Password };
            _context.loggedIns.Add(activeUser);
            _context.SaveChanges();
        }
        public void DeleteLoggedInUser()
        {
            foreach (LoggedIn user in _context.loggedIns)
            {
                _context.loggedIns.Remove(user);
                _context.SaveChanges();
            }
        }
        public bool CheckThereIsAUserLoggedIn()
        {
            bool IsAUserLoggedIn = false;
            if (_context.loggedIns.Count() == 1)
            { IsAUserLoggedIn = true; }
            return IsAUserLoggedIn;
        }
        public bool CanOnlyBeOneUserLoggedIn()
        {
            bool CanAUserBeLoggedIn = true;
            if (_context.loggedIns.Count() != 0)
            { CanAUserBeLoggedIn = false; }
            return CanAUserBeLoggedIn;
        }
        public string ReturnUserName()
        {
            string userName = null;
            if (CheckThereIsAUserLoggedIn() == true)
            {
                foreach (LoggedIn user in _context.loggedIns)
                {
                    userName = user.UserName;
                }
            }
            return userName;
        }
        public void SaveUserChanges()
        {
            _context.SaveChanges();
        }
    }
}
