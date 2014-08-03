namespace Phonebook
{
    using System;

    using Phonebook.Command;
    using Phonebook.PhoneSanitizer;
    using Phonebook.Printer;
    using Phonebook.Repository;

    public class CommandFactory : ICommandFactory
    {
        private IDeletablePhonebookRepository phonebookRepo;
        private IPrinter printer;
        private IPhoneNumberSanitizer sanitizer;

        private IPhonebookCommand addEntryCommand;
        private IPhonebookCommand changePhoneCommand;
        private IPhonebookCommand listEntriesCommand;
        private IPhonebookCommand removeCommand;

        public CommandFactory(IPrinter printer, IDeletablePhonebookRepository repo, IPhoneNumberSanitizer sanitizer)
        {
            this.printer = printer;
            this.phonebookRepo = repo;
            this.sanitizer = sanitizer;
        }

        public IPhonebookCommand CreateCommand(string commandName, int argumentsCount)
        {
            IPhonebookCommand command;

            if (commandName.StartsWith("AddPhone") && (argumentsCount >= 2))
            {
                if (this.addEntryCommand == null)
                {
                    this.addEntryCommand = new AddPhoneCommand(this.printer, this.phonebookRepo, this.sanitizer);
                }

                command = this.addEntryCommand;
            }
            else if ((commandName == "ChangePhone") && (argumentsCount == 2))
            {
                if (this.changePhoneCommand == null)
                {
                    this.changePhoneCommand = new ChangePhoneCommand(this.printer, this.phonebookRepo, this.sanitizer);
                }

                command = this.changePhoneCommand;
            }
            else if ((commandName == "List") && (argumentsCount == 2))
            {
                if (this.listEntriesCommand == null)
                {
                    this.listEntriesCommand = new ListEntriesCommand(this.printer, this.phonebookRepo);
                }

                command = this.listEntriesCommand;
            }
            else if (commandName == "Remove")
            {
                if (this.removeCommand == null)
                {
                    this.removeCommand = new RemoveCommand(this.printer, this.phonebookRepo, this.sanitizer);
                }

                command = this.removeCommand;
            }
            else
            {
                throw new ArgumentException("Not specified command.");
            }

            return command;
        }
    }
}