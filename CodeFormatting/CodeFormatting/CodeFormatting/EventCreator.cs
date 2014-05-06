namespace CodeFormatting
{
    using System;
    using System.Linq;
    using System.Text;

    public class EventCreator : IComparable
    {
        private readonly DateTime date;
        private readonly String title;
        private readonly String location;

        public EventCreator(DateTime date, String title, String location)
        {
            this.date = date;
            this.title = title;
            this.location = location;
        }

        public int CompareTo(object compareObj)
        {
            EventCreator other = compareObj as EventCreator;
            int byDate = this.date.CompareTo(other.date);
            int byTitle = this.title.CompareTo(other.title);

            int byLocation = this.location.CompareTo(other.location);
            if (byDate == 0)
            {
                if (byTitle == 0)
                {
                    return byLocation;
                }
                else
                {
                    return byTitle;
                }
            }
            else
            {
                return byDate;
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.Append(this.date.ToString("yyyy-MM-ddTHH:mm:ss"));
            result.AppendFormat(" | {0}", this.title);

            if (this.location != null && this.location != string.Empty)
            {
                result.AppendFormat(" | {0}", this.location);
            }

            return result.ToString();
        }
    }
}