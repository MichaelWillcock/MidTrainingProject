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
            int x = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var setupPrimaryKey = db.Users.Count<User>();
                x = setupPrimaryKey++;
            }
            var newUser = new User() { UserId = x, UserName = userName, Password = password };
            using(var db = new DnDCharacterBuilderDataContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
            }
        }
    }
}
