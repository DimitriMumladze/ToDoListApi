using AutoMapper;
using MediatR;
using ToDoListApi.Domain.Repositories;

namespace ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskDelete;

public class ToDoTaskDeleteCommandHandler : IRequestHandler<ToDoTaskDeleteCommand>
{
    private readonly IMapper _mapper;
    private readonly IToDoTasksRepository _toDoTaskRepository;

    public ToDoTaskDeleteCommandHandler(IMapper mapper, IToDoTasksRepository toDoTaskRepository)
    {
        _mapper = mapper;
        _toDoTaskRepository = toDoTaskRepository;
    }
    public async Task Handle(ToDoTaskDeleteCommand request, CancellationToken cancellationToken)
    {
        var toDoTask = await _toDoTaskRepository.GetToDoTaskByIdAsync(request.Id);

        await _toDoTaskRepository.DeleteToDoTaskAsync(toDoTask);
    }
}
