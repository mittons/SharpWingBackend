public class MockDatabase : IDatabase
{
    private List<Task> tasks;
    private int nextTaskId;
    public MockDatabase()
    {
        tasks = CreateMockTasks();
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

            // Do not update parentId (no functionality implemented that allows for changes in task hierarchy):
            // existingTask.ParentId = updatedTask.ParentId;
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

    private List<Task> CreateMockTasks(){
        return new List<Task>
        {
            new Task
            {
                TaskId = 0,
                ParentId = null,
                TaskName = "Home",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 1,
                ParentId = 0,
                TaskName = "Daily - Weekday",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 2,
                ParentId = 0,
                TaskName = "Daily - Weekend",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 3,
                ParentId = 0,
                TaskName = "Piano practice",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.AdHoc
            },
            new Task
            {
                TaskId = 4,
                ParentId = 0,
                TaskName = "Cooking skill",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.AdHoc
            },
            new Task
            {
                TaskId = 5,
                ParentId = 0,
                TaskName = "Cross stich projects",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.AdHoc
            },
            new Task
            {
                TaskId = 6,
                ParentId = 1,
                TaskName = "Breakfast",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 7,
                ParentId = 1,
                TaskName = "Brush teeth",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 8,
                ParentId = 1,
                TaskName = "Make bed",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 9,
                ParentId = 1,
                TaskName = "Gather work bag, gym bag and essentials",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 10,
                ParentId = 1,
                TaskName = "Gym",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 11,
                ParentId = 1,
                TaskName = "Work",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 12,
                ParentId = 1,
                TaskName = "Put gym stuff in laundry and prepare next day's gym bag",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 13,
                ParentId = 1,
                TaskName = "Put away work bag",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 14,
                ParentId = 1,
                TaskName = "Plan activities post work",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 15,
                ParentId = 2,
                TaskName = "Breakfast",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 16,
                ParentId = 2,
                TaskName = "Brush teeth",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 17,
                ParentId = 2,
                TaskName = "Make bed",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 18,
                ParentId = 2,
                TaskName = "Work on a skillbuilding hobby",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 19,
                ParentId = 2,
                TaskName = "Plan leisure activities for the rest of the day",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 20,
                ParentId = 3,
                TaskName = "Determine song to practice and fetch sheets",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 21,
                ParentId = 3,
                TaskName = "Turn piano on",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 22,
                ParentId = 3,
                TaskName = "Practice song",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 23,
                ParentId = 3,
                TaskName = "Remember counting",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 24,
                ParentId = 3,
                TaskName = "Remember putting equal strength into dominant and non-dominant hand",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 25,
                ParentId = 3,
                TaskName = "Remember practicing each hand separately first",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 26,
                ParentId = 3,
                TaskName = "Remember sight-reading every note",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 27,
                ParentId = 3,
                TaskName = "Remember going as slow as I need",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 28,
                ParentId = 3,
                TaskName = "Turn piano off",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 29,
                ParentId = 3,
                TaskName = "Return sheet music to the sheet music folder",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 30,
                ParentId = 4,
                TaskName = "Select recipe to learn",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 31,
                ParentId = 4,
                TaskName = "Determine which materials are not in stock",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 32,
                ParentId = 4,
                TaskName = "Go grocery shopping",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 33,
                ParentId = 4,
                TaskName = "Clear work area and gather tools/materials for recipe",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 34,
                ParentId = 4,
                TaskName = "Read recipe through and stage work area",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 35,
                ParentId = 4,
                TaskName = "Follow recipe",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 36,
                ParentId = 4,
                TaskName = "Plate food",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 37,
                ParentId = 4,
                TaskName = "Put away leftover materials",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 38,
                ParentId = 4,
                TaskName = "Clean work area",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 39,
                ParentId = 4,
                TaskName = "Clean tools and return to storage",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            },
            new Task
            {
                TaskId = 40,
                ParentId = 4,
                TaskName = "Learn to cook dumplings",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.AdHoc
            },
            new Task
            {
                TaskId = 41,
                ParentId = 4,
                TaskName = "Learn to cook teriyaki chicken",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.AdHoc
            },
            new Task
            {
                TaskId = 42,
                ParentId = 4,
                TaskName = "Search for more vegetarian recipes",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.AdHoc
            },
            new Task
            {
                TaskId = 43,
                ParentId = 4,
                TaskName = "Research vegetarian substitutes for non-vegetarian ingredients",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.AdHoc
            },
            new Task
            {
                TaskId = 44,
                ParentId = 5,
                TaskName = "Clear workspace",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 45,
                ParentId = 5,
                TaskName = "Fetch workbag and withdraw tools/materials/pattern",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Setup
            },
            new Task
            {
                TaskId = 46,
                ParentId = 5,
                TaskName = "Work on pattern",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Recurring
            },
            new Task
            {
                TaskId = 47,
                ParentId = 5,
                TaskName = "Return tools/materials/pattern to workbag and store the bag",
                Description = "",
                CreatedDate = DateTime.Now,
                Status = "not completed",
                TaskLifecycleType = TaskLifecycleType.Closure
            }
        };
    }

}
