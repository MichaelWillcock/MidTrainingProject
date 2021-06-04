using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilderData
{
    public interface ILoginService
    {
        public User GetUserByUserName(string userName);
        public LoggedIn GetLoggedInUserByUserName(string UserName);
        public List<User> GetUserList();
        public void AddUserToLoggedIn(string userName);
        public void DeleteLoggedInUser();
        public bool CanOnlyBeOneUserLoggedIn();
        public bool CheckThereIsAUserLoggedIn();
        public string ReturnUserName();
        public void SaveUserChanges();
    }
}
