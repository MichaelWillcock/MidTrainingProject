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
        public void 
    }
}
