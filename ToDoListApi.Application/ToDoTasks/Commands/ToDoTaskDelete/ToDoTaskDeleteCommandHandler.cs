using MediatR;
using ToDoListApi.Domain.Entities;
using ToDoListApi.Domain.Exceptions;
using ToDoListApi.Domain.Repositories;

namespace ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskDelete;

public class ToDoTaskDeleteCommandHandler : IRequestHandler<ToDoTaskDeleteCommand>
{
    private readonly IToDoTasksRepository _toDoTaskRepository;

    public ToDoTaskDeleteCommandHandler(IToDoTasksRepository toDoTaskRepository)
    {
        _toDoTaskRepository = toDoTaskRepository;
    }
    public async Task Handle(ToDoTaskDeleteCommand request, CancellationToken cancellationToken)
    {
        var toDoTaskById = await _toDoTaskRepository.GetToDoTaskByIdAsync(request.Id)
            ?? throw new NotFoundException(nameof(ToDoTask), request.Id.ToString());

        await _toDoTaskRepository.DeleteToDoTaskAsync(toDoTaskById);
    }
}
