// 3. Write a program to compare the performance of square root, natural logarithm, sinus for float, 
// double and decimal values.

namespace AdvancedMath
{
    using System;
    using System.Diagnostics;
    using System.Linq;

    public class AdvancedMathOperation
    {
        private static void Main()
        {
            Stopwatch stopwatch = new Stopwatch();

            float resultFloat = 0.0f;
            double resultDouble = 0.0;
            decimal resultDecimal = 0.0m;

            Console.WriteLine("Square root performance:");
            stopwatch.Start();
            resultFloat = (float)Math.Sqrt(154646846.1616f);
            stopwatch.Stop();
            Console.WriteLine("float: result: {0}, elapsed: {1}", resultFloat, stopwatch.Elapsed);

            stopwatch.Restart();
            resultDouble = Math.Sqrt(154646846.1616);
            stopwatch.Stop();
            Console.WriteLine("double: result: {0}, elapsed: {1}", resultDouble, stopwatch.Elapsed);

            stopwatch.Restart();
            resultDecimal = (decimal)Math.Sqrt((double)154646846.1616m);
            stopwatch.Stop();
            Console.WriteLine("decimal: result: {0}, elapsed: {1}", resultDecimal, stopwatch.Elapsed);

            Console.WriteLine("\nNatural logarithm performance:");
            stopwatch.Restart();
            resultFloat = (float)Math.Log(154646846.1616f);
            stopwatch.Stop();
            Console.WriteLine("float: result: {0}, elapsed: {1}", resultFloat, stopwatch.Elapsed);

            stopwatch.Restart();
            resultDouble = Math.Log(154646846.1616);
            stopwatch.Stop();
            Console.WriteLine("double: result: {0}, elapsed: {1}", resultDouble, stopwatch.Elapsed);

            stopwatch.Restart();
            resultDecimal = (decimal)Math.Log((double)154646846.1616m);
            stopwatch.Stop();
            Console.WriteLine("decimal: result: {0}, elapsed: {1}", resultDecimal, stopwatch.Elapsed);

            Console.WriteLine("\nSinus performance:");
            stopwatch.Restart();
            resultFloat = (float)Math.Sin(154646846.1616f);
            stopwatch.Stop();
            Console.WriteLine("float: result: {0}, elapsed: {1}", resultFloat, stopwatch.Elapsed);

            stopwatch.Restart();
            resultDouble = Math.Sin(154646846.1616);
            stopwatch.Stop();
            Console.WriteLine("double: result: {0}, elapsed: {1}", resultDouble, stopwatch.Elapsed);

            stopwatch.Restart();
            resultDecimal = (decimal)Math.Sin((double)154646846.1616m);
            stopwatch.Stop();
            Console.WriteLine("decimal: result: {0}, elapsed: {1}", resultDecimal, stopwatch.Elapsed);
        }
    }
}