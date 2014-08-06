namespace ComputerSystem.Exceptions
{
    using System;
    using System.Linq;

    public class LowerNumberException : ArgumentException
    {
        public LowerNumberException()
            : this(string.Empty)
        {
        }

        public LowerNumberException(string message)
            : base(message)
        {
        }
    }
}