public class TaskDetailsResponse
{
    public Task CurrentTask { get; set; }
    public List<Task> SubTasks { get; set; }
    public List<Task> PathEnumeration { get; set; }

    public TaskDetailsResponse()
    {
        SubTasks = new List<Task>();
        PathEnumeration = new List<Task>();
    }
}