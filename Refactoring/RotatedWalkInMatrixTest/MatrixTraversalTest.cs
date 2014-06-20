namespace RotatedWalkInMatrixTest
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Refactoring;

    [TestClass]
    public class MatrixTraversalTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateMatrixWithBiggerSizeThanMaxTest()
        {
            var matrix = new Matrix(Matrix.MaxSize + 1);
        }

        [TestMethod]
        public void TraverseMatrixWith3ElementsTest()
        {
            var matrix = new Matrix(3);

            string result = "  1  7  8\r\n"
                           + "  6  2  9\r\n"
                           + "  5  4  3";

            matrix.Traverse();

            Assert.AreEqual(result, matrix.ToString());
        }
    }
}