namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Phonebook.Repository;
    using Phonebook.Printer;
    using Phonebook.PhoneSanitizer;
    using Phonebook.Parser;
    using Phonebook.Command;

    public class PhonebookEntryPoint
    {
        private static void Main()
        {
            IPhonebookRepository data = new PhonebookRepository();
            IPrinter printer = new StringBuilderPrinter();
            IPhoneNumberSanitizer sanitezer = new PhoneNumberSanitizer();
            ICommandFactory commandFactory = new CommandFactory(printer, data, sanitezer);
            ICommandParser commandParser = new CommandParser();

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

            printer.PrintAll();
        }
    }
}