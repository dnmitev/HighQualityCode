namespace Phonebook.Printer
{
    using System;
    using System.Linq;

    public class FancyPrinter : PrinterDecorator
    {
        public FancyPrinter(IPrinter printer) : base(printer)
        {
        }

        public override void Print(string text)
        {
            base.Print(text);
            base.Print("Because I'm happy :)");
        }

        public override void PrintAll()
        {
            base.PrintAll();
            Console.WriteLine("Mnoo fancy stana toq printer.");
        }
    }
}