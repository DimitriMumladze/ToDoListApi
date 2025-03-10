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
        var toDoTaskEntity = new ToDoTask
        {
            Title = request.Title,
            PriorityId = request.PriorityId,
            StatusId = request.StatusId,
            Description = request.Description,
            CreationDate = request.CreationDate,
            DueToDate = request.DueToDate,
            ModifiedDate = request.ModifiedDate
        };

        var toDoTaskCreate = await _toDoTaskRepository.CreateToDoTaskAsync(toDoTaskEntity);
        var toDoTaskDto = _mapper.Map<ToDoTaskDto?>(request);

        return toDoTaskDto;
    }
}
