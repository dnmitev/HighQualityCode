namespace CalendarSystem
{
    using System;

    public class EntryPoint
    {
        internal static void Main()
        {
            var eventManager = new EventsManager();
            var commandHandler = new CommandHandler(eventManager);

            while (true)
            {
                string userLine = Console.ReadLine();
                if (userLine == "End" || userLine == null)
                {
                    break;
                }

                //try
                //{
                    // The sequence of commands is finished
                    Console.WriteLine(commandHandler.ProcessCommand(Command.Parse(userLine)));
                //}
                //catch (StackOverflowException ex)
                //{
                //    Console.WriteLine(ex.Message);
                //}
            }
        }
    }
}