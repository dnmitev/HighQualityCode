namespace Phonebook.Printer
{
    using System;
    using System.Linq;

    public abstract class PrinterDecorator : Printer
    {
        public PrinterDecorator(IPrinter printer)
        {
            this.Printer = printer;
        }

        protected IPrinter Printer { get; set; }

        public override void Print(string text)
        {
            this.Printer.Print(text);
        }

        public override void PrintAll()
        {
            this.Printer.PrintAll();
        }
    }
}