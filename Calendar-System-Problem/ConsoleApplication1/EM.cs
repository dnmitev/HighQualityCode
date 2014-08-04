using System;
using System.Collections.Generic;
using System.Linq;
using CalendarSystem;

namespace CalendarSystem
{
    // TODO: Probably delete but check efficiency first
    public class EM : IEventsManager
    {
        private readonly List<EventEntry> list = new List<EventEntry>();

        public void AddEvent(EventEntry e)
        {
            this.list.Add(e);
        }

        public int DeleteEventsByTitle(string t)
        {
            return this.list.RemoveAll(
                e => e.Title.ToLowerInvariant() == t.ToLowerInvariant());
        }

        public IEnumerable<EventEntry> ListEvents(DateTime d, int c)
        {
            return (from e in this.list
                    where e.Date >= d
                    orderby e.Date, e.Title, e.Location
                    select e).Take(c);
        }
    }
}