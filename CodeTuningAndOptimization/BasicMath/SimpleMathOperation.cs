// 2. Write a program to compare the performance of add, subtract, increment, multiply, divide for int, 
// long, float, double and decimal values. 

namespace BasicMath
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class SimpleMathOperation
    {
        private static void Main()
        {
            const int Length = 20000;
            Stopwatch stopwatch = new Stopwatch();

            int resultInt = 0;
            long resultLong = 0;
            float resultFloat = 0.0F;
            double resultDouble = 0.0;
            decimal resultDecimal = 0.0M;

            Console.WriteLine("Diagnose the performance of summing 20 000 numbers");

            stopwatch.Start();

            for (int i = 0; i < Length; i++)
            {
                resultInt += i;
            }

            stopwatch.Stop();
            Console.WriteLine("Summing int, result: {0}, elapsed: {1}", resultInt, stopwatch.Elapsed);

            stopwatch.Restart();

            for (long i = 0; i < Length; i++)
            {
                resultLong += i;
            }

            stopwatch.Stop();
            Console.WriteLine("Summing long, result: {0}, elapsed: {1}", resultLong, stopwatch.Elapsed);

            stopwatch.Restart();

            for (float i = 0; i < Length; i += 0.01f)
            {
                resultFloat += i;
            }

            stopwatch.Stop();
            Console.WriteLine("Summing float, result: {0}, elapsed: {1}", resultFloat, stopwatch.Elapsed);

            stopwatch.Restart();

            for (double i = 0; i < Length; i += 0.01)
            {
                resultDouble += i;
            }

            stopwatch.Stop();
            Console.WriteLine("Summing double, result: {0}, elapsed: {1}", resultDouble, stopwatch.Elapsed);

            stopwatch.Restart();

            for (decimal i = 0; i < Length; i += 0.01m)
            {
                resultDecimal += i;
            }

            stopwatch.Stop();
            Console.WriteLine("Summing decimal, result: {0}, elapsed: {1}", resultDecimal, stopwatch.Elapsed);
        }
    }
}