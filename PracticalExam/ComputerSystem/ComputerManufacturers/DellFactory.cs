namespace ComputerSystem.ComputerManufacturers
{
    using System.Collections.Generic;
    using ComputerSystem.Components;
    using ComputerSystem.ComputerConfigurations;
    using ComputerSystem.Contracts;
    using ComputerSystem.Utils;

    public class DellFactory : AbstractComputerFactory
    {
        private const int DefaultPersonalComputerCpuCoresCount = 4;
        private const int DefaultServerCpuCoresCount = 4;
        private const int DefaultLaptopCpuCoresCount = 4;

        private const int DefaultPersonalComputerRamAmount = 8;
        private const int DefaultServerRamAmount = 64;
        private const int DefaultLaptopRamAmount = 8;

        private const int DefaultPersonalComputerHardDrivesCount = 1;
        private const int DefaultServerHardDrivesCount = 2;
        private const int DefaultLaptopHardDrivesCount = 1;

        private const int DefaultPersonalComputerHardDrivesCapacity = 1000;
        private const int DefaultServerHardDrivesCapacity = 2000;
        private const int DefaultLaptopHardDrivesCapacity = 1000;

        public override PersonalComputer MakePersonalComputer()
        {
            var ram = new RamMemory(DefaultPersonalComputerRamAmount);
            var videoCard = new ColorfulVideoCard();

            var motherboard = new Motherboard(ram, videoCard);

            var randomNumberProvider = new RandomNumberProvider();

            var processor = new Cpu64Bit(DefaultPersonalComputerCpuCoresCount, motherboard, randomNumberProvider);

            var hardDrive = new HardDrive(DefaultPersonalComputerHardDrivesCapacity);
            var hardDrives = new List<IHardDrive>(DefaultPersonalComputerHardDrivesCount);
            for (int i = 0; i < DefaultPersonalComputerHardDrivesCount; i++)
            {
                hardDrives.Add(hardDrive);
            }

            var personalComputer = new PersonalComputer(processor, hardDrives);

            return personalComputer;
        }

        public override Laptop MakeLaptop()
        {
            var ram = new RamMemory(DefaultLaptopRamAmount);
            var videoCard = new ColorfulVideoCard();

            var motherboard = new Motherboard(ram, videoCard);

            var randomNumberProvider = new RandomNumberProvider();

            var processor = new Cpu32Bit(DefaultLaptopCpuCoresCount, motherboard, randomNumberProvider);

            var hardDrive = new HardDrive(DefaultLaptopHardDrivesCapacity);
            var hardDrives = new List<IHardDrive>(DefaultLaptopHardDrivesCount);
            for (int i = 0; i < DefaultLaptopHardDrivesCount; i++)
            {
                hardDrives.Add(hardDrive);
            }

            var battery = new Battery();

            var laptop = new Laptop(processor, hardDrives, battery);

            return laptop;
        }

        public override Server MakeServer()
        {
            var ram = new RamMemory(DefaultServerRamAmount);
            var videoCard = new MonochromeVideoCard();

            var motherboard = new Motherboard(ram, videoCard);

            var randomNumberProvider = new RandomNumberProvider();

            var processor = new Cpu64Bit(DefaultServerCpuCoresCount, motherboard, randomNumberProvider);

            var hardDrive = new HardDrive(DefaultServerHardDrivesCapacity);
            var hardDrives = new List<IHardDrive>(DefaultServerHardDrivesCount);
            for (int i = 0; i < DefaultServerHardDrivesCount; i++)
            {
                hardDrives.Add(hardDrive);
            }

            var server = new Server(processor, hardDrives);

            return server;
        }
    }
}