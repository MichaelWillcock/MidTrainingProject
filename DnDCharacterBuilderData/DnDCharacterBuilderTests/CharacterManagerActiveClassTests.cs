using NUnit.Framework;
using DnDCharacterBuilderBusiness;
using DnDCharacterBuilderData;
using System.Linq;
using System.Collections.Generic;

namespace DnDCharacterBuilderTests
{
    class CharacterManagerActiveClassTests
    {
        UserManager _userManager;
        LoginManager _loginManager;
        CharacterManager _characterManager;
        StatlineManager _statlineManager;

        [SetUp]
        public void Setup()
        {
            _userManager = new UserManager();
            _loginManager = new LoginManager();
            _characterManager = new CharacterManager();
            _statlineManager = new StatlineManager();
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
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = db.Characters.Where(c => c.UserName == "TestUser");
                foreach (var ID in query)
                { CharID = ID.CharacterId; }
            }
            _characterManager.AddCharacterToActiveCharacters(CharID);
        }
        [Test]
        public void ChangeCharacterNameRaceAndClass()
        {
            bool changed = false;
            string newname = ""; string newclass = ""; string newrace = "";
            List<string> details = new List<string>() { "newTestName", "newTestClass", "newTestRace" };
            _characterManager.UdateCharacterDetails(details[0], details[1], details[2]);
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                {
                    newname = character.CharacterName;
                    newclass = character.Class;
                    newrace = character.Race;
                }
            }
            if (details[0] == newname && details[1] == newclass && details[2] == newrace)
            { changed = true; }
            Assert.AreEqual(changed, true);
        }
        [Test]
        public void ReturnsActiveCharacterName()
        {
            string expected = "TestName";
            string actual = _characterManager.ReturnCharacterName();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ReturnsActiveCharacterClass()
        {
            string expected = "TestClass";
            string actual = _characterManager.ReturnCharacterClass();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ReturnsActiveCharacterRace()
        {
            string expected = "TestRace";
            string actual = _characterManager.ReturnCharacterRace();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ReturnsActiveCharacterLevel()
        {
            int expected = 1;
            int levelID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                int chaID = 0;
                var query = from c in db.activeCharacters select c;
                foreach (var charID in query)
                { chaID = charID.CharacterId; levelID = charID.ActiveCharacterId; }
                var activeChar = db.activeCharacters.Find(levelID);
                activeChar.Level = 1;
                var charlevel = db.Characters.Find(chaID);
                charlevel.Level = 1;
                db.SaveChanges();
            }
            int actual = _characterManager.ReturnCharacterLevel();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void ReturnsActiveCharacterHitPoints()
        {
            int expected = 1;
            int levelID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                int chaID = 0;
                var query = from c in db.activeCharacters select c;
                foreach (var charID in query)
                { chaID = charID.CharacterId; levelID = charID.ActiveCharacterId; }
                var activeChar = db.activeCharacters.Find(levelID);
                activeChar.HitPoints = 1;
                var charlevel = db.Characters.Find(chaID);
                charlevel.HitPoints = 1;
                db.SaveChanges();
            }
            int actual = _characterManager.ReturnCharacterHP();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void IfActiveCharacterReturnsTrue()
        {
            bool expected = false;
            bool actual = _characterManager.IsThereAnActiveCharacter();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void GeneratesAStatlineAndAssignsCharacterID()
        {
            int expected = 60;
            int charID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { charID = character.CharacterId; }
            }
            _statlineManager.AddStatlineToCharacter(charID, 10, 10, 10, 10, 10, 10);
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from s in db.Stats where s.CharacterId == charID select s;
                int actual = 0;
                foreach (var stat in query)
                { actual = stat.Strength + stat.Dexterity + stat.Constitution + stat.Intelligence + stat.Wisdom + stat.Charisma; }
                Assert.AreEqual(expected, actual);
            }
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
