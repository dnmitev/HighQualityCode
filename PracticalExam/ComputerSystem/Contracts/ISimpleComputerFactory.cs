namespace ComputerSystem.Contracts
{
    using System;
    using System.Linq;
    using ComputerSystem.ComputerManufacturers;
    
    public interface ISimpleComputerFactory
    {
        AbstractComputerFactory CreateManufacturer(string manufacturer);
    }
}