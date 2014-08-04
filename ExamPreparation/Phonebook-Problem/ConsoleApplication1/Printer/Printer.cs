namespace Phonebook.Printer
{
    using System;
    using System.Linq;

    public abstract class Printer : IPrinter
    {
        public abstract void Print(string text);

        public abstract void PrintAll();
    }
}