using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterBuilderData;

namespace DnDCharacterBuilderBusiness
{
    public class LoginManager
    {
        public bool CheckNameToPassword(string userName, string password, bool x)
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var passwordQuery =
                    from u in db.Users
                    where u.UserName == userName
                    select u.Password;
                if (passwordQuery.Contains(password))
                {
                    x = true;
                }
            }
            return x;
        }
        public bool IsNameInDatabase(string userName, bool x)
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
