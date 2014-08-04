using System;
using System.Collections.Generic;

namespace CalendarSystem
{
    public interface IEventsManager
    {
        void AddEvent(EventEntry @event);

        int DeleteEventsByTitle(string eventTitle);

        IEnumerable<EventEntry> ListEvents(DateTime date, int count);
    }
}