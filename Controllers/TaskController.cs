using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace TaskManagementBackend.Controllers
{
    [Route("api/tasks")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Task>> GetAllTasks()
        {
            var tasks = _taskService.GetAllTasks();
            
            return Ok(tasks);
        }

        [HttpGet("{taskId}")]
        public ActionResult<Task> GetTaskById(int taskId)
        {
            var task = _taskService.GetTaskById(taskId);
            if (task == null)
            {
                return NotFound(); // Task not found
            }

            return Ok(task);
        }

        [HttpPost]
        public ActionResult<Task> AddTask(Task task)
        {
            var addedTask = _taskService.AddTask(task);
            return CreatedAtAction(nameof(GetTaskById), new { taskId = addedTask.TaskId }, addedTask);
        }

        [HttpPut("{taskId}")]
        public IActionResult UpdateTask(int taskId, Task updatedTask)
        {
            var existingTask = _taskService.GetTaskById(taskId);
            if (existingTask == null)
            {
                return NotFound(); // Task not found
            }

            _taskService.UpdateTask(taskId, updatedTask);
            return NoContent();
        }

        [HttpDelete("{taskId}")]
        public IActionResult DeleteTask(int taskId)
        {
            var existingTask = _taskService.GetTaskById(taskId);
            if (existingTask == null)
            {
                return NotFound(); // Task not found
            }

            _taskService.DeleteTask(taskId);
            return NoContent();
        }
    }
}