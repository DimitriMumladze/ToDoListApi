using System.ComponentModel.DataAnnotations.Schema;

namespace ToDoListApi.Domain.Entities;

public class Status
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Name { get; set; }

    public ICollection<ToDoTask> ToDoTasks { get; set; }
}
