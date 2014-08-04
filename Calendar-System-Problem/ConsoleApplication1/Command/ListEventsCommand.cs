namespace CalendarSystem.Command
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using CalendarSystem.Printer;

    public class ListEventsCommand : CalendarSystemCommand
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private readonly CultureInfo provider = CultureInfo.InvariantCulture;

        public ListEventsCommand(IEventsManager manager, IPrinter printer)
            : base(manager, printer)
        {
        }

        public override void Execute(CommandInfo command)
        {
            var date = DateTime.ParseExact(command.Params[0], DateTimeFormat, this.provider, DateTimeStyles.AllowLeadingWhite);
            var count = int.Parse(command.Params[1]);
            var events = this.EventManager.ListEvents(date, count).ToList();
            var output = new StringBuilder();

            if (!events.Any())
            {
                this.Printer.Print("No events found");
            }

            foreach (var e in events)
            {
                output.AppendLine(e.ToString().Trim());
            }

            this.Printer.Print(output.ToString().Trim());
        }
    }
}