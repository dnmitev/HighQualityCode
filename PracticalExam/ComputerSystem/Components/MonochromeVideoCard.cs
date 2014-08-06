namespace ComputerSystem.Components
{
    using System;
    using ComputerSystem.Contracts;

    public class MonochromeVideoCard : IVideoCard
    {
        public void Draw(string text)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}