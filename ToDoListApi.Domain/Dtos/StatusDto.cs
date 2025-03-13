using ToDoListApi.Domain.Entities;

public class StatusDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<ToDoTask>? ToDoTasks { get; set; }
}
