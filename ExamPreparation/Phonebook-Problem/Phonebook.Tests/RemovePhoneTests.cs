namespace Phonebook.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook.Repository;
    using System.Collections.Generic;

    [TestClass]
    public class RemovePhoneTests
    {
        private IDeletablePhonebookRepository data;

        [TestInitialize]
        public void CreateTestData()
        {
            this.data = new PhonebookRepository();
            this.data.AddPhone("Pesho", new List<string>() { "02/911 02 02", "0889 123 123" });
            this.data.AddPhone("Gosho", new List<string>() { "0878 514 415", "0789 825 655" });
            this.data.AddPhone("Maria", new List<string>() { "0800 20 400" });
        }

        [TestMethod]
        public void RemovePhoneShpuldRemoveGivenNumber()
        {
            this.data.Remove("0878 514 415");
            var result = this.data.ListEntries(0, 1)[0].PhoneNumbers.Count;

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void RemoveLastEntruPhoneShouldDeleteTheEntry()
        {
            // remove Maria's only number should delete her
            this.data.Remove("0800 20 400");

            // add Maria as new entry should return true
            var result = this.data.AddPhone("Maria", new List<string>() { });
            Assert.IsTrue(result);
        }
    }
}