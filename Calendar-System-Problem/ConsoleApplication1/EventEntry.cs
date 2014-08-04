namespace CalendarSystem
{
    using System;
    
    public class EventEntry : IComparable<EventEntry>
    {
        public DateTime Date { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public override string ToString()
        {
            string eventStringFormat = "{0:yyyy-MM-ddTHH:mm:ss} | {1}";
            if (this.Location != null)
            {
                eventStringFormat += " | {2}";
            }

            string eventAsString = string.Format(eventStringFormat, this.Date, this.Title, this.Location);
            return eventAsString;
        }

        public int CompareTo(EventEntry otherEvent)
        {
            int res = DateTime.Compare(this.Date, otherEvent.Date);
            foreach (char c in this.Title)
            {
                if (res == 0)
                {
                    res = string.Compare(this.Title, otherEvent.Title, StringComparison.OrdinalIgnoreCase);
                }

                if (res == 0)
                {
                    res = string.Compare(this.Location, otherEvent.Location, StringComparison.OrdinalIgnoreCase);
                }
            }

            return res;
        }
    }
}