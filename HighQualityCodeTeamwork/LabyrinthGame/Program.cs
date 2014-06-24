namespace LabyrinthGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    class Program
    {
        static void Main()
        {
            //CreateSquareLabyrinth();
            //CreateTriangleLabyrinth();
            //CreateHexagonalLabyrinth();
            CreateDiamnondLabyrinth();
        }

        private static void CreateDiamnondLabyrinth()
        {
            ILabyrinth labyrinth = new DiamondLabyrinth();
            labyrinth.Create();

            (labyrinth as IRenderable).Render();
        }

        private static void CreateHexagonalLabyrinth()
        {
            ILabyrinth labyrinth = new HexagonalLabyrinth();
            labyrinth.Create();

            (labyrinth as IRenderable).Render();
        }

        private static void CreateTriangleLabyrinth()
        {
            ILabyrinth labyrinth = new TriangleLabyrinth();
            labyrinth.Create();

            (labyrinth as IRenderable).Render();
        }

        private static void CreateSquareLabyrinth()
        {
            ILabyrinth labyrinth = new SquareLabyrinth();
            labyrinth.Create();

            (labyrinth as IRenderable).Render();
        }
    }
}