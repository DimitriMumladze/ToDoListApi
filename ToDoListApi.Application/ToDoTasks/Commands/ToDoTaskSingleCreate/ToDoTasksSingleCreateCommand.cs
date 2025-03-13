using MediatR;

namespace ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskSingleCreate;

public class ToDoTasksSingleCreateCommand : IRequest<int>
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int PriorityId { get; set; }
    public int StatusId { get; set; }
    public string Description { get; set; }
    // How to date time now
    public DateTime CreationDate { get; set; } = DateTime.Now;
    public DateTime DueToDate { get; set; }
    // How to modify time now
    public DateTime ModifiedDate { get; set; }
}
