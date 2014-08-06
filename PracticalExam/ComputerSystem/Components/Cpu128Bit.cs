namespace ComputerSystem.Components
{
    using System;
    using System.Linq;
    using ComputerSystem.Contracts;
    using ComputerSystem.Exceptions;

    public class Cpu128Bit : Cpu
    {
        private const int MinNumber = 0;
        private const int MaxNumber = 2000;

        public Cpu128Bit(int cores, IMotherboard motherboard, IRandomNumberProvider randomNumberProvider) : base(cores, motherboard, randomNumberProvider)
        {
        }

        public override void GetSquare()
        {
            var data = this.Motherboard.LoadFromRam();

            if (data < MinNumber)
            {
                throw new LowerNumberException();
            }
            else if (data > MaxNumber)
            {
                throw new HigherNumberException();
            }
            else
            {
                int square = data * data;
                this.Motherboard.Draw(string.Format("Square of {0} is {1}.", data, square));
            }
        }
    }
}