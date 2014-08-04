namespace CalendarSystem
{
    using System;
    
    public struct Command
    {
        public string Name { get; set; }

        public string[] Params { get; set; }

        public static Command Parse(string commandLine)
        {
            int indexOfCommandEnd = commandLine.IndexOf(' ');
            if (indexOfCommandEnd == -1)
            {
                throw new Exception(string.Format("Invalid command: {0}", commandLine));
            }

            string commandName = commandLine.Substring(0, indexOfCommandEnd);
            string commandArgs = commandLine.Substring(indexOfCommandEnd + 1);

            var commandArguments = commandArgs.Split('|');
            for (int i = 0; i < commandArguments.Length; i++)
            {
                commandArgs = commandArguments[i];
                commandArguments[i] = commandArgs.Trim();
            }

            var command = new Command { Name = commandName, Params = commandArguments };

            return command;
        }
    }
}