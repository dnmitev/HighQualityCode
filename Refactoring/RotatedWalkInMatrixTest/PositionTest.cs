using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RotatedWalkInMatrixTest
{
    [TestClass]
    public class PositionTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void CreateNewPositionWithExceptionExpectedTest()
        {
            var position = new Position(-1, 0);
        }

        [TestMethod]
        public void UpdatePositionTest()
        {
            var position = new Position(0, 0);
            var expectedPosition = new Position(1, 1);
            var delta = new DeltaPosition(Direction.Southeast);

            position.Update(delta);

            Assert.AreEqual(expectedPosition.Row, position.Row, "Row should be 1");
            Assert.AreEqual(expectedPosition.Col, position.Col, "Col should be 1");
        }
    }
}
