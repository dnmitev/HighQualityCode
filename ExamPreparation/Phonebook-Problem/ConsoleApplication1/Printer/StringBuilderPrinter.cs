namespace Phonebook.Printer
{
    using System;
    using System.Text;

    public class StringBuilderPrinter : Printer
    {
        private StringBuilder output = new StringBuilder();

        public override void Print(string text)
        {
            this.output.AppendLine(text);
        }

        public override void PrintAll()
        {
            Console.Write(this.output.ToString());
        }
    }
}