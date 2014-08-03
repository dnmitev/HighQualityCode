namespace Phonebook.Parser
{
    using System;

    public class CommandParser : ICommandParser
    {
        public CommandInfo Parse(string text)
        {
            int indexOfOpeningBracket = text.IndexOf('(');

            if (indexOfOpeningBracket == -1)
            {
                throw new FormatException("Invalid command format.There is no opening bracket");
            }

            string commandName = text.Substring(0, indexOfOpeningBracket);

            if (!text.EndsWith(")"))
            {
                throw new FormatException("Invalid command format.There is no closing bracket");
            }

            string listOfStringArgs = text.Substring(indexOfOpeningBracket + 1, text.Length - indexOfOpeningBracket - 2);
            string[] arguments = listOfStringArgs.Split(',');

            for (int j = 0; j < arguments.Length; j++)
            {
                arguments[j] = arguments[j].Trim();
            }

            var commandInfo = new CommandInfo
            {
                CommandName = commandName,
                Arguments = arguments
            };

            return commandInfo;
        }
    }
}