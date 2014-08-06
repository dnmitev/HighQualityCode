namespace ComputerSystem.ComputerManufacturers
{
    using System;
    using System.Linq;
    using ComputerSystem.ComputerConfigurations;
    using ComputerSystem.Contracts;

    public abstract class AbstractComputerFactory : IAbstractComputerFactory
    {
        public abstract PersonalComputer MakePersonalComputer();

        public abstract Laptop MakeLaptop();

        public abstract Server MakeServer();
    }
}