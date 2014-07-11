namespace Factory
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Demo
    {
        public static void Main()
        {
            MatrixFactory matrixFactory = new CharMatrixFactory(5, 5);
            matrixFactory.CreateMatrix();
            Console.WriteLine(matrixFactory);
        }
    }
}