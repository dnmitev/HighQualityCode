namespace Phonebook.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook.Repository;
    using System.Collections.Generic;

    [TestClass]
    public class ListEntriesTests
    {
        private IPhonebookRepository data;

        [TestInitialize]
        public void CreateTestData()
        {
            this.data = new PhonebookRepository();
            this.data.AddPhone("Pesho", new List<string>() { "02/911 02 02", "0889 123 123" });
            this.data.AddPhone("Gosho", new List<string>() { "0878 514 415", "0889 123 123" });
            this.data.AddPhone("Maria", new List<string>() { "0800 20 400" });
        }

        [TestMethod]
        public void ListEntriesShouldReturnAllEntries()
        {
            var result = this.data.ListEntries(0, 3);

            Assert.AreEqual(3, result.GetLength(0));
        }

        [TestMethod]
        public void ListEntriesShouldReturnAllEntriesSortedByName()
        {
            var result = this.data.ListEntries(0, 3);

            Assert.AreEqual("Gosho", result[0].Name);
            Assert.AreEqual("Pesho", result[result.GetLength(0) - 1].Name);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesOfNullShouldThrowArgumentOutOfRangeException()
        {
            IPhonebookRepository repo = new PhonebookRepository();
            repo.ListEntries(10, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ListEntriesOfInvalidParametersShouldThrowArgumentOutOfRangeException()
        {
            this.data.ListEntries(10, 10);
        }
    }
}