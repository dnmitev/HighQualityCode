namespace ControlFlow.ConditionalStatements
{
    using ControlFlow.StraightlineCode;
    using System;

    public class ConditionalStatement
    {
        static void Main()
        {
            Potato potato = new Potato();

            if (potato != null && potato.IsHealthy && potato.IsPeeled)
            {
                Cook(potato);
            }

            int x = 0;
            int xMin = 0;
            int xMax = 0;

            int y = 0;
            int yMin = 0;
            int yMax = 0;

            bool shouldVisitCell = true;

            bool isValidX = xMin <= x && x <= xMax;
            bool isValidY = yMin <= y && y <= yMax;

            bool isCellValid = shouldVisitCell;

            if (isCellValid && isValidX && isValidY)
            {
                VisitCell();
            }
        }
 
        private static void VisitCell()
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
 
        private static void Cook(Potato potato)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
