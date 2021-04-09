using System;
using System.Linq;
using Task3.DoNotChange;
using Task3.Exception;

namespace Task3
{
    public class UserTaskService
    {
        private readonly IUserDao _userDao;

        public UserTaskService(IUserDao userDao)
        {
            _userDao = userDao;
        }

        public int AddTaskForUser(int userId, UserTask task)
        {
            if (userId < 0)
                throw new InvalidUserIdException();

            var user = _userDao.GetUser(userId);
            if (user == null)
                throw new UserNotFoundException();

            var tasks = user.Tasks;

            if (tasks.Any(t => string.Equals(task.Description, t.Description, StringComparison.OrdinalIgnoreCase)))
            {
                throw new TheTaskAlreadyExistsException();
            }

            tasks.Add(task);

            return 0;
        }
    }
}