public class MockDatabase : IDatabase
{
    private List<Task> tasks;
    private int nextTaskId;
    public MockDatabase()
    {
        tasks = new List<Task>
        {
            new Task
            {
                TaskId = 1,
                TaskName = "Mock Task 1",
                Description = "This is a mock task",
                CreatedDate = DateTime.Now,
                Status = "completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 2,
                TaskName = "Mock Task 2",
                Description = "Another mock task",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 3,
                TaskName = "Mock Task 3",
                Description = "Yet another mock task",
                CreatedDate = DateTime.Now,
                Status = "completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 4,
                TaskName = "Mock Task 4",
                Description = "Where do these mock tasks appear from?",
                CreatedDate = DateTime.Now,
                Status = "completed",
                TaskLifecycleType = TaskLifecycleType.AdHoc
            },
            new Task
            {
                TaskId = 5,
                TaskName = "Mock Task 5",
                Description = "Here is another mock task",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 6,
                TaskName = "Mock Task 6",
                Description = "Mock tasks from outer space!",
                CreatedDate = DateTime.Now,
                Status = "completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 7,
                TaskName = "Mock Task 7",
                Description = "This is just a mock task, dont worry.",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 8,
                TaskName = "Mock Task 8",
                Description = "Is this a mock task? Is it a task? Is it? Is anything? Help, I am trapped in the mock twilight zone!",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.AdHoc
            }
        };

        nextTaskId = tasks.Count + 1;
    }

    public List<Task> GetAllTasks()
    {
        return tasks;
    }

    public Task? GetTaskById(int taskId)
    {
        return tasks.FirstOrDefault(task => task.TaskId == taskId);
    }

    public void AddTask(Task task)
    {
        task.TaskId = nextTaskId++;
        tasks.Add(task);
    }

    public void UpdateTask(Task updatedTask)
    {
        Task? existingTask = GetTaskById(updatedTask.TaskId);
        if (existingTask != null)
        {
            // Update the existing task with the new values
            existingTask.TaskName = updatedTask.TaskName;
            existingTask.Description = updatedTask.Description;
            existingTask.Status = updatedTask.Status;
            existingTask.TaskLifecycleType = updatedTask.TaskLifecycleType;
        }
    }

    public void DeleteTask(int taskId)
    {
        Task? taskToRemove = GetTaskById(taskId);
        if (taskToRemove != null)
        {
            tasks.Remove(taskToRemove);
        }
    }
}
