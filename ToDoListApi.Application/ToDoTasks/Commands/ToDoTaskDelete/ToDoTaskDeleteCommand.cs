using MediatR;

namespace ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskDelete;

public class ToDoTaskDeleteCommand(int id) : IRequest
{
    public int Id { get; } = id;
}
