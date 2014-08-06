namespace ComputerSystem.Utils
{
    using System;
    using System.Linq;
    using ComputerSystem.Contracts;

    public class CommandParser : ICommandParser
    {
        private const int DefaultCommandArgumentsCount = 2;

        public CommandInfo Parse(string commandLine)
        {
            var commandLineParams = commandLine.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (commandLineParams.Length != DefaultCommandArgumentsCount)
            {
                throw new ArgumentException("Invalid command arguments!");
            }

            var commandName = commandLineParams[0];
            var commandParams = int.Parse(commandLineParams[1]);

            var currentCommand = new CommandInfo
            {
                Name = commandName,
                Perameter = commandParams
            };

            return currentCommand;
        }
    }
}