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
        public void AddUser(string userName, string password)
        {
            var newUser = new User() { UserName = userName, Password = password };
            using(var db = new DnDCharacterBuilderDataContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
        public bool CheckUserName(string userName, bool x)
        {
            using(var db = new DnDCharacterBuilderDataContext())
            {
                var userNameQuery =
                    from u in db.Users
                    select u.UserName;
                foreach (var name in userNameQuery)
                {
                    if (name == userName)
                    {
                        x = true;
                    }
                }
            }
            return x;
        }
    }
}
