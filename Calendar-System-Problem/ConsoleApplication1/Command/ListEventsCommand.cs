namespace CalendarSystem.Command
{
    using CalendarSystem.Printer;
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    public class ListEventsCommand : CalendarSystemCommand
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private readonly CultureInfo Provider = CultureInfo.InvariantCulture;

        public ListEventsCommand(IEventsManager manager, IPrinter printer) : base(manager, printer)
        {
        }

        public override void Execute(CommandInfo command)
        {
            var date = DateTime.ParseExact(command.Params[0], DateTimeFormat, this.Provider, DateTimeStyles.AllowLeadingWhite);
            var count = int.Parse(command.Params[1]);
            var events = this.EventManager.ListEvents(date, count).ToList();
            var output = new StringBuilder();

            if (!events.Any())
            {
                this.Printer.Print( "No events found");
            }

            foreach (var e in events)
            {
                output.AppendLine(e.ToString().Trim());
            }

            this.Printer.Print(output.ToString().Trim());
        }
    }
}