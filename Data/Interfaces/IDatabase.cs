public interface IDatabase
{
    List<Task> GetAllTasks();
    Task? GetTaskById(int taskId);
    void AddTask(Task task);
    void UpdateTask(Task updatedTask);
    void DeleteTask(int taskId);
}