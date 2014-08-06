namespace ComputerSystem.Tests
{
    using System;
    using ComputerSystem.Components;
    using ComputerSystem.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;

    [TestClass]
    public class CpuGetRandomNumberTests
    {
        private Mock<IRandomNumberProvider> randomNumberProviderMock;
        private ICpu processor;
        private IMotherboard motherboard;

        [TestInitialize]
        public void GetInstances()
        {
            this.randomNumberProviderMock = new Mock<IRandomNumberProvider>();

            var ram = new RamMemory(8);
            var videoCard = new ColorfulVideoCard();
            this.motherboard = new Motherboard(ram, videoCard);

            this.processor = new Cpu32Bit(2, this.motherboard, this.randomNumberProviderMock.Object);
        }

        [TestMethod]
        public void GetRandomNumberShouldSaveNumberInRamMemory()
        {
            this.randomNumberProviderMock.Setup(rndNum => rndNum.GetRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(5);

            this.processor.GetRandomNumber(1, 10);

            var number = this.motherboard.LoadFromRam();

            Assert.AreEqual(5, number);
        }
    }
}