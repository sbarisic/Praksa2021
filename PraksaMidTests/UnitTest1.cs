using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using PraksaMid;
using PraksaMid.Model;

namespace PraksaMidTests
{
    [TestClass]
    public class UnitTest1
    {
        var database;

        [TestInitialize]
        public void Setup()
        {
            database = database();
        }

        [TestCleanup]
        public void Teardown()
        {
            database = null;
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
    }
}
