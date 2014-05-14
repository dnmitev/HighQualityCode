namespace NamingIdentifiers.ConsolePrinter
{
    using System;
    using System.Linq;

    public class ConsolePrinter
    {
        public void toPrint(bool condition)
        {
            string conditionToString = condition.ToString();

            Console.WriteLine(conditionToString);
        }
    }
}