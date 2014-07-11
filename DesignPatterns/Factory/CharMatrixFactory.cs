namespace Factory
{

    public class CharMatrixFactory : MatrixFactory
    {
        public CharMatrixFactory(int rows, int cols) : base(rows, cols)
        {
        }

        public override void CreateMatrix()
        {
            for (int i = 0; i < this.RowCount; i++)
            {
                for (int j = 0; j < this.ColCount; j++)
                {
                    int currentNumber = MatrixFactory.RandomGenerator.Next(20, 30);

                    this.Matrix[i, j] = ((char)currentNumber).ToString();
                }
            }
        }
    }
}