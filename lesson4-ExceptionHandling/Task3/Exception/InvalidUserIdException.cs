namespace Task3.Exception
{
    public class InvalidUserIdException : UserException
    {
        public InvalidUserIdException()
        {
            Message = "Invalid userId";
        }

        public override string Message { get; }
    }
}
