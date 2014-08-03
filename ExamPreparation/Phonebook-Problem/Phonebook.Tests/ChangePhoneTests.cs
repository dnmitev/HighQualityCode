namespace Phonebook.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
using Phonebook.Repository;
    using System.Collections.Generic;
    
    [TestClass]
    public class ChangePhoneTests
    {
        private IPhonebookRepository data;

        [TestInitialize]
        public void CreateTestData()
        {
            this.data = new PhonebookRepository();
            this.data.AddPhone("Pesho", new List<string>(){ "02/911 02 02", "0889 123 123" });
            this.data.AddPhone("Gosho", new List<string>() { "0878 514 415", "0889 123 123" });
            this.data.AddPhone("Maria", new List<string>() { "0800 20 400" });
        }

        [TestMethod]
        public void ChangeExistingNumberShouldReturn1()
        {
            int result = this.data.ChangePhone("02/911 02 02", "0888 88 88 88");

            Assert.AreEqual(1,result);
        }

        [TestMethod]
        public void Change2ExistingNumberShouldReturn2()
        {
            int result = this.data.ChangePhone("0889 123 123", "911");

            Assert.AreEqual(2, result);
        }

        [TestMethod]
        public void ChangeNonExistingNumberShouldReturn0()
        {
            int result = this.data.ChangePhone("112", "911");

            Assert.AreEqual(0, result);
        }
    }
}