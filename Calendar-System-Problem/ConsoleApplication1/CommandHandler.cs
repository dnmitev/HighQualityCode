using System;
using System.Globalization;
using System.Linq;
using System.Text;

namespace CalendarSystem
{
    public class CommandHandler
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private readonly CultureInfo Provider = CultureInfo.InvariantCulture;

        public CommandHandler(IEventsManager eventManager)
        {
            this.EventsProcessor = eventManager;
        }

        public IEventsManager EventsProcessor { get; private set; }

        public string ProcessCommand(Command command)
        {
            // First command
            if ((command.Name == "AddEvent") && (command.Params.Length == 2))
            {
                var date = DateTime.ParseExact(command.Params[0], DateTimeFormat, Provider, DateTimeStyles.AllowLeadingWhite);
                var e = new EventEntry
                {
                    Date = date,
                    Title = command.Params[1],
                    Location = null,
                };

                this.EventsProcessor.AddEvent(e);

                return "Event added";
            }
            if ((command.Name == "AddEvent") && (command.Params.Length == 3))
            {
                var date = DateTime.ParseExact(command.Params[0], DateTimeFormat, Provider, DateTimeStyles.AllowLeadingWhite);
                var e = new EventEntry
                {
                    Date = date,
                    Title = command.Params[1],
                    Location = command.Params[2],
                };

                this.EventsProcessor.AddEvent(e);

                return "Event added";
            }
            // Second command
            if ((command.Name == "DeleteEvents") && (command.Params.Length == 1))
            {
                int c = this.EventsProcessor.DeleteEventsByTitle(command.Params[0]);

                if (c == 0)
                {
                    return "No events found";
                }

                return string.Format("{0} events deleted", c);
            }
            // Third command
            if ((command.Name == "ListEvents") && (command.Params.Length == 2))
            {
                var date = DateTime.ParseExact(command.Params[0], DateTimeFormat, Provider, DateTimeStyles.AllowLeadingWhite);
                var count = int.Parse(command.Params[1]);
                var events = this.EventsProcessor.ListEvents(date, count).ToList();
                var output = new StringBuilder();

                if (!events.Any())
                {
                    return "No events found";
                }

                foreach (var e in events)
                {
                    output.AppendLine(e.ToString().Trim());
                }

                return output.ToString().Trim();
            }
            else
            {
                throw new ArgumentException(string.Format("Invalid command: {0}", command.Name));
            }
        }
    }
}