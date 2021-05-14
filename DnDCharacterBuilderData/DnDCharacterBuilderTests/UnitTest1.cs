using NUnit.Framework;
using DnDCharacterBuilderBusiness;
using DnDCharacterBuilderData;
using System.Linq;

namespace DnDCharacterBuilderTests
{
    public class Tests
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
        }

        [Test]
        public void UserCountIncreasesBy1WhenUserAdded()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var preAddCount = db.Users.Count();
                _userManager.AddUser("TestName", "Password");
                var postAddCount = db.Users.Count();
                Assert.AreEqual(preAddCount+1, postAddCount);
            }
        }
        [Test]
        public void UniqueNameDoesNotReturnTrue()
        {
            bool expected = false;
            bool result = false;
            result = _userManager.CheckUserName("TestName", result);
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void NonUniqueNameReturnsTrue()
        {
            bool expected = true;
            bool result = false;
            _userManager.AddUser("TestName", "Password");
            result = _userManager.CheckUserName("TestName", result);
            Assert.AreEqual(result, expected);
        }
        [Test]
        public void MatchingNameAndPasswordReturnsTrue()
        {
            bool expected = true;
            bool result = false;
            _userManager.AddUser("TestName", "Password");
            result = _loginManager.CheckNameToPassword("TestName", "Password", result);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void NonMatchingNameAndPasswordDoesNotReturnTrue()
        {
            bool expected = true;
            bool result = false;
            _userManager.AddUser("TestName", "Password");
            result = _loginManager.CheckNameToPassword("TestName", "WordPass", result);
            Assert.AreNotEqual(expected, result);
        }
        [Test]
        public void NameNotInDataBaseDoesNotReturnTrue()
        {
            bool expected = false;
            bool result = false;
            result = _loginManager.IsNameInDatabase("TestName", result);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void NameInDataBaseReturnsTrue()
        {
            bool expected = false;
            bool result = false;
            _userManager.AddUser("TestName", "Password");
            result = _loginManager.IsNameInDatabase("TestName", result);
            Assert.AreNotEqual(expected, result);
        }
        [Test]
        public void LoggedInUserIncreasesLoggedInCountByOne()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                _userManager.AddUser("TestName", "Password");
                _loginManager.AddUserToLoggedIn("TestName");
                var postAddCount = db.loggedIns.Count();
                Assert.AreEqual(postAddCount, 1);
            }
        }
        [Test]
        public void DeleteLoggedInUserDecreasesLoggedInCountByOne()
        {
            using (var db = new DnDCharacterBuilderDataContext())
            {
                _userManager.AddUser("TestName", "Password");
                _loginManager.AddUserToLoggedIn("TestName");
                _loginManager.DeleteLoggedInUser();
                var postDeleteCount = db.loggedIns.Count();
                Assert.AreEqual(0, postDeleteCount);
            }
        }
        [Test]
        public void ReturnsLoggedInName()
        {
            _userManager.AddUser("TestName", "Password");
            _loginManager.AddUserToLoggedIn("TestName");
            var userName = _loginManager.ReturnUserName();
            Assert.AreEqual(userName, "TestName");
        }
        [Test]
        public void NameChangeSuccessful()
        {
            _userManager.AddUser("TestName", "Password");
            _loginManager.AddUserToLoggedIn("TestName");
            var oldUserName = _loginManager.ReturnUserName();
            _loginManager.ChangeUserName("NewTestName");
            var newUserName = _loginManager.ReturnUserName();
            Assert.AreNotEqual(oldUserName, newUserName);
        }
        [Test]
        public void PasswordChangeSuccessful()
        {
            bool expected = true;
            bool result = false;
            _userManager.AddUser("TestName", "Password");
            _loginManager.AddUserToLoggedIn("TestName");
            _loginManager.ChangePassword("NewPassword");
            result = _loginManager.CheckNameToPassword("TestName", "NewPassword", result);
            Assert.AreEqual(expected, result);
        }
        [Test]
        public void AddedCharacterToCharacters()
        {
            _userManager.AddUser("TestName", "Password");
            _loginManager.AddUserToLoggedIn("TestName");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var preAddCount = db.Characters.Count();
                _characterManager.AddCharacter("TestCharacter", "TestClass", "TestRace");
                var postAddCount = db.Characters.Count();
                Assert.AreEqual(preAddCount + 1, postAddCount);
            }
        }
        [Test]
        public void RemovedCharacterFromCharacters()
        {
            _userManager.AddUser("TestName", "Password");
            _loginManager.AddUserToLoggedIn("TestName");
            _characterManager.AddCharacter("TestCharacter", "TestClass", "TestRace");
            using (var db = new DnDCharacterBuilderDataContext())
            {
                var preDeleteCount = db.Characters.Count();
                _characterManager.RemoveCharacter("TestCharacter");
                var postDeleteCount = db.Characters.Count();
                Assert.AreEqual(preDeleteCount, postDeleteCount+1);
            }
        }

        [TearDown]
        public void TearDown()
        {
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
        }
    }
}