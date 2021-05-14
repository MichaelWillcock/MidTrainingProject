using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterBuilderData;

namespace DnDCharacterBuilderBusiness
{
    public class CharacterManager
    {
        public void AddCharacter(string characterName, string Class, string race)
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                int userId = 0;
                var query =
                    from u in db.loggedIns
                    select u;
                foreach (var number in query)
                {
                    userId = number.UserId;
                }
                var user = db.Users.Find(userId);
                user.Characters.Add(new Character { UserId = userId, UserName = user.UserName.ToString(), CharacterName = characterName, Class = Class, Race = race });
                db.SaveChanges();

            }
        }
        public void RemoveCharacter(string characterName)
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                int userId = 0;
                var userLoggedInQuery =
                    from u in db.loggedIns
                    select u;
                foreach (var number in userLoggedInQuery)
                {
                    userId = number.UserId;
                }
                var query =
                    from c in db.Characters
                    where c.CharacterName == characterName && c.UserId == userId 
                    select c;
                db.Characters.RemoveRange(query);
                db.SaveChanges();
            }
        }
        public List<Character> RetrieveAllUsersCharacters()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                int userId = 0;
                var userLoggedInQuery =
                    from u in db.loggedIns
                    select u;
                foreach (var number in userLoggedInQuery)
                {
                    userId = number.UserId;
                }
                return db.Characters.Where(u => u.UserId == userId).ToList();
            }
        }
    }
}
