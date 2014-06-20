namespace Refactoring
{
    using System;

    public class Position
    {
        private int row;
        private int col;

        public Position(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return this.row;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Row position cannot be negative");
                }
                else
                {
                    this.row = value;
                }
            }
        }

        public int Col
        {
            get
            {
                return this.col;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Column position cannot be negative");
                }
                else
                {
                    this.col = value;
                }
            }
        }

        public void Update(DeltaPosition deltaPosition)
        {
            this.Row += deltaPosition.Row;
            this.Col += deltaPosition.Col;
        }
    }
}