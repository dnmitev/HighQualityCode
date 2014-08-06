namespace ComputerSystem.Contracts
{
    public interface ICpu
    {
        int NumberOfCores { get; }

        IRandomNumberProvider RandomNumberProvider { get; }

        IMotherboard Motherboard { get; }

        void GetSquare();

        void GetRandomNumber(int minValue, int maxValue);
    }
}