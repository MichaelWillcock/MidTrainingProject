using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterBuilderBusiness;
using DnDCharacterBuilderData;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterBuilderTests
{
    class LoginServiceTests
    {
        private UserService _sut;
        private LoginService _asut;
        private DnDCharacterBuilderDataContext _context;

        [OneTimeSetUp]
        public void Setup()
        {
            //options are that the database will have the same structure as the original database,
            //will be stored in memory.
            var options = new DbContextOptionsBuilder<DnDCharacterBuilderDataContext>().UseInMemoryDatabase(databaseName: "Test DB").Options;
            _context = new DnDCharacterBuilderDataContext(options);
            _sut = new UserService(_context);
            _asut = new LoginService(_context);

            //Add stuff to our in memory database
            _sut.AddUser(new User { UserId = 1, UserName = "Gandalf", Password = "SpeakFriend" });
            _sut.AddUser(new User { UserId = 2, UserName = "Frodo", Password = "AndEnter" });
        }
        [Test]
        public void ReturnsCorrectUserDetails_WhenDatabaseSearchedByUserName()
        {
            var result = _asut.GetUserByUserName("Gandalf");
            int ID = result.UserId;
            string name = result.UserName;
            string password = result.Password;
            Assert.That(ID, Is.EqualTo(1));
            Assert.That(name, Is.EqualTo("Gandalf"));
            Assert.That(password, Is.EqualTo("SpeakFriend"));
        }
        [Test]
        public void NoUserLoggedInSoIsLoggedInUserReturnsFalse()
        {
            var NoLoggedInUserNotEqual1SoReturnsFalse = _asut.CheckThereIsAUserLoggedIn();
            var CanAUserBeLoggedInReturnsTrue = _asut.CanOnlyBeOneUserLoggedIn();
            Assert.That(NoLoggedInUserNotEqual1SoReturnsFalse, Is.False);
            Assert.That(CanAUserBeLoggedInReturnsTrue, Is.True);
        }
        [Test]
        public void AddAUserToTheLoggedInTableIncreasesTheCountBy1()
        {
            var numberBeforeAddition = _context.loggedIns.Count();
            _asut.AddUserToLoggedIn("Gandalf");
            var numberAfterAddition = _context.loggedIns.Count();
            var UserLoggedInCheckReturnsTrue = _asut.CheckThereIsAUserLoggedIn();
            Assert.That(numberAfterAddition, Is.EqualTo(numberBeforeAddition + 1));
            Assert.That(UserLoggedInCheckReturnsTrue, Is.True);

            //CleanUp
            _asut.DeleteLoggedInUser();
        }
        [Test]
        public void DeleteTheUserFromTheLoggedInListDecreasesItsCountByOne()
        {
            _asut.AddUserToLoggedIn("Gandalf");
            var numberBeforeDeletion = _context.loggedIns.Count();
            _asut.DeleteLoggedInUser();
            var numberAfterDeletion = _context.loggedIns.Count();
            var UserLoggedInCheckReturnsFalse = _asut.CheckThereIsAUserLoggedIn();
            Assert.That(numberBeforeDeletion, Is.EqualTo(numberAfterDeletion + 1));
            Assert.That(UserLoggedInCheckReturnsFalse, Is.False);
        }
        [Test]
        public void GetUserList_ReturnsAListOfCreatedUsers()
        {
            var UserList = _asut.GetUserList();
            int numberOfUsers = UserList.Count();
            Assert.That(numberOfUsers, Is.EqualTo(2));
        }
        [Test]
        public void OnceAUserIsLoggedInTheUserNameOfThatUserIsReturned()
        {
            _asut.AddUserToLoggedIn("Gandalf");
            var result = _asut.GetLoggedInUserByUserName("Gandalf");
            int ID = result.UserId;
            string name = result.UserName;
            string password = result.Password;
            Assert.That(ID, Is.EqualTo(1));
            Assert.That(name, Is.EqualTo("Gandalf"));
            Assert.That(password, Is.EqualTo("SpeakFriend"));
        }
    }
}
