namespace ComputerSystem.Components
{
    using ComputerSystem.Contracts;
    using ComputerSystem.Exceptions;

    public class Cpu32Bit : Cpu
    {
        private const int MinNumber = 0;
        private const int MaxNumber = 500;

        public Cpu32Bit(int cores, IMotherboard motherboard, IRandomNumberProvider randomNumberProvider) : base(cores, motherboard, randomNumberProvider)
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