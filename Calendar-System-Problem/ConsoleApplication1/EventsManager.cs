namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Wintellect.PowerCollections;

    public class EventsManager : IEventsManager
    {
        private readonly MultiDictionary<string, EventEntry> eventsCollection = new MultiDictionary<string, EventEntry>(true);
        private readonly OrderedMultiDictionary<DateTime, EventEntry> orderedEventsCollection = new OrderedMultiDictionary<DateTime, EventEntry>(true);

        public void AddEvent(EventEntry @event)
        {
            string eventTitleLowerCase = @event.Title.ToLowerInvariant().Trim();
            this.eventsCollection.Add(eventTitleLowerCase, @event);
            this.orderedEventsCollection.Add(@event.Date, @event);
        }

        public int DeleteEventsByTitle(string eventTitle)
        {
            string invariantTitle = eventTitle.ToLowerInvariant();
            var eventToDelete = this.eventsCollection[invariantTitle];
            int countOfEvents = eventToDelete.Count;

            foreach (var e in eventToDelete)
            {
                this.orderedEventsCollection.Remove(e.Date, e);
            }

            this.eventsCollection.Remove(invariantTitle);

            return countOfEvents;
        }

        public IEnumerable<EventEntry> ListEvents(DateTime date, int count)
        {
            var data =
                    from e in this.orderedEventsCollection.RangeFrom(date, true).Values
                    select e;

            var events = data.Take(count);
            return events;
        }
    }
}