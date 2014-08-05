using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalendarSystem.Command;
using System.Collections.Generic;
using System.Linq;

namespace CalendarSystem.Tests
{
    [TestClass]
    public class AddEventTests
    {
        private EventEntry @event;
        private IEventsManager manager;

        [TestInitialize]
        public void GetInstantiated()
        {
            this.manager = new EventsManager();
            this.@event = new EventEntry
                            {
                                Date = new DateTime(2014, 08, 06, 16, 00, 00),
                                Title = "HQPC Practical Exam",
                                Location = "Telerik Academy"
                            };
        }

        [TestMethod]
        public void AddValidEntryShouldWork()
        {
            this.manager.AddEvent(this.@event);

            var result = this.manager.ListEvents(@event.Date, 1).ToList();

            Assert.AreEqual(1, result.Count);
        }
    }
}
