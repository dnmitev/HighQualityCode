using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class DeleteEventsTests
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
        }

        [TestMethod]
        public void DeleteNonExistingEventShouldReturn0()
        {
            var result = this.manager.DeleteEventsByTitle("kurti");

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void DeleteExistingTitleShouldReturn1()
        {
            var result = this.manager.DeleteEventsByTitle("Blacksea");

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void DeleteTwiceAddedEventTitleShouldReturn2()
        {
            var result = this.manager.DeleteEventsByTitle("Partyyy");

            Assert.AreEqual(2, result);
        }
    }
}