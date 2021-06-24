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
            var expectedresult= "wrong_user@gmail.com";
            var result = Authentication.LogIn(connectionString,expectedresult , "useruser");
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
            var result = ContactNumber.GetContactNumbers(connectionString, 29);
            Assert.IsTrue(result.Count > 0);
        }

        

        [TestMethod]
        public void TestGetPermits()
        {
            var result = Permit.GetPermits(connectionString, 29);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetPermitsFailed()
        {
            var result = Permit.GetPermits(connectionString, 6666);
            Assert.IsTrue(result.Count==0);
        }

       

        [TestMethod]
        public void TestGetUsers()
        {
            var result = Person.GetUsers(connectionString);
            Assert.IsTrue(result.Count > 0);
        }
      
        [TestMethod]
        public void TestGetUser()
        {
            var model = new ContactEmailModel();
            model.Email = "user1@gmail.com";

        }

        [TestMethod]
        public void TestGetRegistartionsRequestUser()
        {

        }

        [TestMethod]
        public void TestGetDismissedUsers()
        {
            var result = Person.GetDismissedUsers(connectionString);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetRoles()
        {
            var result = Role.GetRoles(connectionString,29);
            Assert.IsTrue(result.Count > 0);
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
            var result = Work.GetWorks(connectionString);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetWork()
        {
            
        }
    }
}