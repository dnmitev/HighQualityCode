﻿namespace CalendarSystem.Command
{
    using System;
    using System.Globalization;

    using CalendarSystem.Printer;

    public class AddEventCommand : CalendarSystemCommand
    {
        private const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss";
        private readonly CultureInfo provider = CultureInfo.InvariantCulture;

        public AddEventCommand(IEventsManager manager, IPrinter printer) : base(manager, printer)
        {
        }

        public override void Execute(CommandInfo command)
        {
            if (command.Params.Count == 2)
            {
                var date = DateTime.ParseExact(command.Params[0], DateTimeFormat, this.provider, DateTimeStyles.AllowLeadingWhite);
                var @event = new EventEntry
                {
                    Date = date,
                    Title = command.Params[1],
                    Location = null,
                };

                this.EventManager.AddEvent(@event);
                this.Printer.Print("Event added");
            }
            else if (command.Params.Count == 3)
            {
                var date = DateTime.ParseExact(command.Params[0], DateTimeFormat, this.provider, DateTimeStyles.AllowLeadingWhite);
                var @event = new EventEntry
                {
                    Date = date,
                    Title = command.Params[1],
                    Location = command.Params[2],
                };

                this.EventManager.AddEvent(@event);
                this.Printer.Print("Event added");
            }
        }
    }
}