namespace CalendarSystem.Command
{
    using System;

    using CalendarSystem.Printer;

    public class DeleteEventsCommand : CalendarSystemCommand
    {
        public DeleteEventsCommand(IEventsManager manager, IPrinter printer)
            : base(manager, printer)
        {
        }

        public override void Execute(CommandInfo command)
        {
            int count = this.EventManager.DeleteEventsByTitle(command.Params[0]);

            if (count == 0)
            {
                this.Printer.Print("No events found");
            }

            this.Printer.Print(string.Format("{0} events deleted", count));
        }
    }
}