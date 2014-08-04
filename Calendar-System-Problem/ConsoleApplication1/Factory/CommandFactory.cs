namespace CalendarSystem.Factory
{
    using CalendarSystem.Command;
    using CalendarSystem.Printer;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class CommandFactory : ICommandFactory
    {
        private IEventsManager eventManager;
        private IPrinter printer;

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
                if (addEventCommand == null)
                {
                    addEventCommand = new AddEventCommand(this.eventManager, this.printer);
                }

                command = addEventCommand;
            }
            else if (cmdInfo.Name == "DeleteEvents" && cmdInfo.Params.Count() == 1)
            {
                if (deleteEventsCommand == null)
                {
                    deleteEventsCommand = new DeleteEventsCommand(this.eventManager, this.printer);
                }

                command = deleteEventsCommand;
            }
            else if (cmdInfo.Name == "ListEvents" && cmdInfo.Params.Count() == 2)
            {
                if (listEventsCommand == null)
                {
                    listEventsCommand = new ListEventsCommand(this.eventManager, this.printer);
                }

                command = listEventsCommand;
            }
            else
            {
                throw new FormatException("Invalid command format.");
            }

            return command;
        }
    }
}