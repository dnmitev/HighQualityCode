namespace Refactoring
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Matrix
    {
        public const int MaxSize = 10;

        private static DeltaPosition[] deltaPositions;
        private int[,] matrix;

        static Matrix()
        {
            int directionsCount = DeltaPosition.DirectionCount;

            deltaPositions = new DeltaPosition[directionsCount];

            for (int i = 0; i < directionsCount; i++)
            {
                deltaPositions[i] = new DeltaPosition((Direction)i);
            }
        }

        public Matrix(int size)
        {
            if (size < 1 || size > MaxSize)
            {
                throw new ArgumentOutOfRangeException(string.Format("The size must be between {0} and {1}", 0, MaxSize));
            }

            this.matrix = new int[size, size];
        }

        public void Traverse()
        {
            this.Clear();

            int counter = 1;
            var position = new Position(0, 0);
            var deltaPosition = new DeltaPosition(Direction.Southeast);

            while (true)
            {
                this.matrix[position.Row, position.Col] = counter;

                if (!this.CanContinue(position))
                {
                    bool foundNewPosition = this.TryGetNewPosition(out position);

                    if (foundNewPosition)
                    {
                        counter++;
                        this.matrix[position.Row, position.Col] = counter;
                        deltaPosition.Direction = Direction.Southeast;
                    }
                    else
                    {
                        break;
                    }
                }

                while (!this.CanChangePosition(position.Row + deltaPosition.Row, position.Col + deltaPosition.Col))
                {
                    deltaPosition.UpdateDirection();
                }

                position.Update(deltaPosition);
                counter++;
            }
        }

        private bool TryGetNewPosition(out Position newPosition)
        {
            newPosition = new Position(0, 0);

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    if (this.matrix[row, col] == 0)
                    {
                        newPosition.Row = row;
                        newPosition.Col = col;

                        return true;
                    }
                }
            }

            return false;
        }

        private bool CanChangePosition(int row, int col)
        {
            bool validRow = 0 <= row && row < this.matrix.GetLength(0);
            bool validCol = 0 <= col && col < this.matrix.GetLength(1);

            return validRow && validCol && this.matrix[row, col] == 0;
        }

        private bool CanContinue(Position position)
        {
            for (int i = 0; i < deltaPositions.Length; i++)
            {
                if (this.CanChangePosition(position.Row + deltaPositions[i].Row, position.Col + deltaPositions[i].Col))
                {
                    return true;
                }
            }

            return false;
        }

        private void Clear()
        {
            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    this.matrix[row, col] = 0;
                }
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int row = 0; row < this.matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.matrix.GetLength(1); col++)
                {
                    result.AppendFormat("{0,3}", this.matrix[row, col]);
                }

                result.Append("\r\n");
            }

            result.Length -= 2;

            return result.ToString();
        }
    }
}