namespace CalendarSystem.Command
{
    using CalendarSystem.Printer;

    public interface ICalendarSystemCommand
    {
        IEventsManager EventManager { get; }

        IPrinter Printer { get; }

        void Execute(CommandInfo command);
    }
}