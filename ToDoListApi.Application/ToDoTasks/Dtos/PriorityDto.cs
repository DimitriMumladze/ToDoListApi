using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Application.ToDoTasks.Dtos;

public class PriorityDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<ToDoTask> ToDoTasks { get; set; }
}
