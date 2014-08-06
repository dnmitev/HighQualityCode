namespace ComputerSystem.Components
{
    using System;
    using ComputerSystem.Contracts;

    public class ColorfulVideoCard : IVideoCard
    {
        public void Draw(string text)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(text);
            Console.ResetColor();
        }
    }
}