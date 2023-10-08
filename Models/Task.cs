using System;
using System.Collections.Generic;
using System.Linq;

public class Task
{
    public int TaskId { get; set; }
    public string? TaskName { get; set; }
    public string? Description { get; set; }
    public DateTime CreatedDate { get; set; }
    public string? Status { get; set; }
    public TaskLifecycleType? TaskLifecycleType { get; set; }
}

public enum TaskLifecycleType
{
    Setup,
    Recurring,
    Closure,
    AdHoc
}
