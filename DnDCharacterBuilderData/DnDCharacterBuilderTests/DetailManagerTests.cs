using NUnit.Framework;
using DnDCharacterBuilderBusiness;
using DnDCharacterBuilderData;
using System.Linq;
using System.Collections.Generic;

namespace DnDCharacterBuilderTests
{
    class DetailManagerTests
    {
        UserManager _userManager;
        LoginManager _loginManager;
        CharacterManager _characterManager;
        StatlineManager _statlineManager;
        DetailManager _detailManager;

        [SetUp]
        public void Setup()
        {
            _userManager = new UserManager();
            _loginManager = new LoginManager();
            _characterManager = new CharacterManager();
            _statlineManager = new StatlineManager();
            _detailManager = new DetailManager();
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
            _characterManager.AddCharacter("TestName", "Rogue", "Dark Elf");
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = db.Characters.Where(c => c.UserName == "TestUser");
                foreach (var ID in query)
                { CharID = ID.CharacterId; }
            }
            _characterManager.AddCharacterToActiveCharacters(CharID);
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            _statlineManager.AddStatlineToCharacter(CharID, 10, 10, 10, 10, 10, 10);
        }
        [Test]
        public void DarkElfRogueLevel1Returns10Abilities()
        {
            int expected = 10;
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            int actual = _detailManager.ReturnRacialAndLevel1Abilities(CharID, 1).Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DarkElfRogueLevel2Returns10Abilities()
        {
            int expected = 11;
            int CharID = 0;
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query)
                { CharID = character.CharacterId; }
            }
            int actual = _detailManager.ReturnRacialAndLevel1Abilities(CharID, 2).Count;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DarkElfRogueIsLevel1With8HitPoints()
        {
            int expectedLevel = 1;
            int expectedHitPoints = 8;
            int actualLevel = 0;
            int actualHitPoints = 0;
            bool allGood = false;
            _detailManager.AssignFirstLevelAndHitPoints();
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query) { actualLevel = character.Level; actualHitPoints = character.HitPoints; }
            }
            if (expectedHitPoints == actualHitPoints && expectedLevel == actualLevel) { allGood = true; }
            Assert.AreEqual(true, allGood);
        }
        [Test]
        public void DarkElfRogueIsLevel2With12HitPoints()
        {
            int expectedLevel = 2;
            int expectedHitPoints = 12;
            int actualLevel = 0;
            int actualHitPoints = 0;
            bool allGood = false;
            _detailManager.AssignFirstLevelAndHitPoints();
            _detailManager.ChangeLevelAndUpdateHitPOints(2);
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var query = from c in db.activeCharacters select c;
                foreach (var character in query) { actualLevel = character.Level; actualHitPoints = character.HitPoints; }
            }
            if (expectedHitPoints == actualHitPoints && expectedLevel == actualLevel) { allGood = true; }
            Assert.AreEqual(true, allGood);
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
