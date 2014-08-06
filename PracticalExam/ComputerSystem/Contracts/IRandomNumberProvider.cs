namespace ComputerSystem.Contracts
{
    public interface IRandomNumberProvider
    {
        int GetRandomNumber(int minValue, int maxValue);
    }
}