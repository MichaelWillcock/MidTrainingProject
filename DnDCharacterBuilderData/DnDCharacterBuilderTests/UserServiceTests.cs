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
    class UserServiceTests
    {
        private UserService _sut;
        private DnDCharacterBuilderDataContext _context;

        [OneTimeSetUp]
        public void Setup()
        {
            //options are that the database will have the same structure as the original database,
            //will be stored in memory.
            var options = new DbContextOptionsBuilder<DnDCharacterBuilderDataContext>().UseInMemoryDatabase(databaseName: "Test DB").Options;
            _context = new DnDCharacterBuilderDataContext(options);
            _sut = new UserService(_context);

            //Add stuff to our in memory database
            _sut.AddUser(new User { UserId = 1, UserName = "Gandalf", Password = "SpeakFriend" });
            _sut.AddUser(new User { UserId = 2, UserName = "Frodo", Password = "AndEnter" });
        }
        [Test]
        public void GivenANewUser_AddUserAddsThemToTheDatabase()
        {
            var numberOfCustomersBefore = _context.Users.Count();
            var newUser = new User { UserId = 3, UserName = "Samwise", Password = "POE-TAY-TOES" };
            _sut.AddUser(newUser);
            var numberOfCustomersAfter = _context.Users.Count();

            //Assert
            Assert.That(numberOfCustomersAfter, Is.EqualTo(numberOfCustomersBefore + 1));

            //Clean Up
            _context.Users.Remove(newUser);
            _context.SaveChanges();
        }
        [Test]
        public void GivenANewUser_UniqueUserNameReturnsTrue()
        {
            var newUser = new User { UserId = 4, UserName = "Pippin", Password = "FoolOfATook!!" };
            bool result = _sut.CheckUserName(newUser.UserName);
            Assert.That(result, Is.True);
        }
        [Test]
        public void GivenANewuser_NonUniqueUserNameReturnsFalse()
        {
            var newuser = new User { UserId = 4, UserName = "Frodo", Password = "MrUnderhill" };
            bool result = _sut.CheckUserName(newuser.UserName);
            Assert.That(result, Is.False);
        }
    }
}
