using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

public class TaskService
{
    private IDatabase _database;

    public TaskService(IDatabase database)
    {
        _database = database; // Initialize the in-memory database
    }

    public List<Task> GetAllTasks()
    {
        return _database.GetAllTasks();
    }

    public Task? GetTaskById(int taskId)
    {
        return _database.GetTaskById(taskId);
    }

    public Task AddTask(Task task)
    {
        _database.AddTask(task);
        return task;
    }

    public Task UpdateTask(int taskId, Task updatedTask)
    {
        updatedTask.TaskId = taskId; // Ensure the updated task has the correct ID
        _database.UpdateTask(updatedTask);
        return updatedTask;
    }

    public void DeleteTask(int taskId)
    {
        _database.DeleteTask(taskId);
    }
}