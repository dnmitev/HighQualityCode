namespace Factory
{
    public class OddNumbersMatrixFactory : MatrixFactory
    {
        public OddNumbersMatrixFactory(int rows, int cols) : base(rows, cols)
        {
        }

        public override void CreateMatrix()
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColCount; j++)
                {
                    int currentNumber = 0;

                    do
                    {
                        currentNumber = MatrixFactory.RandomGenerator.Next(1, 10);
                    }
                    while (currentNumber % 2 == 0);

                    this.Matrix[i, j] = currentNumber.ToString();
                }
            }
        }
    }
}