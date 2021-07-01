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
            var result = Authentication.LogIn("user1@gmail.com", "useruser");
            Assert.AreNotEqual(0, result);
        }

        [TestMethod]
        public void TestLoginIsNotSuccessfulWrongUser()
        {
            var expectedresult= "wrong_user@gmail.com";
            var result = Authentication.LogIn(expectedresult , "useruser");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestLoginIsNotSuccessfulWrongPassword()
        {
            var result = Authentication.LogIn("user@gmail.com", "wrong_password");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestLoginIsNotSuccessfulWrongUserAndPassword()
        {
            var result = Authentication.LogIn("wrong_user@gmail.com", "wrong_password");
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void TestGetPasswordSalt()
        {
            var ExpectedPasswordSalt =  "60BCC43AF6549BE3E00BA05AA5AE7E6E";
            var result = Authentication.GetPasswordSalt("user1@gmail.com");
            Assert.AreEqual(ExpectedPasswordSalt, result);
        }

        [TestMethod]
        public void TestGetPasswordSaltWrongEmail()
        {
            var ExpectedPasswordSalt = "60BCC43AF6549BE3E00BA05AA5AE7E6E";
            var result = Authentication.GetPasswordSalt("FakeEmail@gmail.com");
            Assert.AreNotEqual(ExpectedPasswordSalt, result);
        }

        [TestMethod]
        public void TestGetAttendants()
        {
            var result = Attendant.GetAttendants(7);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetAttendantsFailed()
        {
            var result = Attendant.GetAttendants( fakeID);
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void TestGetAttendant()
        {
            int expectedIdAttendance = 2;
            var result = Attendant.GetAttendant( 7, 29);
            Assert.AreEqual(expectedIdAttendance, result.IdAttendance);
        }

        [TestMethod]
        public void TestGetAttendantFailedWrongJobId()
        {
            int expectedIDAttendance = 2;
            var result = Attendant.GetAttendant(fakeID, 29);
            Assert.AreNotEqual(expectedIDAttendance, result.IdAttendance);
        }

        [TestMethod]
        public void TestGetAttendantFailedWrongUserId()
        {
            int expectedIdAttendance = 2;
            var result = Attendant.GetAttendant( 7, fakeID);
            Assert.AreNotEqual(expectedIdAttendance, result.IdAttendance);
        }

        //[TestMethod]
        //public void TestGetAttendantId()
        //{
        //    int expectedIdAttendance = 2;
        //    var result = Attendant.GetAttendantId(connectionString, 7, 29);
        //    Assert.AreEqual(expectedIdAttendance, result.IdAttendance);
        //}

        //[TestMethod]
        //public void TestGetAttendantIdWrongJobId()
        //{
        //    int expectedIdAttendance = 2;
        //    var result = Attendant.GetAttendantId(connectionString, fakeID, 29);
        //    Assert.AreEqual(expectedIdAttendance, result.IdAttendance);
        //}

        //[TestMethod]
        //public void TestGetAttendantIdWrongUserId()
        //{
        //    int expectedIdAttendance = 2;
        //    var result = Attendant.GetAttendantId(connectionString, 7, fakeID);
        //    Assert.AreEqual(expectedIdAttendance, result.IdAttendance);
        //}



        [TestMethod]
        public void TestGetContactEmail()
        {
            var result = ContactEmail.GetContactEmails( 29);
            Assert.IsTrue(result.Count > 0);

        }

        [TestMethod]
        public void TestGetContactEmailFailed()
        {
            var result = ContactEmail.GetContactEmails( fakeID);
            Assert.IsTrue(result.Count == 0);

        }

        [TestMethod]
        public void TestGetEmail()
        {
            var result = ContactEmail.GetEmail( 29 , 36);
            var expectedemail = "user1@gmail.com";
            Assert.AreEqual(expectedemail, result.Email);
        }

        [TestMethod]
        public void TestGetEmailFailedWrongUserId()
        {
            var result = ContactEmail.GetEmail( fakeID, 36);
            var expectedemail = "user1@gmail.com";
            Assert.AreNotEqual(expectedemail, result.Email);
        }

        [TestMethod]
        public void TestGetEmailFailedWrongEmailId()
        {
            var result = ContactEmail.GetEmail( 36, fakeID);
            var expectedemail = "user1@gmail.com";
            Assert.AreNotEqual(expectedemail, result.Email);
        }

        [TestMethod]
        public void TestGetContactNumbers()
        {
            var result = ContactNumber.GetContactNumbers( 29);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetContactNumbersFailed()
        {
            var result = ContactNumber.GetContactNumbers( fakeID);
            Assert.IsTrue(result.Count == 0);
        }



        [TestMethod]
        public void TestGetPermits()
        {
            var result = Permit.GetPermits( 29);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetPermitsFailed()
        {
            var result = Permit.GetPermits( fakeID);
            Assert.IsTrue(result.Count==0);
        }

        [TestMethod]
        public void TestGetPermitNames()
        {
            var result = PermitName.GetPermitNames();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetPermitName()
        {
            var ExpectedPermitName = "Vozačka Dozvola B Kategorije";
            var result = PermitName.GetPermitName(1);
            Assert.AreEqual(ExpectedPermitName, result.Name);
        }

        [TestMethod]
        public void TestGetPermitNameFail()
        {
            var ExpectedPermitName = "Vozačka Dozvola B Kategorije";
            var result = PermitName.GetPermitName(fakeID);
            Assert.AreNotEqual(ExpectedPermitName, result.Name);
        }





        [TestMethod]
        public void TestGetUsers()
        {
            var result = Person.GetUsers();
            Assert.IsTrue(result.Count > 0);
        }

        

        [TestMethod]
        public void TestGetUser()
        {
            var expecteduseradress = "Štitno Područje, 1B";
            var result = Person.GetUser( 29);
            Assert.AreEqual(expecteduseradress, result.Address);
        }

        [TestMethod]
        public void TestGetUserFailed()
        {
            var result = Person.GetUser( fakeID);
            Assert.AreEqual(0,result.Id);

        }

        [TestMethod]
        public void TestGetRegistartionsRequestUser()
        {
            var result = Person.GetRegistartionsRequestUser();
            Assert.IsTrue(result.Count > 0);
        }

        public void TestGetRegistartionsRequestUserFailed()
        {
            var result = Person.GetRegistartionsRequestUser();
            Assert.IsTrue(result.Count == 0);
        }

        [TestMethod]
        public void TestGetDismissedUsers()
        {
            var result = Person.GetDismissedUsers();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetUserId()
        {
            int ExpectedUserId = 29; 
            var result = Person.GetUserId("user1@gmail.com");
            Assert.AreEqual(ExpectedUserId, result);
        }

        [TestMethod]
        public void TestGetRoles()
        {
            var result = Role.GetRoles(29);
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetRolesFailed()
        {
            var result = Role.GetRoles( fakeID);
            Assert.IsTrue(result.Count == 0);
        }



        [TestMethod]
        public void TestGetRoleNames()
        {
            var result = RoleName.GetRoleNames();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetRoleName()
        {
            var expectedrolename = "Admin";
            var result = RoleName.GetRoleName(1);
            Assert.AreEqual(expectedrolename, result.Name);
        }

        public void TestGetRoleNameFailed()
        {
            var expectedrolename = "FakeRoleName";
            var result = RoleName.GetRoleName( 1);
            Assert.AreNotEqual(expectedrolename, result.Name);
        }

        [TestMethod]
        public void TestGetWorks()
        {
            var result = Work.GetWorks();
            Assert.IsTrue(result.Count > 0);
        }

        [TestMethod]
        public void TestGetWork()
        {
            var expectedworkname = "novaradnaakcija";
            var result = Work.GetWork(15);
            Assert.AreEqual(result.Name, expectedworkname);
        }

        [TestMethod]
        public void TestGetWorkFailed()
        {
            var expectedworkname = "novaradnaakcija";
            var result = Work.GetWork( fakeID);
            Assert.AreNotEqual(result.Name, expectedworkname);
        }

        [TestMethod]
        public void TestGetDoneWorks()
        {
            var result = Work.GetDoneWorks();
            Assert.IsTrue(result.Count > 0);
        }

       
    }
}