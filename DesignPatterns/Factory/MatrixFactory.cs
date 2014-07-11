namespace Factory
{
    using System;
    using System.Text;

    public abstract class MatrixFactory
    {
        protected static Random RandomGenerator = new Random();

        private int rowCount;
        private int colCount;

        public MatrixFactory(int rows, int cols)
        {
            this.RowCount = rows;
            this.ColCount = cols;
            this.Matrix = new string[this.RowCount, this.ColCount];
        }

        protected int ColCount
        {
            get
            {
                return this.colCount;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Matrix col count must be a positive number");
                }

                this.colCount = value;
            }
        }

        protected int RowCount
        {
            get
            {
                return this.rowCount;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Matrix row count must be a positive number");
                }

                this.rowCount = value;
            }
        }

        public string[,] Matrix { get; private set; }

        public abstract void CreateMatrix();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < this.RowCount; i++)
            {
                string row = string.Empty;

                for (int j = 0; j < this.ColCount; j++)
                {
                    row += this.Matrix[i, j] + " ";
                }

                result.AppendLine(row);
            }

            return result.ToString();
        }
    }
}