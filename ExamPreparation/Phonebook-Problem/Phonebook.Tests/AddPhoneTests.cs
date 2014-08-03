namespace Phonebook.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Phonebook.Repository;
    using System.Collections.Generic;

    [TestClass]
    public class AddPhoneTests
    {
        [TestMethod]
        public void AddNonExistignPhoneEntryShouldReturnTrue()
        {
            IPhonebookRepository data = new PhonebookRepository();

            var result = data.AddPhone("Pesho", new List<string>() { });

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AddExistignPhoneEntryShouldReturnFalse()
        {
            IPhonebookRepository data = new PhonebookRepository();

            data.AddPhone("Pesho", new List<string>() { });
            var result = data.AddPhone("Pesho", new List<string>() { });

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void AddDuplicatedPhonesShouldMerge()
        {
            IPhonebookRepository data = new PhonebookRepository();

            data.AddPhone("Pesho", new List<string>() { "02/911 02 02", "0888 88 88 88" });
            var result = data.AddPhone("Pesho", new List<string>() { "02/911 02 02" });

            Assert.AreEqual(2, data.ListEntries(0, 1)[0].PhoneNumbers.Count);
        }
        
        [TestMethod]
        public void AddNewPhonesShouldExtendCurrentEntryData()
        {
            IPhonebookRepository data = new PhonebookRepository();

            data.AddPhone("Pesho", new List<string>() { "02/911 02 02", "0888 88 88 88" });
            data.AddPhone("Pesho", new List<string>() { "0899 981 891" });

            Assert.AreEqual(3, data.ListEntries(0, 1)[0].PhoneNumbers.Count);
        }

        [TestMethod]
        public void AddEntryWithDifferentNameCasingShouldMergeEntries()
        {
            IPhonebookRepository data = new PhonebookRepository();

            data.AddPhone("Pesho", new List<string>() { "02/911 02 02" });
            data.AddPhone("peSHo", new List<string>() { "0899 981 891" });

            Assert.AreEqual("Pesho", data.ListEntries(0, 1)[0].Name);
        }
    }
}