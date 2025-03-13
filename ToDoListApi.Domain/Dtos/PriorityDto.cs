namespace ToDoListApi.Domain.Entities;

public class PriorityDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ToDoTask>? ToDoTasks { get; set; }
}
