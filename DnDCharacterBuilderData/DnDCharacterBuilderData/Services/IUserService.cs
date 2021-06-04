using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilderData
{
    public interface IUserService
    {
        public void AddUser(User u);
        public bool CheckUserName(string userName);
    }
}
