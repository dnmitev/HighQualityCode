namespace Refactoring
{
    using System;

    public class MatrixDemo
    {
        static void Main()
        {
            string input;
            int size;

            do
            {
                Console.Write("Enter n, (0 < n <= 10):");
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out size) || size < 1 || size > Matrix.MaxSize);

            var matrix = new Matrix(size);

            matrix.Traverse();

            Console.WriteLine(matrix);
        }
    }
}