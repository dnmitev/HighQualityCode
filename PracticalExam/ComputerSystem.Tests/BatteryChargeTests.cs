namespace ComputerSystem.Tests
{
    using System;
    using ComputerSystem.Components;
    using ComputerSystem.Contracts;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class BatteryChargeTests
    {
        private IBattery battery;

        [TestInitialize]
        public void GetInstances()
        {
            this.battery = new Battery();
        }

        [TestMethod]
        public void ChargeBatteryWith10ShouldReturn60()
        {
            this.battery.ChargeBattery(10);

            Assert.AreEqual(60, this.battery.LeftCharge);
        }

        [TestMethod]
        public void ChargeBatteryMoreThanMaxChargeShouldReturn100()
        {
            this.battery.ChargeBattery(1000);

            Assert.AreEqual(100, this.battery.LeftCharge);
        }

        [TestMethod]
        public void ChargeBatteryLessThanMinChargeShouldReturn0()
        {
            this.battery.ChargeBattery(-1000);

            Assert.AreEqual(0, this.battery.LeftCharge);
        }

        [TestMethod]
        public void ChargeBatterySeveralTimesShouldReturnTrueResult()
        {
            this.battery.ChargeBattery(10);
            this.battery.ChargeBattery(10);
            this.battery.ChargeBattery(10);

            Assert.AreEqual(80, this.battery.LeftCharge);
        }

        [TestMethod]
        public void ChargeBatteryWith0PercentShouldReturn50()
        {
            this.battery.ChargeBattery(0);

            Assert.AreEqual(50, this.battery.LeftCharge);
        }

        [TestMethod]
        public void ChargeBatteryWithNegativePercentShouldReturnLessChargeLeft()
        {
            this.battery.ChargeBattery(-10);

            Assert.AreEqual(40, this.battery.LeftCharge);
        }

        [TestMethod]
        public void ChargeBatterySeveralTimesWithNegativePercentShouldReturnLessChargeLeft()
        {
            this.battery.ChargeBattery(-10);
            this.battery.ChargeBattery(-10);
            this.battery.ChargeBattery(-10);

            Assert.AreEqual(20, this.battery.LeftCharge);
        }
    }
}