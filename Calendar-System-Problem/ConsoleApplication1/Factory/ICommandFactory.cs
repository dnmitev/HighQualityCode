namespace CalendarSystem.Factory
{
    using CalendarSystem.Command;

    public interface ICommandFactory
    {
        ICalendarSystemCommand CreateCommand(CommandInfo cmdInfo);
    }
}