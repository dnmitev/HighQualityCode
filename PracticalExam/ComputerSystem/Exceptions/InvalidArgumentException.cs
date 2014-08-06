namespace ComputerSystem.Exceptions
{
    using System;
    using System.Linq;

    public class InvalidArgumentException : ArgumentException
    {
        public InvalidArgumentException(string message) : base(message)
        {
        }
    }
}