namespace CalendarSystem.Command
{
    using CalendarSystem.Printer;

    public abstract class CalendarSystemCommand : ICalendarSystemCommand
    {
        public CalendarSystemCommand(IEventsManager manager, IPrinter printer)
        {
            this.EventManager = manager;
            this.Printer = printer;
        }

        public IEventsManager EventManager { get; private set; }

        public IPrinter Printer { get; private set; }

        public abstract void Execute(CommandInfo command);
    }
}