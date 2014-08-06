namespace ComputerSystem.Contracts
{
    using System;
    using System.Linq;
    using ComputerSystem.ComputerConfigurations;

    public interface IAbstractComputerFactory
    {
        PersonalComputer MakePersonalComputer();

        Laptop MakeLaptop();

        Server MakeServer();
    }
}