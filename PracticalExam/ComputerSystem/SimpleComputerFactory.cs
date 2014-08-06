namespace ComputerSystem
{
    using System;
    using System.Linq;
    using ComputerSystem.ComputerManufacturers;
    using ComputerSystem.Contracts;
    using ComputerSystem.Exceptions;

    public class SimpleComputerFactory : ISimpleComputerFactory
    {
        private const string HpManufacturerString = "HP";
        private const string DellManufacturerString = "Dell";
        private const string LenovoManufacturerString = "Lenovo";

        public AbstractComputerFactory CreateManufacturer(string manufacturer)
        {
            if (string.Compare(manufacturer, HpManufacturerString, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return new HpFactory();
            }
            else if (string.Compare(manufacturer, DellManufacturerString, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return new DellFactory();
            }
            else if (string.Compare(manufacturer, LenovoManufacturerString, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return new LenovoFactory();
            }
            else
            {
                throw new InvalidArgumentException("Invalid manufacturer!");
            }
        }
    }
}