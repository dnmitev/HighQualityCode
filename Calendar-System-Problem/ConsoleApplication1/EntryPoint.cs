namespace CalendarSystem
{
    using CalendarSystem.Factory;
    using CalendarSystem.Parser;
    using CalendarSystem.Printer;
    using System;

    public class EntryPoint
    {
        public static void Main()
        {
            IEventsManager eventManager = new EventsManager();
            ICommandParser commandParser = new CommandParser();
            IPrinter printer = new StringBuilderPrinter();

            ICommandFactory commandFactory = new CommandFactory(eventManager, printer);

            while (true)
            {
                string userLine = Console.ReadLine();
                if (userLine == "End" || userLine == null)
                {
                    break;
                }

                var currentCmdInfo = commandParser.Parse(userLine);
                var command = commandFactory.CreateCommand(currentCmdInfo);
                command.Execute(currentCmdInfo);
            }
            
            printer.PrintAll();
        }
    }
}