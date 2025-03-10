using MediatR;
using System.Windows.Input;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Domain.Entities;

namespace ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskSingleCreate;

public class ToDoTasksSingleCreateCommand : IRequest<ToDoTaskDto?>
{
    public string Title { get; set; }
    public int PriorityId { get; set; }
    public int StatusId { get; set; }
    public string Description { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime DueToDate { get; set; }
    public DateTime ModifiedDate { get; set; }
}
