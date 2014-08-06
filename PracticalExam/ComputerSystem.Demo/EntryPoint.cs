namespace ComputerSystem.Demo
{
    using System;
    using System.Linq;
    using ComputerSystem;
    using ComputerSystem.Contracts;
    using ComputerSystem.Utils;

    public class EntryPoint
    {
        private static void Main()
        {
            IAbstractComputerFactory manufacturer;
            ICommandInfo commandInfo;

            ICommandParser commandParser = new CommandParser();
            ISimpleComputerFactory factory = new SimpleComputerFactory();

            var manufacturerString = Console.ReadLine();
            manufacturer = factory.CreateManufacturer(manufacturerString);

            ICommandExecutor commandExecutor = new CommandExecutor(manufacturer);

            while (true)
            {
                var commandLine = Console.ReadLine().ToLowerInvariant();
                if (commandLine.StartsWith("exit") || commandLine == null)
                {
                    break;
                }

                commandInfo = commandParser.Parse(commandLine);

                commandExecutor.Execute(commandInfo);
            }
        }
    }
}