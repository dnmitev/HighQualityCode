namespace CalendarSystem.Factory
{
    using CalendarSystem.Command;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface ICommandFactory
    {
        ICalendarSystemCommand CreateCommand(CommandInfo cmdInfo);
    }
}