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
        public void RemoveCharacter(int characterId)
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
                    where c.CharacterId == characterId && c.UserId == userId 
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
        public List<Classes> RetrieveAllClasses()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                return db.Class.ToList();
            }
        }
        public List<Races> RetrieveAllRaces()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                return db.Race.ToList();
            }
        }
        public List<int> RollStats()
        {
            List<int> statLine = new List<int>();
            for (int i = 0; i < 6; i++)
            {
                var random = new Random();
                List<int> dice = new List<int>();
                for (int j = 0; j < 4; j++)
                {
                    dice.Add(random.Next(1, 7));
                }
                int lowestIndex = 0;
                int lowest = Int32.MaxValue;
                foreach (var number in dice)
                {
                    if (number <= lowest)
                    {
                        lowest = number;
                        lowestIndex = dice.IndexOf(lowest);
                    }
                }
                dice.RemoveAt(lowestIndex);
                int stat = 0;
                foreach (var number in dice)
                {
                    stat += number;
                }
                statLine.Add(stat);
            }
            statLine.Sort();
            statLine.Reverse();
            return statLine;
        }
        public void AddCharacterToActiveCharacters(int characterId)
        {
            List<string> userDeets = new List<string>();
            int userId = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var loggedin =
                    from u in db.loggedIns
                    select u.UserId;
                foreach (var number in loggedin)
                {
                    userId = number;
                }
                var characterDetails =
                from c in db.Characters
                where c.CharacterId == characterId && c.UserId == userId
                select new { c.UserId, c.UserName, c.CharacterId, c.CharacterName, c.Class, c.Race };

                foreach (var item in characterDetails)
                {
                    userId = item.UserId;
                    userDeets.Add(item.UserName);
                    userDeets.Add(item.CharacterName);
                    userDeets.Add(item.Class);
                    userDeets.Add(item.Race);
                }
            }
            var setActiveCharacter = new ActiveCharacter() { UserId = userId, UserName = userDeets[0], CharacterId = characterId, CharacterName = userDeets[1], Class = userDeets[2], Race = userDeets[3] };
            using (var db = new DnDCharacterBuilderDataContext())
            {
                db.activeCharacters.Add(setActiveCharacter);
                db.SaveChanges();
            }
        }
        public void DeleteActiveCharacter()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.activeCharacters
                    select c;
                foreach (var item in query)
                {
                    db.activeCharacters.Remove(item);
                }
                db.SaveChanges();
            }
        }
        public int ReturnLatestCreatedCharacter()
        {
            int charId = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.Characters
                    select c.CharacterId;
                foreach (var id in query)
                {
                    if (id >= charId)
                    {
                        charId = id;
                    }
                }
            }
            return charId;
        }
        public int ReturnActiveCharId()
        {
            int charID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.activeCharacters
                    select c.CharacterId;
                foreach (var number in query)
                {
                    charID = number;
                }
            }
            return charID;
        }
        public void UdateCharacterDetails(string name, string Class, string race)
        {
            int charID = 0;
            int activeID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.activeCharacters
                    select c.CharacterId;
                foreach (var number in query)
                {
                    charID = number;
                }
                var editCharacter = db.Characters.Find(charID);
                editCharacter.CharacterName = name;
                editCharacter.Class = Class;
                editCharacter.Race = race;
                var query2 =
                    from c in db.activeCharacters
                    where c.CharacterId == charID
                    select c.ActiveCharacterId;
                foreach (var number in query2)
                {
                    activeID = number;
                }
                var editActiveCharacter = db.activeCharacters.Find(activeID);
                editActiveCharacter.CharacterName = name;
                editActiveCharacter.Class = Class;
                editActiveCharacter.Race = race;
                db.SaveChanges();
            }
        }
        public string ReturnCharacterName()
        {
            string name = "";
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.activeCharacters
                    select c;
                foreach (var words in query)
                {
                    name = words.CharacterName;
                }
            }
            return name;
        }
        public string ReturnCharacterRace()
        {
            string name = "";
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.activeCharacters
                    select c;
                foreach (var words in query)
                {
                    name = words.Race;
                }
            }
            return name;
        }
        public string ReturnCharacterClass()
        {
            string name = "";
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.activeCharacters
                    select c;
                foreach (var words in query)
                {
                    name = words.Class;
                }
            }
            return name;
        }
        public bool IsThereAnActiveCharacter()
        {
            bool active = true;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = db.activeCharacters.Count();
                if (query != 0)
                {
                    active = false;
                }
            }
            return active;
        }
    }
}
