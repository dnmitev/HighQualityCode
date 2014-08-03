namespace Phonebook.Parser
{
    using System.Collections.Generic;

    public class CommandInfo
    {
        public string CommandName { get; set; }

        public IEnumerable<string> Arguments { get; set; }
    }
}