namespace Task3.Exception
{
    public class TheTaskAlreadyExistsException : UserException
    {
        public TheTaskAlreadyExistsException()
        {
            Message = "The task already exists";
        }

        public override string Message { get; }
    }
}
