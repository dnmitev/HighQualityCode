namespace CalendarSystem.Parser
{
    using System;
    using CalendarSystem;

    public class CommandParser : ICommandParser
    {
        public CommandInfo Parse(string input)
        {
            int indexOfCommandEnd = input.IndexOf(' ');
            if (indexOfCommandEnd == -1)
            {
                throw new Exception(string.Format("Invalid command: {0}", input));
            }

            string commandName = input.Substring(0, indexOfCommandEnd);
            string commandArgs = input.Substring(indexOfCommandEnd + 1);

            var commandArguments = commandArgs.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                commandArgs = commandArguments[i];
                commandArguments[i] = commandArgs.Trim();
            }

            var command = new CommandInfo
            {
                Name = commandName,
                Params = commandArguments
            };

            return command;
        }
    }
}