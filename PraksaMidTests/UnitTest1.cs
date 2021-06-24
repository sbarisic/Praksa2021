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
        readonly String connectionString = "Data Source=167.86.127.239;Initial Catalog=Praksa2021;User ID=SerengetiUser;Password=Serengeti12345678910";
        readonly int fakeID = 66666;

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
            var result = Attendant.GetAttendants(connectionString, fakeID);
            Assert.IsTrue(result.Count == 0);
        }

       

        [TestMethod]
        public void TestGetContactEmail()
        {
            var result = ContactEmail.GetContactEmails(connectionString, 29);
            Assert.IsTrue(result.Count > 0);

        }

        [TestMethod]
        public void TestGetContactEmailFailed()
        {
            var result = ContactEmail.GetContactEmails(connectionString, fakeID);
            Assert.IsTrue(result.Count == 0);

        }

        [TestMethod]
        public void TestGetEmail()
        {
            var result = ContactEmail.GetEmail(connectionString, 29 , 36);
            var expectedemail = "user1@gmail.com";
            Assert.AreEqual(expectedemail, result.Email);
        }

        [TestMethod]
        public void TestGetContactNumbers()
        {
            var result = ContactNumber.GetContactNumbers(connectionString, 29);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetContactNumbersFailed()
        {
            var result = ContactNumber.GetContactNumbers(connectionString, fakeID);
            Assert.IsTrue(result.Count == 0);
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
            var result = Permit.GetPermits(connectionString, fakeID);
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
            var expecteduseradress = "Štitno Područje, 1B";
            var result = Person.GetUser(connectionString, 29);
            Assert.AreEqual(expecteduseradress, result.Address);

        }

        [TestMethod]
        public void TestGetUserFailed()
        {
            var expecteduseradress = "lažna adresa";
            var result = Person.GetUser(connectionString, 29);
            Assert.AreNotEqual(expecteduseradress, result.Address);

        }

        [TestMethod]
        public void TestGetRegistartionsRequestUser()
        {
            var result = Person.GetRegistartionsRequestUser(connectionString);
            Assert.IsTrue(result.Count > 0);
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
        public void TestGetRolesFailed()
        {
            var result = Role.GetRoles(connectionString, fakeID);
            Assert.IsTrue(result.Count == 0);
        }



        [TestMethod]
        public void TestGetRoleNames()
        {
            var result = RoleName.GetRoleNames(connectionString);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetRoleName()
        {
            var expectedrolename = "Admin";
            var result = RoleName.GetRoleName(connectionString,1);
            Assert.AreEqual(expectedrolename, result.Name);


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
            var expectedworkname = "Kupanje u bazenu";
            var result = Work.GetWork(connectionString, 7);
            Assert.AreEqual(result.Name, expectedworkname);
        }
    }
}