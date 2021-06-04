using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DnDCharacterBuilderData
{
    public class UserService : IUserService
    {
        private readonly DnDCharacterBuilderDataContext _context;

        public UserService()
        {
            _context = new DnDCharacterBuilderDataContext();
        }
        public UserService(DnDCharacterBuilderDataContext context)
        {
            _context = context;
        }
        public void AddUser(User u)
        {
            _context.Users.Add(u);
            _context.SaveChanges();
        }
        public bool CheckUserName(string userName)
        {
            bool uniqueName = true;
            foreach (var user in _context.Users)
            {
                if (user.UserName == userName)
                { uniqueName = false; }
            }
            return uniqueName;
        }
    }
}
