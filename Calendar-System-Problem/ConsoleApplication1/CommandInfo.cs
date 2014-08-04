namespace CalendarSystem
{
    using System.Collections.Generic;

    public class CommandInfo
    {
        public string Name { get; set; }

        public IList<string> Params { get; set; }
    }
}