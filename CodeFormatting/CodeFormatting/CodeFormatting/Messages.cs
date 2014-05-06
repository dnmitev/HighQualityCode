namespace CodeFormatting
{
    using System;
    using System.Linq;
    using System.Text;

    public static class Messages
    {
        public static StringBuilder output = new StringBuilder();

        public static void EventAdded()
        {
            output.AppendLine("Event added");
        }

        public static void EventDeleted(int targetEvent)
        {
            if (targetEvent == 0)
            {
                NoEventsFound();
            }
            else
            {
                output.AppendLine(string.Format("{0} events deleted", targetEvent));
            }
        }

        public static void NoEventsFound()
        {
            output.AppendLine("No events found");
        }

        public static void PrintEvent(EventCreator eventToPrint)
        {
            if (eventToPrint != null)
            {
                output.AppendLine(eventToPrint.ToString());
            }
        }
    }
}