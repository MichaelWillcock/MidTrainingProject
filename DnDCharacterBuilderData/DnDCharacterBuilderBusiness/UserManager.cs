using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterBuilderData;

namespace DnDCharacterBuilderBusiness
{
    public class UserManager
    {
        //Permanant connection to the service
        private IUserService _service;

        //We require a constructor or two
        public UserManager()
        {
            _service = new UserService();
        }
        public UserManager(IUserService service)
        {
            if (service == null)
            {
                throw new ArgumentException("User Service cannot be null");
            }
            _service = service;
        }

        public void AddUser(string userName, string password)
        {
            var newUser = new User() { UserName = userName, Password = password };
            _service.AddUser(newUser);
        }
        public bool CheckUserName(string userName)
        {
            return _service.CheckUserName(userName);
        }
    }
}
