namespace ComputerSystem.Contracts
{
    public interface IRamMemory
    {
        int Amount { get; }

        void SaveValue(int number);

        int LoadValue();
    }
}