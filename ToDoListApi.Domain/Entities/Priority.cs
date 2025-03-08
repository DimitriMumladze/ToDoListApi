namespace ToDoListApi.Domain.Entities;

public class Priority
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<ToDoTask> ToDoTasks { get; set; }
}
