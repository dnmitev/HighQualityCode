namespace CalendarSystem
{
    using System;

    public class EventEntry : IComparable<EventEntry>
    {
        private const int MaxTitleLength = 100;

        private readonly DateTime minDate = new DateTime(2000, 01, 01, 00, 00, 00);
        private readonly DateTime maxDate = new DateTime(2020, 01, 01, 00, 00, 00);

        private string title;
        private string location;
        private DateTime date;

        public DateTime Date
        {
            get
            {
                return this.date;
            }

            set
            {
                if (value < this.minDate || value > this.maxDate)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Date should be in the interval [{0}; {1}].", this.minDate, this.maxDate));
                }

                this.date = value;
            }
        }

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                if (value.Length < 0 || value.Length > MaxTitleLength)
                {
                    throw new ArgumentOutOfRangeException(string.Format("Title length should be in the interval [{0}; {1}].", 0, this.maxDate));
                }
                else if (value.IndexOf('|') > 0 || value.IndexOf("\n") > 0)
                {
                    throw new FormatException("Title contains invalid symbols.");
                }

                this.title = value;
            }
        }

        public string Location 
        {
            get
            {
                return this.location;
            }

            set
            {
                if (value.IndexOf('|') > 0 || value.IndexOf("\n") > 0)
                {
                    throw new FormatException("Title contains invalid symbols.");
                }

                this.location = value;
            }
        }

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