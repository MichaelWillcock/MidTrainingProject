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
        public void AddUserToLoggedIn(string userName)
        {
            int x = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var setupPrimaryKey = db.loggedIns.Count<LoggedIn>();
                x = setupPrimaryKey++;
            }
            int userId = 0;
            List<string> userDeets = new List<string>();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var userDetails =
                from u in db.Users
                where u.UserName == userName
                select new {u.UserId, u.UserName, u.Password };

                foreach (var item in userDetails)
                {
                    userId = item.UserId;
                    userDeets.Add(item.UserName);
                    userDeets.Add(item.Password);
                }
            }
            var loggedIn = new LoggedIn() { LoggedInId = x, UserId = userId, UserName = userDeets[0], Password = userDeets[1] };
            using(var db = new DnDCharacterBuilderDataContext())
            {
                db.loggedIns.Add(loggedIn);
                db.SaveChanges();
            }
        }
        public void DeleteLoggedInUser()
        {
            using(var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from u in db.loggedIns
                    select u;
                foreach (var item in query)
                {
                    db.loggedIns.Remove(item);
                }
                db.SaveChanges();
            }
        }
        public string ReturnUserName()
        {
            string name = "";
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var dbname =
                    from u in db.loggedIns
                    select u.UserName;
                foreach (var item in dbname)
                {
                    name += item;
                }
            }
            return name;

        }
        public void ChangeUserName(string newUserName)
        {
            int userID = 0;
            int logInID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var userIdQuery =
                    from u in db.loggedIns
                    select u.UserId;
                foreach (var Id in userIdQuery)
                {
                    userID = Id;
                }
            }
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var userLogInQuery =
                    from u in db.loggedIns
                    select u.LoggedInId;
                foreach (var Id in userLogInQuery)
                {
                    logInID = Id;
                }
            }
            using(var db = new DnDCharacterBuilderDataContext())
            {
                var SelectUser = db.Users.Find(userID+1);
                SelectUser.UserName = newUserName;
                db.SaveChanges();
            }
            using(var db = new DnDCharacterBuilderDataContext())
            {
                var SelectUser = db.loggedIns.Find(logInID);
                SelectUser.UserName = newUserName;
                db.SaveChanges();
            }


        }
        public void ChangePassword(string newPassword)
        {
            int userID = 0;
            int logInID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var userIdQuery =
                    from u in db.loggedIns
                    select u.UserId;
                foreach (var Id in userIdQuery)
                {
                    userID = Id;
                }
            }
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var userLogInQuery =
                    from u in db.loggedIns
                    select u.LoggedInId;
                foreach (var Id in userLogInQuery)
                {
                    logInID = Id;
                }
            }
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var SelectUser = db.Users.Find(userID + 1);
                SelectUser.Password = newPassword;
                db.SaveChanges();
            }
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var SelectUser = db.loggedIns.Find(logInID);
                SelectUser.Password = newPassword;
                db.SaveChanges();
            }
        }
    }
}
