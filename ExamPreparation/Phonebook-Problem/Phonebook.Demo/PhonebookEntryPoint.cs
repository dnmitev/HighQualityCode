namespace Phonebook.Demo
{
    using System;
    using System.Linq;

    using Phonebook.Command;
    using Phonebook.Parser;
    using Phonebook.PhoneSanitizer;
    using Phonebook.Printer;
    using Phonebook.Repository;

    public class PhonebookEntryPoint
    {
        private static void Main()
        {
            IDeletablePhonebookRepository data = new PhonebookRepository();
            IPrinter printer = new StringBuilderPrinter();
            IPhoneNumberSanitizer sanitezer = new PhoneNumberSanitizer();
            ICommandParser commandParser = new CommandParser();

            IPrinter fancyPrinter = new FancyPrinter(printer);
            ICommandFactory commandFactory = new CommandFactory(fancyPrinter, data, sanitezer);

            while (true)
            {
                string userLine = Console.ReadLine();
                if (userLine == "End" || userLine == null)
                {
                    break;
                }

                var commandInfo = commandParser.Parse(userLine);
                IPhonebookCommand currentCommand = commandFactory.CreateCommand(commandInfo.CommandName, commandInfo.Arguments.Count());
                currentCommand.Excecute(commandInfo.Arguments.ToArray());
            }

            fancyPrinter.PrintAll();
        }
    }
}