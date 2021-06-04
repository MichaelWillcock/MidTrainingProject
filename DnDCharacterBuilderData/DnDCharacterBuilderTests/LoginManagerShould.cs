using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DnDCharacterBuilderBusiness;
using DnDCharacterBuilderData;
using Moq;
using Microsoft.EntityFrameworkCore;

namespace DnDCharacterBuilderTests
{
    class LoginManagerShould
    {
        private LoginManager _sut;
        [Test]
        public void BeAbleToConstruct_LoginManager()
        {
            //Arrange
            var mockUserService = new Mock<ILoginService>();
            //Act
            _sut = new LoginManager(mockUserService.Object);
            //Assert
            Assert.That(_sut, Is.InstanceOf<LoginManager>());
        } 
    }
}
