namespace ComputerSystem.Components
{
    using System;
    using System.Linq;
    using ComputerSystem.Contracts;

    public class Motherboard : IMotherboard
    {
        private readonly IRamMemory ram;
        private readonly IVideoCard videoCard;

        public Motherboard(IRamMemory ram, IVideoCard videoCard)
        {
            this.ram = ram;
            this.videoCard = videoCard;
        }

        public void SaveToRam(int number)
        {
            this.ram.SaveValue(number);
        }

        public int LoadFromRam()
        {
            return this.ram.LoadValue();
        }

        public void Draw(string text)
        {
            this.videoCard.Draw(text);
        }
    }
}