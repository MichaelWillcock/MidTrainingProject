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
            var mockLoginService = new Mock<ILoginService>();
            //Act
            _sut = new LoginManager(mockLoginService.Object);
            //Assert
            Assert.That(_sut, Is.InstanceOf<LoginManager>());
        }
        [Test]
        public void UpdatesUserNameAndPasswordWhenMethodIsCalled()
        {
            //Arrange
            var mockLoginService = new Mock<ILoginService>();
            var originalLoggedInUser = new LoggedIn
            {
                LoggedInId = 1,
                UserId = 1,
                UserName = "Gandalf",
                Password = "WhatAboutVeryOldFriends"
            };
            //Make up what we want the mock to return
            mockLoginService.Setup(cs => cs.GetLoggedInUserByUserName("Gandalf")).Returns(originalLoggedInUser);

            //Act
            _sut = new LoginManager(mockLoginService.Object);

            var changeUserName = _sut.ChangeUserName("Aragorn");
            var changePassword = _sut.ChangePassword("ForFrodo");

            //Assert
            //Assert.That(changeUserName, Is.True);
            Assert.That(changePassword, Is.True);
        }
    }
}
