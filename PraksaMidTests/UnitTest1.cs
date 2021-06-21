using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PraksaMid;
using PraksaMid.Model;


namespace PraksaMidTests
{
    [TestClass]
    public class UnitTest1
    {
        

        [TestInitialize]
        public void Setup()
        {
            
        }

        [TestCleanup]
        public void Teardown()
        {
            
        }

        [TestMethod]
        public void TestContactEmailModelIsEmailValid()
        {
            var model = new ContactEmailModel();
            model.Email = "krpa@gmail.com";
            var expectedEmail = "krpa@gmail.com";
            Assert.AreEqual(model.Email, expectedEmail);
        }

        [TestMethod]
        public void TestLoginIsSuccessful()
        {

        }

        [TestMethod]
        public void TestLoginIsNotSuccessful()
        {

        }

        [TestMethod]
        public void TestGetAttendants()
        {

        }

        [TestMethod]
        public void TestGetPasswordSalt()
        {

        }

        [TestMethod]
        public void TestGetContactEmail()
        {

        }

        [TestMethod]
        public void TestGetEmail()
        {

        }

        [TestMethod]
        public void TestGetContactNumbers()
        {

        }

        [TestMethod]
        public void TestGetStringToByteArray()
        {

        }

        [TestMethod]
        public void TestGetByteArrayToString()
        {

        }

        [TestMethod]
        public void TestGenerateSalt()
        {

        }

        [TestMethod]
        public void TestHashPassword()
        {

        }

        [TestMethod]
        public void TestIsValidPassword()
        {

        }

        [TestMethod]
        public void TestGetPermits()
        {

        }

        [TestMethod]
        public void TestGetPermitNames()
        {

        }

        [TestMethod]
        public void TestGetGetPermitName()
        {

        }

        [TestMethod]
        public void TestGetUsers()
        {

        }

        [TestMethod]
        public void TestGetUser()
        {

        }

        [TestMethod]
        public void TestGetRegistartionsRequestUser()
        {

        }

        [TestMethod]
        public void TestGetDismissedUsers()
        {

        }

        [TestMethod]
        public void TestGetRoles()
        {

        }

        [TestMethod]
        public void TestGetRoleNames()
        {

        }

        [TestMethod]
        public void TestGetRoleName()
        {

        }

        [TestMethod]
        public void TestGetWorks()
        {

        }

        [TestMethod]
        public void TestGetWork()
        {

        }
    }
}