namespace ComputerSystem.Components
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ComputerSystem.Contracts;

    public class HardDrive : IHardDrive
    {
        private readonly ICollection<IHardDrive> raidHddArray;
        private readonly IDictionary<int, string> data;

        private int capacity;

        public HardDrive(int capacity)
            : this(capacity, false, 1)
        {
        }

        public HardDrive(int capacity, bool isInRaid, int hardDrivesInRaid)
        {
            this.Capacity = capacity;
            this.IsInRaid = isInRaid;
            this.data = new Dictionary<int, string>(capacity);
            this.raidHddArray = new List<IHardDrive>(hardDrivesInRaid);
        }

        public int Capacity
        {
            get
            {
                if (this.IsInRaid)
                {
                    if (!this.raidHddArray.Any())
                    {
                        return 0;
                    }

                    return this.raidHddArray.First().Capacity;
                }
                else
                {
                    return this.capacity;
                }
            }

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("HDD capacity cannot be negative.");
                }

                this.capacity = value;
            }
        }

        public bool IsInRaid { get; private set; }

        public void Save(int address, string text)
        {
            if (address > this.Capacity)
            {
                throw new ArgumentOutOfRangeException("The address is out of the HDD capacity.");
            }

            this.data[address] = text;
        }

        public string Load(int address)
        {
            return this.data[address];
        }
    }
}