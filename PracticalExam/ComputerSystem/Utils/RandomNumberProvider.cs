namespace ComputerSystem.Utils
{
    using System;
    using System.Linq;
    using ComputerSystem.Contracts;

    public class RandomNumberProvider : IRandomNumberProvider
    {
        private readonly Random randomGenerator;

        public RandomNumberProvider()
        {
            this.randomGenerator = new Random();
        }

        public int GetRandomNumber(int minValue, int maxValue)
        {
            // since it is from minValue to maxValue, inclusive, it should be greater with 1
            return this.randomGenerator.Next(minValue, maxValue + 1);
        }
    }
}