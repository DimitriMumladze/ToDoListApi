using AutoMapper;
using MediatR;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Domain.Repositories;

namespace ToDoListApi.Application.ToDoTasks.Commands.ToDoTaskSingleCreate;

public class ToDoTasksSingleCreateCommandHandler : IRequestHandler<ToDoTasksSingleCreateCommand, ToDoTaskDto?>
{
  
    private readonly IMapper _mapper;
    private readonly IToDoTasksRepository _toDoTaskRepository;

    public ToDoTasksSingleCreateCommandHandler(IMapper mapper, IToDoTasksRepository toDoTaskRepository)
    {
        _mapper = mapper;
        _toDoTaskRepository = toDoTaskRepository;
    }

    public async Task<ToDoTaskDto?> Handle(ToDoTasksSingleCreateCommand request, CancellationToken cancellationToken)
    {
        var toDoTaskCreate = await _toDoTaskRepository.CreateToDoTaskAsync(request);
        var toDoTask = _mapper.Map<ToDoTaskDto>(request);

    }
}
