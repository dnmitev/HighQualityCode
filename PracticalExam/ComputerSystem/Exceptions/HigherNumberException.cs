namespace ComputerSystem.Exceptions
{
    using System;
    using System.Linq;

    public class HigherNumberException : ArgumentException
    {
        public HigherNumberException() : this(string.Empty)
        {
        }

        public HigherNumberException(string message) : base(message)
        {
        }
    }
}