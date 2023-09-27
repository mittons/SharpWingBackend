using System;
using System.Collections.Generic;
using System.Linq;

public class Task
{
    public int TaskId { get; set; }
    public string? TaskName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime DueDate { get; set; }
    public string? Status { get; set; }
    public string? Priority { get; set; }
}

public class TaskDatabase
{
    private List<Task> tasks;
    private int nextTaskId;
    public TaskDatabase()
    {
        tasks = new List<Task>
        {
            new Task
            {
                TaskId = 1,
                TaskName = "Mock Task 1",
                Description = "This is a mock task",
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(7),
                Status = "completed",
                Priority = "High"
            },
            new Task
            {
                TaskId = 2,
                TaskName = "Mock Task 2",
                Description = "Another mock task",
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(5),
                Status = "not completed",
                Priority = "Medium"
            },
            new Task
            {
                TaskId = 3,
                TaskName = "Mock Task 3",
                Description = "Yet another mock task",
                CreatedDate = DateTime.Now,
                DueDate = DateTime.Now.AddDays(10),
                Status = "completed",
                Priority = "Low"
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
            existingTask.DueDate = updatedTask.DueDate;
            existingTask.Status = updatedTask.Status;
            existingTask.Priority = updatedTask.Priority;
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
