namespace ToDoListApi.Domain.Entities;

public class Task
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public Priority Level { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime DueToDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}
