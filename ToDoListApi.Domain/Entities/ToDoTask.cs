
namespace ToDoListApi.Domain.Entities;

public class ToDoTask
{
    public int Id { get; set; }
    public string? Title { get; set; }

    public int PriorityId { get; set; }
    public Priority? Priority { get; set; }

    public int StatusId { get; set; }
    public Status? Status { get; set; }

    public string? Description { get; set; } = "No description provided";
    public DateTime CreationDate { get; set; }
    public DateTime DueToDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}
