using NUnit.Framework;
using DnDCharacterBuilderBusiness;
using DnDCharacterBuilderData;
using System.Linq;
using System.Collections.Generic;

namespace DnDCharacterBuilderTests
{
    class CharacterManagerTests
    {
        UserManager _userManager;
        LoginManager _loginManager;
        CharacterManager _characterManager;

        [SetUp]
        public void Setup()
        {
            _userManager = new UserManager();
            _loginManager = new LoginManager();
            _characterManager = new CharacterManager();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from u in db.Users
                    where u.UserName == "TestName" || u.UserName == "NewTestName"
                    select u;
                db.Users.RemoveRange(query);
                db.SaveChanges();
            }
            _loginManager.DeleteLoggedInUser();
            _userManager.AddUser("TestUser", "Password");
            _loginManager.AddUserToLoggedIn("TestUser");
            _characterManager.AddCharacter("TestName", "TestClass", "TestRace");
        }
        [Test]
        public void RetrieveAllCharactersOfLoggedInUser()
        {
            int expected = 1;
            int actual = _characterManager.RetrieveAllUsersCharacters().Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RetrieveAllClassesInDatabase()
        {
            int expected = 12;
            int actual = _characterManager.RetrieveAllClasses().Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void RetrieveAllRacesInDatabase()
        {
            int expected = 15;
            int actual = _characterManager.RetrieveAllRaces().Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void StatsAreRolledForActiveCharacter()
        {
            int expected = 6;
            int actual = _characterManager.RollStats().Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void AddSelectedCharToActiveChar()
        {
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = db.Characters.Where(c => c.UserName == "TestUser");
                foreach (var ID in query)
                { CharID = ID.CharacterId; }
            }
            _characterManager.AddCharacterToActiveCharacters(CharID);
            int expected = 1;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                int actual = db.activeCharacters.Count();
                Assert.AreEqual(expected, actual);
            }
        }
        [Test]
        public void DeletesAllCharsFromActiveChars()
        {
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = db.Characters.Where(c => c.UserName == "TestUser");
                foreach (var ID in query)
                { CharID = ID.CharacterId; }
            }
            _characterManager.AddCharacterToActiveCharacters(CharID);
            int expected = 0;
            int result = 1;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                int actual = db.activeCharacters.Count();
                if (actual > 0)
                {
                    _characterManager.DeleteActiveCharacter();
                    result = db.activeCharacters.Count();
                }
                Assert.AreEqual(expected, result);
            }
        }
        [Test]
        public void GivestHighestNumberCharIDFromListOfChars()
        {
            int expected = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var IdQuery =
                    from c in db.Characters
                    where c.CharacterName == "TestName"
                    select c.CharacterId;
                foreach (var ID in IdQuery)
                { expected = ID; }
            }
            int actual = _characterManager.ReturnLatestCreatedCharacter();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ReturnsCharIdOfActiveCharacter()
        {
            int expected = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c.CharacterId;
                foreach (var ID in query)
                { expected = ID; }
            }
            int actual = _characterManager.ReturnActiveCharId();
            Assert.AreEqual(expected, actual);
        }
        [TearDown]
        public void TearDown()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from u in db.Users
                    where u.UserName == "TestName" || u.UserName == "NewTestName" || u.UserName == "TestUser"
                    select u;
                db.Users.RemoveRange(query);
                db.SaveChanges();
            }
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query =
                    from c in db.Characters
                    where c.UserName == "TestUser"
                    select c;
                db.Characters.RemoveRange(query);
                db.SaveChanges();
            }
            _loginManager.DeleteLoggedInUser();
            _characterManager.DeleteActiveCharacter();
        }
    }
}
