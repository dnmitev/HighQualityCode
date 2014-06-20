using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Refactoring;

namespace RotatedWalkInMatrixTest
{
    [TestClass]
    public class DeltaPositionTest
    {
        [TestMethod]
        public void DirectionSouthEastTest()
        {
            var delta = new DeltaPosition(Direction.Southeast);

            Assert.AreEqual(1, delta.Row, "Row should be 1.");
            Assert.AreEqual(1, delta.Col, "Column should be 1.");
        }

        [TestMethod]
        public void DirectionSouthTest()
        {
            var delta = new DeltaPosition(Direction.South);

            Assert.AreEqual(1, delta.Row, "Row should be 1.");
            Assert.AreEqual(0, delta.Col, "Column should be 0.");
        }

        [TestMethod]
        public void DirectionSouthWestTest()
        {
            var delta = new DeltaPosition(Direction.Southwest);

            Assert.AreEqual(1, delta.Row, "Row should be 1.");
            Assert.AreEqual(-1, delta.Col, "Column should be -1.");
        }

        [TestMethod]
        public void DirectionWestTest()
        {
            var delta = new DeltaPosition(Direction.West);

            Assert.AreEqual(0, delta.Row, "Row should be 0.");
            Assert.AreEqual(-1, delta.Col, "Column should be -1.");
        }

        [TestMethod]
        public void DirectionNorthWestTest()
        {
            var delta = new DeltaPosition(Direction.Northwest);

            Assert.AreEqual(-1, delta.Row, "Row should be -1.");
            Assert.AreEqual(-1, delta.Col, "Column should be -1.");
        }

        [TestMethod]
        public void DirectionNorthTest()
        {
            var delta = new DeltaPosition(Direction.North);

            Assert.AreEqual(-1, delta.Row, "Row should be -1.");
            Assert.AreEqual(0, delta.Col, "Column should be 0.");
        }

        [TestMethod]
        public void DirectionNorthEastTest()
        {
            var delta = new DeltaPosition(Direction.Northeast);

            Assert.AreEqual(-1, delta.Row, "Row should be -1.");
            Assert.AreEqual(1, delta.Col, "Column should be 1.");
        }

        [TestMethod]
        public void DirectionEastTest()
        {
            var delta = new DeltaPosition(Direction.East);

            Assert.AreEqual(0, delta.Row, "Row should be 0.");
            Assert.AreEqual(1, delta.Col, "Column should be 1.");
        }
    }
}
