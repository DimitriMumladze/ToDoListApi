using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApi.Domain.Entities;

public class Status
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IEnumerable<ToDoTask> ToDoTasks { get; set; }
}
