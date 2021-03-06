using System;
using Xunit;
using PraksaFrontMVC;
using PraksaFrontMVC.Controllers;
using PraksaFrontMVC.Data;
using System.Threading.Tasks;

namespace MvcTest
{
    public class UnitTest1
    {
        readonly int fakeID = 66666;
        [Fact]
        public void GetAttendants()
        {
            
            var  list = Task.Run(() => AttendantData.GetAttendants(7)).Result;
            Assert.True(list.Count > 0);
        }

        [Fact]
        public void GetAttendantsWrongJobId()
        {

            var list = Task.Run(() => AttendantData.GetAttendants(fakeID)).Result;
            Assert.True(list.Count == 0);
        }

        [Fact]
        public void GetAttendant()
        {
            var result = AttendantData.GetAttendant(7,29);
            int expectedIdAttendance = 2;
            Assert.Equal(expectedIdAttendance, result.IdAttendance);


        }

        [Fact]
        public void TestGetAttendantFailedWrongJobId()
        {
            int expectedIDAttendance = 2;
            var result = AttendantData.GetAttendant(fakeID, 29);
            
            Assert.NotEqual(expectedIDAttendance, result.IdAttendance);
        }

        [Fact]
        public void TestGetAttendantFailedWrongUserId()
        {
            int expectedIdAttendance = 2;
            var result = AttendantData.GetAttendant(7, fakeID);
            Assert.NotEqual(expectedIdAttendance, result.IdAttendance);
        }

        [Fact]
        public void TestLoginIsSuccessful()
        {
            var result = Authentication.LogIn("user1@gmail.com", "useruser");
            Assert.NotEqual(0, result);
        }

