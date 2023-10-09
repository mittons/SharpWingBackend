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

    public Task GetRootTask()
    {
        var rootTask = _database.GetAllTasks().FirstOrDefault(t => t.ParentId == null);
        if (rootTask == null)
        {
            throw new Exception("Root task not found");
        }
        return rootTask;
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
        // First, fetch all tasks that should be deleted.
        var tasksToDelete = GetDescendants(taskId).ToList();
        
        // Add the main task to the list of tasks to delete.
        tasksToDelete.Add(taskId);

        // Now delete each task.
        foreach (var id in tasksToDelete)
        {
            _database.DeleteTask(id);
        }
    }

    private IEnumerable<int> GetDescendants(int parentTaskId)
    {
        var children = _database.GetAllTasks().Where(t => t.ParentId == parentTaskId).Select(t => t.TaskId);
        foreach (var child in children)
        {
            // Recursively get descendants of each child and flatten the result.
            yield return child;
            foreach (var descendant in GetDescendants(child))
            {
                yield return descendant;
            }
        }
    }

    public TaskDetailsResponse GetTaskDetails(int taskId)
    {
        var response = new TaskDetailsResponse();

        // Get the current task.
        response.CurrentTask = _database.GetTaskById(taskId);

        if(response.CurrentTask == null)
        {
            throw new Exception("Task not found");
        }

        // Get sub-tasks of the current task.
        response.SubTasks = _database.GetAllTasks().Where(t => t.ParentId == taskId).ToList();

        // Get path enumeration (ancestors of the current task).
        var currentAncestor = response.CurrentTask;
        response.PathEnumeration.Insert(0, currentAncestor);
        while(currentAncestor.ParentId != null)
        {
            var nextAncestor = _database.GetTaskById(currentAncestor.ParentId.Value); 
            if (nextAncestor == null) 
            {
                // This is an error state, means there's a missing link in the hierarchy
                // This error state can be handled differently based on the application's requirements
                throw new Exception($"Parent task with ID {currentAncestor.ParentId.Value} not found.");
            }
            currentAncestor = nextAncestor;
            response.PathEnumeration.Insert(0, currentAncestor); // Insert at start to maintain order.
        }

        return response;
    }
}