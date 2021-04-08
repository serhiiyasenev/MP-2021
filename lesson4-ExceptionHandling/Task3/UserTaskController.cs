using Task3.DoNotChange;
using Task3.Exception;

namespace Task3
{
    public class UserTaskController
    {
        private readonly UserTaskService _taskService;

        public UserTaskController(UserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            try
            {
                string message = GetMessageForModel(userId, description);
                if (message != null)
                {
                    model.AddAttribute("action_result", message);
                    return false;
                }

                return true;
            }
            catch (UserException e)
            {
                model.AddAttribute("action_result", e.Message);
                return false;
            }
            
        }

        private string GetMessageForModel(int userId, string description)
        {
            var task = new UserTask(description);
            var result = _taskService.AddTaskForUser(userId, task);

            return result switch
            {
                -1 => throw new InvalidUserIdException(),
                -2 => throw new UserNotFoundException(),
                -3 => throw new TheTaskAlreadyExistsException(),
                _ => null
            };
        }
    }
}