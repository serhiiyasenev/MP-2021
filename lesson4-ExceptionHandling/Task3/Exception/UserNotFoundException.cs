namespace Task3.Exception
{
    public class UserNotFoundException : UserException
    {
        public UserNotFoundException()
        {
            Message = "User not found";
        }

        public override string Message { get; }
    }
}
