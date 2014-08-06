namespace ComputerSystem.Components
{
    using System;
    using ComputerSystem.Contracts;

    public class RamMemory : IRamMemory
    {
        private int amount;
        private int value;

        public RamMemory(int amount)
        {
            this.Amount = amount;
        }

        public int Amount
        {
            get
            {
                return this.amount;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("RAM amount cannot be zero or negative.");
                }

                this.amount = value;
            }
        }

        public void SaveValue(int number)
        {
            this.value = number;
        }

        public int LoadValue()
        {
            return this.value;
        }
    }
}