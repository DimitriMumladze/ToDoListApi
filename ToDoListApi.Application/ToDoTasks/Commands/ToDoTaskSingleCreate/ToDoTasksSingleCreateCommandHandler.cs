using AutoMapper;
using MediatR;
using ToDoListApi.Application.ToDoTasks.Dtos;
using ToDoListApi.Domain.Entities;
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
        var todoTaskEntity = _mapper.Map<ToDoTask>(request);
        var createdToDoTask = await _toDoTaskRepository.CreateToDoTaskAsync(todoTaskEntity);
        var toDoTaskDto = _mapper.Map<ToDoTaskDto?>(createdToDoTask);

        return toDoTaskDto;
    }
}
