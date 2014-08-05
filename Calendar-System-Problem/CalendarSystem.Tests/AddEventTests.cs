namespace CalendarSystem.Tests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using CalendarSystem.Command;
    using System.Collections.Generic;
    using System.Linq;

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

        [TestMethod]
        public void AddSameEntrySeveralTimesShouldReturnSameCountAsAdded()
        {
            this.manager.AddEvent(this.@event);
            this.manager.AddEvent(this.@event);
            this.manager.AddEvent(this.@event);
            this.manager.AddEvent(this.@event);

            var result = this.manager.ListEvents(@event.Date, 10).ToList();

            Assert.AreEqual(4, result.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void AddSEntryWithInvalidTitleLengthShouldThrowException()
        {
            this.manager.AddEvent(new EventEntry
            {
                Date = new DateTime(2014, 08, 06, 16, 00, 00),
                Title = new string('D', 201)
            });
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AddSEntryWithForbiddenSymbolInTitleLengthShouldThrowException()
        {
            this.manager.AddEvent(new EventEntry
            {
                Date = new DateTime(2014, 08, 06, 16, 00, 00),
                Title = "Mn|typo"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AddSEntryWithNewLineSymbollInTitleLengthShouldThrowException()
        {
            this.manager.AddEvent(new EventEntry
            {
                Date = new DateTime(2014, 08, 06, 16, 00, 00),
                Title = "Mn\ntypo"
            });
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void AddSEntryWithInvalidSymbolInLocationPropertyShouldThrowException()
        {
            this.manager.AddEvent(new EventEntry
            {
                Date = new DateTime(2014, 08, 06, 16, 00, 00),
                Title = "Shit",
                Location = "nasam|natam"
            });
        }
    }
}