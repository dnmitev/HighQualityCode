namespace CalendarSystem.Printer
{
    using System;
    using System.Text;

    public class StringBuilderPrinter : IPrinter
    {
        private StringBuilder output = new StringBuilder();

        public void Print(string text)
        {
            this.output.AppendLine(text);
        }

        public void PrintAll()
        {
            Console.WriteLine(this.output.ToString());
        }
    }
}