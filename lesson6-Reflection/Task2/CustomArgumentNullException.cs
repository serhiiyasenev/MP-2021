using System;

namespace Task2
{
    public class CustomArgumentNullException : Exception
    {
        public CustomArgumentNullException(string message) : base(message)
        {
        }
    }
}
