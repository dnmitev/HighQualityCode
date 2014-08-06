namespace ComputerSystem.Components
{
    using ComputerSystem.Contracts;

    public class Battery : IBattery
    {
        private const int MinCharge = 0;
        private const int MaxCharge = 100;
        private const int DefaultCharge = 50;

        private int leftCharge;

        public Battery()
        {
            this.LeftCharge = 50;
        }

        public int LeftCharge
        {
            get
            {
                return this.leftCharge;
            }

            private set
            {
                if (value < MinCharge)
                {
                    this.leftCharge = MinCharge;
                }
                else if (value > MaxCharge)
                {
                    this.leftCharge = MaxCharge;
                }
                else
                {
                    this.leftCharge = value;
                }
            }
        }

        public void ChargeBattery(int chargePercent)
        {
            this.LeftCharge += chargePercent;
        }
    }
}