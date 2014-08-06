namespace ComputerSystem.Tests
{
    using System;
    using ComputerSystem.Components;
    using ComputerSystem.Contracts;
    using ComputerSystem.Exceptions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CpuSquareNumberTests
    {
        private Mock<IVideoCard> videoCardMock;
        private Mock<IRandomNumberProvider> randomNumberProviderMock;
        private IMotherboard motherboard;
        private bool isCalled;

        [TestInitialize]
        public void GetInstances()
        {
            this.isCalled = false;
            this.videoCardMock = new Mock<IVideoCard>();
            this.randomNumberProviderMock = new Mock<IRandomNumberProvider>();

            this.videoCardMock.Setup(vc => vc.Draw(It.IsAny<string>())).Callback(() => { this.isCalled = true; });

            this.motherboard = new Motherboard(new RamMemory(2), this.videoCardMock.Object);
        }

        [TestMethod]
        public void GetSquareShouldBeCalledOn32BitCpu()
        {
            var cpu = new Cpu32Bit(2, this.motherboard, this.randomNumberProviderMock.Object);

            cpu.GetRandomNumber(1, 10);
            cpu.GetSquare();

            Assert.IsTrue(this.isCalled);
        }

        [TestMethod]
        public void GetSquareShouldBeCalledOn64BitCpu()
        {
            var cpu = new Cpu64Bit(2, this.motherboard, this.randomNumberProviderMock.Object);

            cpu.GetRandomNumber(1, 10);
            cpu.GetSquare();

            Assert.IsTrue(this.isCalled);
        }

        [TestMethod]
        public void GetSquareShouldBeCalledOn128BitCpu()
        {
            var cpu = new Cpu128Bit(2, this.motherboard, this.randomNumberProviderMock.Object);

            cpu.GetRandomNumber(1, 10);
            cpu.GetSquare();

            Assert.IsTrue(this.isCalled);
        }

        [TestMethod]
        [ExpectedException(typeof(LowerNumberException))]
        public void GetSquareOfNegativeDateShouldThrowLowerNumberExceptionOn32BitCpu()
        {
            var cpu = new Cpu32Bit(2, this.motherboard, this.randomNumberProviderMock.Object);

            this.randomNumberProviderMock.Setup(rndNum => rndNum.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(-100);

            cpu.GetRandomNumber(1, 10);
            cpu.GetSquare();
        }

        [TestMethod]
        [ExpectedException(typeof(HigherNumberException))]
        public void GetSquareOfNegativeDateShouldThrowHigherNumberExceptionOn32BitCpu()
        {
            var cpu = new Cpu32Bit(2, this.motherboard, this.randomNumberProviderMock.Object);

            this.randomNumberProviderMock.Setup(rndNum => rndNum.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(501);

            cpu.GetRandomNumber(1, 10);
            cpu.GetSquare();
        }

        [TestMethod]
        [ExpectedException(typeof(LowerNumberException))]
        public void GetSquareOfNegativeDateShouldThrowLowerNumberExceptionOn64BitCpu()
        {
            var cpu = new Cpu64Bit(2, this.motherboard, this.randomNumberProviderMock.Object);

            this.randomNumberProviderMock.Setup(rndNum => rndNum.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(-100);

            cpu.GetRandomNumber(1, 10);
            cpu.GetSquare();
        }

        [TestMethod]
        [ExpectedException(typeof(HigherNumberException))]
        public void GetSquareOfNegativeDateShouldThrowHigherrNumberExceptionOn64BitCpu()
        {
            var cpu = new Cpu64Bit(2, this.motherboard, this.randomNumberProviderMock.Object);

            this.randomNumberProviderMock.Setup(rndNum => rndNum.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(1001);

            cpu.GetRandomNumber(1, 10);
            cpu.GetSquare();
        }

        [TestMethod]
        [ExpectedException(typeof(LowerNumberException))]
        public void GetSquareOfNegativeDateShouldThrowLowerNumberExceptionOn128BitCpu()
        {
            var cpu = new Cpu128Bit(2, this.motherboard, this.randomNumberProviderMock.Object);

            this.randomNumberProviderMock.Setup(rndNum => rndNum.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(-100);

            cpu.GetRandomNumber(1, 10);
            cpu.GetSquare();
        }

        [TestMethod]
        [ExpectedException(typeof(HigherNumberException))]
        public void GetSquareOfNegativeDateShouldThrowHigherNumberExceptionOn128BitCpu()
        {
            var cpu = new Cpu128Bit(2, this.motherboard, this.randomNumberProviderMock.Object);

            this.randomNumberProviderMock.Setup(rndNum => rndNum.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(2001);

            cpu.GetRandomNumber(1, 10);
            cpu.GetSquare();
        }
    }
}