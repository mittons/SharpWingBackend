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
