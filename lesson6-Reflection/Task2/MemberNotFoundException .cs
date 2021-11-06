using System;

namespace Task2
{
    public class MemberNotFoundException  : Exception
    {
        public MemberNotFoundException(string message) : base(message)
        {
        }
    }
}
