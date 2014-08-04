namespace CalendarSystem.Factory
{
    using System;
    using System.Linq;

    using CalendarSystem.Command;
    using CalendarSystem.Printer;

    public class CommandFactory : ICommandFactory
    {
        private readonly IEventsManager eventManager;
        private readonly IPrinter printer;

        private ICalendarSystemCommand addEventCommand;
        private ICalendarSystemCommand deleteEventsCommand;
        private ICalendarSystemCommand listEventsCommand;

        public CommandFactory(IEventsManager manager, IPrinter printer)
        {
            this.eventManager = manager;
            this.printer = printer;
        }

        public ICalendarSystemCommand CreateCommand(CommandInfo cmdInfo)
        {
            ICalendarSystemCommand command;

            if (cmdInfo.Name == "AddEvent" && (cmdInfo.Params.Count() == 2 || cmdInfo.Params.Count() == 3))
            {
                if (this.addEventCommand == null)
                {
                    this.addEventCommand = new AddEventCommand(this.eventManager, this.printer);
                }

                command = this.addEventCommand;
            }
            else if (cmdInfo.Name == "DeleteEvents" && cmdInfo.Params.Count() == 1)
            {
                if (this.deleteEventsCommand == null)
                {
                    this.deleteEventsCommand = new DeleteEventsCommand(this.eventManager, this.printer);
                }

                command = this.deleteEventsCommand;
            }
            else if (cmdInfo.Name == "ListEvents" && cmdInfo.Params.Count() == 2)
            {
                if (this.listEventsCommand == null)
                {
                    this.listEventsCommand = new ListEventsCommand(this.eventManager, this.printer);
                }

                command = this.listEventsCommand;
            }
            else
            {
                throw new FormatException("Invalid command format.");
            }

            return command;
        }
    }
}