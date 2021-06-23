using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PraksaMid;
using PraksaMid.Model;
using System.Configuration;
using PraksaFront;

namespace PraksaMidTests
{
    [TestClass]
    public class UnitTest
    {
        String connectionString = "Data Source=167.86.127.239;Initial Catalog=Praksa2021;User ID=SerengetiUser;Password=Serengeti12345678910";

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
            var result = Authentication.LogIn(connectionString, "user1@gmail.com", "useruser");
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestLoginIsNotSuccessfulWrongUser()
        {
            var result = Authentication.LogIn(connectionString, "wrong_user@gmail.com", "useruser");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestLoginIsNotSuccessfulWrongPassword()
        {
            var result = Authentication.LogIn(connectionString, "user@gmail.com", "wrong_password");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestGetAttendants()
        {
            var result = Attendant.GetAttendants(connectionString, 7);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetAttendantsFailed()
        {
            var result = Attendant.GetAttendants(connectionString, 999);
            Assert.AreEqual(0,result);
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