        [Fact]
        public void TestLoginIsNotSuccessfulWrongUser()
        {
            var expectedresult = "wrong_user@gmail.com";
            var result = Authentication.LogIn(expectedresult, "useruser");
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestLoginIsNotSuccessfulWrongPassword()
        {
            var result = Authentication.LogIn("user@gmail.com", "wrong_password");
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestLoginIsNotSuccessfulWrongUserAndPassword()
        {
            var result = Authentication.LogIn("wrong_user@gmail.com", "wrong_password");
            Assert.Equal(0, result);
        }

        [Fact]
        public void TestGetPasswordSalt()
        {
            var ExpectedPasswordSalt = "60BCC43AF6549BE3E00BA05AA5AE7E6E";
            var result = Authentication.GetPasswordSalt("user1@gmail.com");
            Assert.Equal(ExpectedPasswordSalt, result);
        }

        [Fact]
        public void TestGetPasswordSaltWrongEmail()
        {
            var ExpectedPasswordSalt = "60BCC43AF6549BE3E00BA05AA5AE7E6E";
            var result = Authentication.GetPasswordSalt("FakeEmail@gmail.com");
            Assert.NotEqual(ExpectedPasswordSalt, result);
        }

        [Fact]
        public void TestGetPasswordSaltWrongPasswordSalt()
        {
            var ExpectedPasswordSalt = "60BCC43A54549BE3E00BA05AA5AE7E6E";
            var result = Authentication.GetPasswordSalt("user1@gmail.com");
            Assert.NotEqual(ExpectedPasswordSalt, result);
        }

        [Fact]
        public void TestGetContactEmail()
        {
            var list = Task.Run(() => ContactEmailData.GetContactEmails(29)).Result;
            Assert.True(list.Count > 0);

        }

        [Fact]
        public void TestGetEmail()
        {
            var list = Task.Run(() => ContactEmailData.GetEmail(29, 36)).Result;
            var expectedemail = "user1@gmail.com";
            Assert.Equal(expectedemail, list.Email);

        }

        [Fact]
        public void TestGetEmailFailedWrongUserId()
        {
            var list = Task.Run(() => ContactEmailData.GetEmail(fakeID, 36)).Result;
            var expectedemail = "user1@gmail.com";
            Assert.NotEqual(expectedemail, list.Email);

        }

        [Fact]
        public void TestGetEmailFailedWrongEmailId()
        {
            var list = Task.Run(() => ContactEmailData.GetEmail(29, fakeID)).Result;
            var expectedemail = "user1@gmail.com";
            Assert.NotEqual(expectedemail, list.Email);
        }

        [Fact]
        public void TestGetEmailFailedWrongUserIdWrongEmailId()
        {
            var list = Task.Run(() => ContactEmailData.GetEmail(fakeID, fakeID)).Result;
            var expectedemail = "user1@gmail.com";
            Assert.NotEqual(expectedemail, list.Email);

        }

        [Fact]
        public void TestGetContactNumbers()
        {
            var list = Task.Run(() => ContactNumberData.GetContactNumbers(29)).Result;
            Assert.True(list.Count > 0);
        }

        [Fact]
        public void TestGetContactNumbersFailed()
        {
            var list = Task.Run(() => ContactNumberData.GetContactNumbers(fakeID)).Result;
            Assert.True(list.Count == 0);
        }

        [Fact]
        public void TestGetUsers()
        {
            var list = Task.Run(() => PeopleData.GetUsers()).Result;
            Assert.True(list.Count > 0);
        }



        [Fact]
        public void TestGetUser()
        {
            var expecteduseradress = "?titno Podru?je, 1C";
            var list = Task.Run(() => PeopleData.GetUser(29)).Result;
            Assert.Equal(expecteduseradress, list.Address);
        }

        [Fact]
        public void TestGetUserFailed()
        {
            var expecteduseradress = "?titno Podru?je, 1C";
            var list = Task.Run(() => PeopleData.GetUser(fakeID)).Result;
            Assert.NotEqual(expecteduseradress, list.Address);

        }

        [Fact]
        public void TestGetDismissedUsers()
        {
            var list = Task.Run(() => PeopleData.GetDismissedUsers()).Result;
            Assert.True(list.Count > 0);
        }

        [Fact]
        public void TestGetUserId()
        {
            int ExpectedUserId = 29;
            var result = PeopleData.GetUserId("user1@gmail.com");
            Assert.Equal(ExpectedUserId, result);
        }

        [Fact]
        public void TestGetPermits()
        {
            var list = Task.Run(() => PermitData.GetPermits(29)).Result;
            Assert.True(list.Count > 0);
        }

        [Fact]
        public void TestGetPermitsFailed()
        {
            var list = Task.Run(() => PermitData.GetPermits(fakeID)).Result;
            Assert.True(list.Count == 0);
        }

        [Fact]
        public void TestGetPermitName()
        {
            var ExpectedPermitName = "Voza?ka Dozvola B Kategorije";
            var list = Task.Run(() => PermitNameData.GetPermitName(1)).Result;
            Assert.Equal(ExpectedPermitName, list.Name);
        }

        [Fact]
        public void TestGetPermitNameFailed()
        {
            var ExpectedPermitName = "Voza?ka Dozvola B Kategorije";
            var list = Task.Run(() => PermitNameData.GetPermitName(fakeID)).Result;
            Assert.NotEqual(ExpectedPermitName, list.Name);
        }

        [Fact]
        public void TestGetPermitNames()
        {
            var list = Task.Run(() => PermitNameData.GetPermitNames()).Result;
            Assert.True(list.Count > 0);
        }

        [Fact]
        public void TestGetRoles()
        {
            var list = Task.Run(() => RoleData.GetRoles(29)).Result;       
            Assert.True(list.Count > 0);
        }

        [Fact]
        public void TestGetRolesFailed()
        {
            var list = Task.Run(() => RoleData.GetRoles(fakeID)).Result;
            Assert.True(list.Count == 0);
        }

        [Fact]
        public void TestGetRoleNames()
        {
            var list = Task.Run(() => RoleNameData.GetRoleNames()).Result;
            Assert.True(list.Count > 0);
        }

        [Fact]
        public void TestGetRoleName()
        {
            var expectedrolename = "Admin";
            var result = Task.Run(() => RoleNameData.GetRoleName(1)).Result;
            Assert.Equal(expectedrolename, result.Name);
        }

        [Fact]
        public void TestGetRoleNameFailedWrongUserId()
        {
            var expectedrolename = "FakeRoleName";
            var result = Task.Run(() => RoleNameData.GetRoleName(fakeID)).Result;
            Assert.NotEqual(expectedrolename, result.Name);
        }

        [Fact]
        public void TestGetWorks()
        {
            var result = Task.Run(() => WorkData.GetWorks()).Result;
            Assert.True(result.Count > 0);
        }

        [Fact]
        public void TestGetWork()
        {
            var expectedworkname = "Nova";
            var result = Task.Run(() => WorkData.GetWork(15)).Result;
            Assert.Equal(result.Name, expectedworkname);
        }

        [Fact]
        public void TestGetWorkFailedWrongId()
        {
            var expectedworkname = "novaradnaakcija";
            var result = Task.Run(() => WorkData.GetWork(fakeID)).Result;
            Assert.NotEqual(result.Name, expectedworkname);
        }

        [Fact]
        public void TestGetDoneWorks()
        {
            var result = Task.Run(() => WorkData.GetDoneWorks()).Result;
            Assert.True(result.Count > 0);
        }


    }
}
