namespace ComputerSystem.Components
{
    using System;
    using ComputerSystem.Contracts;

    public abstract class Cpu : ICpu
    {
        private int numberOfCores;

        public Cpu(int cores, IMotherboard motherboard, IRandomNumberProvider randomNumberProvider)
        {
            this.NumberOfCores = cores;
            this.Motherboard = motherboard;
            this.RandomNumberProvider = randomNumberProvider;
        }

        public int NumberOfCores
        {
            get
            {
                return this.numberOfCores;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("CPU cannot have less than 1 core.");
                }

                this.numberOfCores = value;
            }
        }

        public IRandomNumberProvider RandomNumberProvider { get; set; }

        public IMotherboard Motherboard { get; set; }

        public abstract void GetSquare();

        public void GetRandomNumber(int minValue, int maxValue)
        {
            var number = this.RandomNumberProvider.GetRandomNumber(minValue, maxValue);
            this.Motherboard.SaveToRam(number);
        }
    }
}