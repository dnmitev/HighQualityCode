namespace CalendarSystem
{
    using System;
    using System.Collections.Generic;
    
    public interface IEventsManager
    {
        void AddEvent(EventEntry @event);

        int DeleteEventsByTitle(string eventTitle);

        IEnumerable<EventEntry> ListEvents(DateTime date, int count);
    }
}