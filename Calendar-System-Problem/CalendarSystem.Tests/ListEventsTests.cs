using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class ListEventsTests
    {
        IEventsManager manager;

        [TestInitialize]
        public void GetInstances()
        {
            this.manager = new EventsManager();
            this.manager.AddEvent(new EventEntry
            {
                Date = new DateTime(2014, 08, 06, 16, 00, 00),
                Title = "Practical Exam",
                Location = "Telerik Academy"
            });

            this.manager.AddEvent(new EventEntry
            {
                Date = new DateTime(2014, 08, 08, 20, 00, 00),
                Title = "Partyyy",
                Location = "club 35"
            });

            this.manager.AddEvent(new EventEntry
            {
                Date = new DateTime(2014, 08, 06, 23, 30, 00),
                Title = "Partyyy",
                Location = "Fantastico"
            });

            this.manager.AddEvent(new EventEntry
            {
                Date = new DateTime(2014, 08, 14, 16, 00, 00),
                Title = "Blacksea",
            });

            this.manager.AddEvent(new EventEntry
            {
                Date = new DateTime(2014, 08, 06, 23, 30, 00),
                Title = "Partyyy",
                Location = "Asenovgrad"
            });
        }

        [TestMethod]
        public void ListEntriesShouldReturnAllEntriesAsCollection()
        {
            var result = this.manager.ListEvents(new DateTime(2014, 08, 06, 00, 00, 00), 4).ToList();

            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        public void ListEntriesFromNonExistingDateShouldReturnEmptyCollection()
        {
            var result = this.manager.ListEvents(new DateTime(2014, 09, 06, 00, 00, 00), 4).ToList();

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ListEntriesShouldReturnSortedByDateCollection()
        {
            var result = this.manager.ListEvents(new DateTime(2014, 08, 06, 00, 00, 00), 4).ToList();

            var isSorted = true;

            for (int i = 1; i < result.Count; i++)
            {
                if (result[i-1].Date > result[i].Date)
                {
                    isSorted = false;
                }
            }

            Assert.IsTrue(isSorted);
        }
    }
}
