namespace VariablesDataExpressionsAndConstants
{
    using System;

    public class Statistic
    {
        public void PrintStatistics(double[] numerics, int count)
        {
            double max = GetMaxElement(numerics, count);
            double min = GetMinElement(numerics, count);
            double average = GetAverage(numerics, count);

            Print(max);
            Print(min);
            Print(average);
        }

        private double GetMaxElement(double[] elements, int count)
        {
            double max = elements[0];

            for (int i = 1; i < count; i++)
            {
                if (elements[i] > max)
                {
                    max = elements[i];
                }
            }

            return max;
        }

        private double GetMinElement(double[] elements, int count)
        {
            double min = elements[0];

            for (int i = 1; i < count; i++)
            {
                if (elements[i] < min)
                {
                    min = elements[i];
                }
            }

            return min;
        }

        private double GetAverage(double[] elements, int count)
        {
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += elements[i];
            }

            double average = sum / count;

            return average;
        }

        private void Print(double parameter)
        {
            Console.WriteLine(parameter);
        }
    }
}
