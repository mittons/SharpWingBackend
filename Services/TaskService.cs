using System;
using System.Collections.Generic;
using System.Linq;

public class TaskService
{
    private TaskDatabase _taskDatabase;

    public TaskService()
    {
        _taskDatabase = new TaskDatabase(); // Initialize the in-memory database
    }

    public List<Task> GetAllTasks()
    {
        return _taskDatabase.GetAllTasks();
    }

    public Task? GetTaskById(int taskId)
    {
        return _taskDatabase.GetTaskById(taskId);
    }

    public Task AddTask(Task task)
    {
        _taskDatabase.AddTask(task);
        return task;
    }

    public Task UpdateTask(int taskId, Task updatedTask)
    {
        updatedTask.TaskId = taskId; // Ensure the updated task has the correct ID
        _taskDatabase.UpdateTask(updatedTask);
        return updatedTask;
    }

    public void DeleteTask(int taskId)
    {
        _taskDatabase.DeleteTask(taskId);
    }
}